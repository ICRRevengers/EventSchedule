import { useEffect, useState } from 'react';
import '../../../App.scss';
import { useParams } from 'react-router-dom';
import Loading from '../../../components/loading/loading';
import { useUserEvents } from '../../../recoil/user';
import {
    Table,
    TableBody,
    TableCell,
    TableContainer,
    TableHead,
    TableRow,
    Typography,
    Paper,
    Button
} from '@mui/material';

function UserParticipatedList() {
    const { id } = useParams();
    const [loading, setLoading] = useState(false);
    const [events, setEvents] = useState([]);
    const { getEventIJoined } = useUserEvents();

    useEffect(() => {
        setLoading(true);
        getEventIJoined(id)
            .then((res) => {
                const data = res.data.data
                setEvents(data);
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
            <>
            {events.length === 0 ? <Typography>
                <h1 > Bạn chưa tham gia sự kiện nào </h1>
            </Typography> : (
        <TableContainer component={Paper} >
            <Table sx={{ minWidth: 650 }} aria-label="event list">
                <TableHead>
                    <TableRow>
                        <TableCell align="center">Tên sự kiện</TableCell>
                        <TableCell align="center">Tổ chức bởi</TableCell>
                        <TableCell align="center">Ngày tham gia</TableCell>
                        <TableCell align="center">Feedback</TableCell>
                    </TableRow>
                </TableHead>
                <TableBody>
                    {events?.map((event) => (
                    <TableRow
                        sx={{
                            '&:last-child td, &:last-child th': {
                                border: 0,
                            },
                        }}
                    >
                        <TableCell align="center">
                            {event?.event_name}
                        </TableCell>
                        <TableCell align="center">
                            Hehe
                        </TableCell>
                        <TableCell align="center">
                            {new Intl.DateTimeFormat('en-US', {
                                year: 'numeric',
                                month: 'short',
                                day: '2-digit',
                            }).format(
                                new Date(Date.parse(event.date_participated)),
                            )}
                        </TableCell>
                        <TableCell align="center">
                            <Button variant="contained">Feedback</Button>
                        </TableCell>                        
                    </TableRow>
                    ))}
                </TableBody>
            </Table>
        </TableContainer>

        )}
        </>
    );
}

export default UserParticipatedList;
