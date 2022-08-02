import React, { useEffect, useState } from 'react';
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
    Button,
} from '@mui/material';
import CreateFeedBack from '../feedback/CreateFeedback';

function UserParticipatedList() {
    const { id } = useParams();
    const [loading, setLoading] = useState(false);
    const [events, setEvents] = useState([]);
    const { getEventIJoined } = useUserEvents();
    const [openFeedback, setOpenFeedBack] = useState(false);
    const [isClickableFeedback, setIsClickableFeedback] = useState(null);
    const [ableToFeedback, setAbleToFeedback] = useState(true)

    const feedbackOpenHandler = (eventId) => {
        setOpenFeedBack(true);
        setIsClickableFeedback(eventId);
    };
    const feedbackCloseHandler = () => {
        setOpenFeedBack(false);
    };

    useEffect(() => {
        setLoading(true);
        getEventIJoined(id)
            .then((res) => {
                const data = res.data.data;
                console.log(data);
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
        <React.Fragment>
            {events.length === 0 ? (
                <Typography>
                    <h1> Bạn chưa tham gia sự kiện nào </h1>
                </Typography>
            ) : (
                <TableContainer component={Paper}>
                    <Table sx={{ minWidth: 650 }} aria-label="event list">
                        <TableHead>
                            <TableRow>
                                <TableCell align="center">
                                    Tên sự kiện
                                </TableCell>
                                <TableCell align="center">
                                    Tổ chức bởi
                                </TableCell>
                                <TableCell align="center">
                                    Ngày tham gia
                                </TableCell>
                                <TableCell align="center">Feedback</TableCell>
                            </TableRow>
                        </TableHead>
                        <TableBody>
                            {events?.map((event) => (
                                <TableRow
                                    key={event.event_id}
                                    sx={{
                                        '&:last-child td, &:last-child th': {
                                            border: 0,
                                        },
                                    }}
                                >
                                    <TableCell align="center">
                                        {event?.event_name}
                                    </TableCell>
                                    <TableCell align="center">{event?.admin_name}</TableCell>
                                    <TableCell align="center">
                                        {/* {new Intl.DateTimeFormat('en-US', {
                                            year: 'numeric',
                                            month: 'short',
                                            day: '2-digit',
                                        }).format(
                                            new Date(
                                                Date.parse(
                                                    event.date_participated,
                                                ),
                                            ),
                                        )} */}
                                        {event.date_participated}
                                    </TableCell>
                                    <TableCell align="center">
                                        {(event.event_id ===
                                            isClickableFeedback &&
                                            openFeedback) === true ? (
                                            <Button
                                                variant="contained"
                                                onClick={() =>
                                                    feedbackOpenHandler(
                                                        event.event_id,
                                                    )
                                                }
                                                disabled={event.is_feedback || (!ableToFeedback && event.event_id === isClickableFeedback)}
                                                sx={{
                                                    opacity: 0.5,
                                                }}
                                            >
                                                Feedback
                                            </Button>
                                        ) : (
                                            <Button
                                                variant="contained"
                                                onClick={() =>
                                                    feedbackOpenHandler(
                                                        event.event_id,
                                                    )
                                                }
                                                sx={{
                                                    opacity: 1,
                                                }}
                                                disabled={event.is_feedback || (!ableToFeedback && event.event_id === isClickableFeedback)}
                                            >
                                                Feedback
                                            </Button>
                                        )}
                                    </TableCell>
                                </TableRow>
                            ))}
                        </TableBody>
                    </Table>
                </TableContainer>
            )}
            {openFeedback && (
                <CreateFeedBack
                    open={openFeedback}
                    onClose={feedbackCloseHandler}
                    eventId={isClickableFeedback}
                    userId={id}
                    setAbleToFeedback={setAbleToFeedback}
                />
            )}
        </React.Fragment>
    );
}

export default UserParticipatedList;
