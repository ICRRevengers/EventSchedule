import Sidebar from '../../../components/layout/sidebar/Sidebar';
import { useEffect, useState } from 'react';
import '../../../App.scss';
import { useParams } from 'react-router-dom';
import Loading from '../../../components/loading/loading';
import {
    Typography,
    Table,
    TableBody,
    TableCell,
    TableContainer,
    TableHead,
    TableRow,
} from '@mui/material';
import Paper from '@mui/material/Paper';
import { FormControlLabel, Switch } from '@mui/material';
import { useAdminEvents } from '../../../recoil/adminEvents';
import { useSnackbar } from '../../../HOCs';
import { useRef } from 'react';
function ParticipatedList() {
    const { id } = useParams();
    const [loading, setLoading] = useState(false);
    const [students, setStudents] = useState([]);
    const [tempArr, settempArr] = useState([]);
    const { getStudentsFromEvent, updatePayment } = useAdminEvents();
    const showSackbar = useSnackbar();
    const cleanup = useRef(1);
    useEffect(() => {
        let isMounted = true;
        let abortController = new AbortController();
        setLoading(true);
        getStudentsFromEvent(id)
            .then((res) => {
                const data = res.data.data;
                if (isMounted) {
                    // console.log(data)
                    setStudents(data);
                    const paymentStatusArray = data.map(
                        (res) => res.payment_status,
                    );
                    settempArr(paymentStatusArray);
                    cleanup.current = setTimeout(() => {
                        setLoading(false);
                    }, 500);
                    console.log(cleanup.current);
                }
            })
            .catch((error) => {
                console.log(error.response);
                cleanup.current = setTimeout(() => {
                    setLoading(false);
                }, 500);
            });

        return () => {
            isMounted = false;
            abortController.abort();
            clearTimeout(cleanup.current);
        };
    }, []);
    console.log(cleanup.current);
    const changePayment = (userId, status, index) => {
        let paymentStatus = status === true ? false : true;
        updatePayment(paymentStatus, userId, id)
            .then((resposne) => {
                showSackbar({
                    severity: 'success',
                    children: 'Update Successfully',
                });
                let arr = students;
                arr[index].payment_status = paymentStatus;
                const paymentStatusArray = arr.map((res) => res.payment_status);
                settempArr(paymentStatusArray);
            })
            .catch((error) => {
                showSackbar({
                    severity: 'error',
                    children: 'Something went wrong, please try again later.',
                });
            });
        // window.location.reload(false);
    };

    return loading ? (
        <Loading />
    ) : (
        <div className="flex">
            <Sidebar />
            {students.length === 0 ? (
                <Typography>
                    <h1>
                        {' '}
                        Sự kiện <br /> hiện chưa có người đăng kí
                    </h1>
                </Typography>
            ) : (
                <TableContainer component={Paper} sx={{ maxWidth: 980 }}>
                    <Table sx={{ minWidth: 650 }} aria-label="user list">
                        <TableHead>
                            <TableRow>
                                <TableCell>STT</TableCell>
                                <TableCell align="center">Họ tên</TableCell>
                                <TableCell align="center">Email</TableCell>
                                <TableCell align="center">Thanh toán</TableCell>
                                <TableCell align="center">
                                    Ngày tham gia
                                </TableCell>
                            </TableRow>
                        </TableHead>
                        <TableBody>
                            {students?.map((student, i) => (
                                <TableRow
                                    key={student?.users_id}
                                    sx={{
                                        '&:last-child td, &:last-child th': {
                                            border: 0,
                                        },
                                    }}
                                >
                                    <TableCell component="th" scope="row">
                                        {i +1}
                                    </TableCell>
                                    <TableCell align="center">
                                        {student?.users_name}
                                    </TableCell>
                                    <TableCell align="center">
                                        {student.users_email}
                                    </TableCell>
                                    <TableCell align="center">
                                        <FormControlLabel
                                            control={
                                                <Switch
                                                    checked={tempArr[i]}
                                                    value={tempArr[i]}
                                                    onClick={() =>
                                                        changePayment(
                                                            student?.users_id,
                                                            student.payment_status,
                                                            i,
                                                        )
                                                    }
                                                />
                                            }
                                            label="Thanh toán"
                                        />
                                    </TableCell>
                                    {student.date_participated !== null ? (
                                        <TableCell align="center">
                                            {/* {new Intl.DateTimeFormat('en-US', {
                                                year: 'numeric',
                                                month: 'short',
                                                day: '2-digit',
                                            }).format(
                                                new Date(
                                                    Date.parse(
                                                        student.date_participated,
                                                    ),
                                                ),
                                            )} */}
                                            {student.date_participated}
                                        </TableCell>
                                    ) : (
                                        <TableCell align="center">
                                            Không tham gia
                                        </TableCell>
                                    )}
                                </TableRow>
                            ))}
                        </TableBody>
                    </Table>
                </TableContainer>
            )}
        </div>
    );
}

export default ParticipatedList;
