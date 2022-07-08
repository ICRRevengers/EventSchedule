import Sidebar from '../../../components/layout/sidebar/Sidebar';
import { useEffect, useState } from 'react';
import '../../../App.scss';
import { useParams } from 'react-router-dom';
import Loading from '../../../components/loading/loading';
import 
{
    Typography,
    Table,
    TableBody,
    TableCell,
    TableContainer,
    TableHead,
    TableRow
} from '@mui/material';
import Paper from '@mui/material/Paper';
import {FormControlLabel, Switch} from '@mui/material';
import { useAdminEvents } from '../../../recoil/adminEvents';

function ParticipatedList() {
    const { id } = useParams();
    const [loading, setLoading] = useState(false);
    const [students, setStudents] = useState([]);
    const { getStudentsFromEvent } = useAdminEvents();

    useEffect(() => {
        setLoading(true);
        getStudentsFromEvent(id)
            .then((res) => {
                const data = res.data
                setStudents(data);
                setTimeout(() => {
                    setLoading(false);
                }, 500);
            })
            .catch((error) => {
                console.log(error.response);
                setTimeout(() => {
                    setLoading(false);
                }, 500);
            });
    }, []);

    return loading ? (
        <Loading />
    ) : (
        <div className="flex">
            <Sidebar />
            {students.length === 0 ? <Typography>
                <h1 > Sự kiện <br/> hiện chưa có người đăng kí</h1>
            </Typography> : (
            <TableContainer component={Paper} sx={{ maxWidth: 980 }}>
                <Table sx={{ minWidth: 650}} aria-label="user list">
                    <TableHead>
                        <TableRow>
                            <TableCell >MSSV</TableCell>
                            <TableCell align="center">Họ tên</TableCell>
                            <TableCell align="center">Số điện thoại</TableCell>
                            <TableCell align="center">Email</TableCell>
                            <TableCell align="center">Thanh toán</TableCell>
                            <TableCell align="center">Ngày tham gia</TableCell>
                        </TableRow>
                    </TableHead>
                    <TableBody>
                    {students?.map((student) => (
                            <TableRow
                                key={student?.users_id}
                                sx={{
                                    '&:last-child td, &:last-child th': {
                                        border: 0,
                                    },
                                }}
                            >
                                <TableCell component="th" scope="row">{student?.users_id}</TableCell>
                                <TableCell align="center">{student?.users_name}</TableCell>
                                <TableCell align="center">{student.users_phone}</TableCell>
                                <TableCell align="center">{student.users_email}</TableCell>                                
                                <TableCell align="center">
                                    <FormControlLabel control={<Switch checked={student.payment_status} value={student.payment_status} />} label='Thanh toán'/>
                                </TableCell>
                                <TableCell align="center">
                                {new Intl.DateTimeFormat('en-US', { year: 'numeric', month: 'short', day: '2-digit' }).format(new Date(Date.parse(student.date_participated)))}
                                </TableCell>
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
