import Sidebar from '../../../components/layout/sidebar/Sidebar';
import '../../../App.scss';
import { useEffect, useState } from 'react';
import { Link } from 'react-router-dom';
import {
    Table,
    TableBody,
    TableCell,
    TableContainer,
    TableHead,
    TableRow,
} from '@mui/material';
import Paper from '@mui/material/Paper';
import Button from '@mui/material/Button';
import { useAdminEvents } from '../../../recoil/adminEvents';
import { useSnackbar } from '../../../HOCs';

const ManageEvents = () => {
    const [events, setEvents] = useState([]);
    const showSackbar = useSnackbar();
    const { getEvents } = useAdminEvents()
    useEffect(() => {
        getEvents()
            .then((resposne) => {
                const data = resposne.data;
                setEvents(data);
            })
            .catch(() => {
                showSackbar({
                    severity: 'error',
                    children: 'Something went wrong, please try again later.',
                });
            });
    }, []);

    return (
        <div className="flex">
            <Sidebar />
            <TableContainer component={Paper} sx={{ maxWidth: 980 }}>
                <Table sx={{ minWidth: 650 }} aria-label="event list">
                    <TableHead>
                        <TableRow>
                            <TableCell>Mã số</TableCell>
                            <TableCell align="center">Tên sự kiện</TableCell>
                            <TableCell align="center">Người tham gia</TableCell>
                            <TableCell align="center">Chi tiết</TableCell>
                            <TableCell align="center">Cập nhật</TableCell>
                            <TableCell align="center">Xóa</TableCell>
                        </TableRow>
                    </TableHead>
                    <TableBody>
                        {events?.map((event) => (
                            <TableRow
                                key={event?.event_id}
                                sx={{
                                    '&:last-child td, &:last-child th': {
                                        border: 0,
                                    },
                                }}
                            >
                                <TableCell component="th" scope="row">
                                    {event?.event_id}
                                </TableCell>
                                <TableCell align="center">
                                    {event?.event_name}
                                </TableCell>
                                <TableCell align="center">
                                    <Link
                                        to={`/admin/manage/participated/${event.event_id}`}
                                    >
                                        <Button variant="contained">
                                            Danh sách
                                        </Button>
                                    </Link>
                                </TableCell>
                                <TableCell align="center">
                                    <Button
                                        variant="contained"
                                        href="/admin/manage/eventdetail"
                                    >
                                        Xem
                                    </Button>
                                </TableCell>
                                <TableCell align="center">
                                    <Link to={`/admin/manage/update`}>
                                        <Button variant="contained">
                                            Cập nhật
                                        </Button>
                                    </Link>
                                </TableCell>
                                <TableCell align="center">
                                    <Button variant="contained">Xóa</Button>
                                </TableCell>
                            </TableRow>
                        ))}
                    </TableBody>
                </Table>
            </TableContainer>
        </div>
    );
};

export default ManageEvents;
