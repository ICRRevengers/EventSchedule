import Sidebar from '../../../components/layout/sidebar/Sidebar';
import '../../../App.scss';
import { useEffect, useState } from 'react';
import { Link } from 'react-router-dom';
import {
    InputLabel,
    Table,
    TableBody,
    TableCell,
    TableContainer,
    TableHead,
    TableRow,
    TextField,
} from '@mui/material';
import Paper from '@mui/material/Paper';
import Button from '@mui/material/Button';
import { useAdminEvents } from '../../../recoil/adminEvents';
import { useSnackbar } from '../../../HOCs';
import AlertConfirm from '../../../components/ConfirmDialog';
import authAtom from '../../../recoil/auth/atom';
import { useRecoilValue } from 'recoil';

const ManageEvents = () => {
    const [events, setEvents] = useState([]);
    const showSackbar = useSnackbar();
    const { getEvents, deleteEvent, searchEvent, getHostEvents } = useAdminEvents();
    const [name, setName] = useState('');
    const [openDialog, setOpenDialog] = useState(false);
    const [eventId, setEventId] = useState(-1);
    const [hostedEvents, setHostedEvents] = useState([])
    const auth = useRecoilValue(authAtom);

    const openDiaglogHandler = (eventId) => {
        setOpenDialog(true);
        setEventId(eventId);
    };

    const closeDialogHanlder = () => {
        setOpenDialog(false);
        setEventId(-1);
    };

    function deleteItem(id) {
        deleteEvent(id)
            .then((resposne) => {
                const deletedArray = events.filter(
                    (event) => event.event_id !== id,
                );
                setEvents(deletedArray);
                showSackbar({
                    severity: 'success',
                    children: resposne.data,
                });
            })
            .catch(() => {
                showSackbar({
                    severity: 'error',
                    children: 'Something went wrong, please try again later.',
                });
            });
    }

    const eventNameHandler = (event) => {
        setName(event.target.value);
    };

    function searchEventlist(name) {
        searchEvent(name)
            .then((resposne) => {
                const data = resposne.data.data;
                setEvents(data);
            })
            .catch((error) => {
                showSackbar({
                    severity: 'error',
                    children: 'Something went wrong, please try again later.',
                });
            });
    }

    useEffect(() => {
        getEvents()
            .then((resposne) => {
                const data = resposne.data.data;
                setEvents(data);
            })
            .catch(() => {
                showSackbar({
                    severity: 'error',
                    children: 'Something went wrong, please try again later.',
                });
            });
        getHostEvents(auth.userId).then(response => {
            const data = response.data.data
            if(data !== null) {
                setHostedEvents(data)
            }else{
                alert("Bạn chưa tạo sự kiên nảo, vui lòng tạo sự kiện mới.")
            }
        }).catch(error => {
            console.log(error.response);
        })

    }, []);

    return (
        <div className="flex">
            <Sidebar />
            <TableContainer component={Paper} sx={{ maxWidth: 980 }}>
                <InputLabel
                    sx={{ paddingLeft: 2, paddingTop: 2 }}
                    className="adminLabel"
                >
                    Nhập tên sự kiện cần tìm ở đây ...
                </InputLabel>
                <TextField
                    sx={{ padding: 2 }}
                    id="filled-basic"
                    variant="filled"
                    onChange={eventNameHandler}
                    onKeyPress={(event) => {
                        if (event.key === 'Enter') {
                            searchEventlist(name);
                        }
                    }}
                    fullWidth
                />
                <Table
                    sx={{ minWidth: 650, marginTop: 2 }}
                    aria-label="event list"
                >
                    <TableHead>
                        <TableRow>
                            <TableCell>Tên sự kiện</TableCell>
                            <TableCell align="center">Người tham gia</TableCell>
                            <TableCell align="center">Chi tiết</TableCell>
                            <TableCell align="center">Cập nhật</TableCell>
                            <TableCell align="center">Xóa</TableCell>
                        </TableRow>
                    </TableHead>
                    <TableBody>
                        {auth.role === 'admin' ? events.map((event) => (
                            <TableRow
                                key={event?.event_id}
                                sx={{
                                    '&:last-child td, &:last-child th': {
                                        border: 0,
                                    },
                                }}
                            >
                                <TableCell component="th" scope="row">
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
                                    <Link
                                        to={`/admin/manage/eventdetail/${event.event_id}`}
                                    >
                                        <Button variant="contained">Xem</Button>
                                    </Link>
                                </TableCell>
                                <TableCell align="center">
                                    <Link
                                        to={`/admin/manage/update/${event.event_id}`}
                                    >
                                        <Button variant="contained">
                                            Cập nhật
                                        </Button>
                                    </Link>
                                </TableCell>
                                <TableCell align="center">
                                    <Button
                                        onClick={(e) =>
                                            openDiaglogHandler(event.event_id)
                                        }
                                        variant="contained"
                                    >
                                        Xóa
                                    </Button>
                                </TableCell>
                            </TableRow>
                        )) : hostedEvents.map(event => (
                            <TableRow
                                key={event?.event_id}
                                sx={{
                                    '&:last-child td, &:last-child th': {
                                        border: 0,
                                    },
                                }}
                            >
                                <TableCell component="th" scope="row">     
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
                                    <Link
                                        to={`/admin/manage/eventdetail/${event.event_id}`}
                                    >
                                        <Button variant="contained">Xem</Button>
                                    </Link>
                                </TableCell>
                                <TableCell align="center">
                                    <Link
                                        to={`/admin/manage/update/${event.event_id}`}
                                    >
                                        <Button variant="contained">
                                            Cập nhật
                                        </Button>
                                    </Link>
                                </TableCell>
                                <TableCell align="center">
                                    <Button
                                        onClick={(e) =>
                                            openDiaglogHandler(event.event_id)
                                        }
                                        variant="contained"
                                    >
                                        Xóa
                                    </Button>
                                </TableCell>
                            </TableRow>
                        ))}
                    </TableBody>
                </Table>
            </TableContainer>
            <AlertConfirm
                title={'Xóa event'}
                children={'Bạn có chắc chắn xóa event này không?'}
                onClose={closeDialogHanlder}
                onConfirm={() => deleteItem(eventId)}
                open={openDialog}
                btnConfirmText={'Xóa'}
            />
        </div>
    );
};

export default ManageEvents;
