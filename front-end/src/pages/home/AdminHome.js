import * as React from 'react';
import {
    Card,
    CardActions,
    CardContent,
    CardMedia,
    Button,
    Typography,
    Box,
    Grid,
    Paper,
    FormControl,
    Input,
    Select,
    MenuItem,
    experimentalStyled as styled,
    Stack,
} from '@mui/material/';
import { useEffect, useState } from 'react';
import { useAdminEvents } from '../../recoil/adminEvents';
import { useSnackbar } from '../../HOCs';

const Item = styled(Paper)(({ theme }) => ({
    backgroundColor: theme.palette.mode === 'dark' ? '#1A2027' : '#fff',
    ...theme.typography.body2,
    padding: theme.spacing(2),
    textAlign: 'center',
    color: theme.palette.text.secondary,
}));

const AdminHome = () => {
    const [events, setEvents] = useState([]);
    const showSackbar = useSnackbar();
    const { getEvents, searchEvent, searchEventTime, getUpcomingEvent, getPastEvent } = useAdminEvents();
    const [name, setName] = useState('');
    const [date, setDate] = useState('20-02-2022');

    useEffect(() => {
        getEvents()
            .then((resposne) => {
                const data = resposne.data.data;
                console.log(data);
                setEvents(data);
            })
            .catch((ERROR) => {
                console.log(ERROR.resposne);
                showSackbar({
                    severity: 'error',
                    children: 'Something went wrong, please try again later.',
                });
            });
    }, []);

    const [values, setValues] = useState();

    const handleChange = (event) => {
        console.log(event.target.value);
        if(event.target.value == 0){ // Tất cả
            getEvents()
            .then((resposne) => {
                const data = resposne.data.data;
                console.log(data);
                setEvents(data);
            })
            .catch((ERROR) => {
                console.log(ERROR.resposne);
                showSackbar({
                    severity: 'error',
                    children: 'Something went wrong, please try again later.',
                });
            });
        }
        else if(event.target.value == 1){ // Upcoming Events
            getUpcomingEvent()
            .then((resposne) => {
                const data = resposne.data.data;
                console.log(data);
                setEvents(data);
            })
            .catch((ERROR) => {
                console.log(ERROR.resposne);
                showSackbar({
                    severity: 'error',
                    children: 'Something went wrong, please try again later.',
                });
            });
        }else if(event.target.value == 2){ // Past Events
            getPastEvent()
            .then((resposne) => {
                const data = resposne.data.data;
                console.log(data);
                setEvents(data);
            })
            .catch((ERROR) => {
                console.log(ERROR.resposne);
                showSackbar({
                    severity: 'error',
                    children: 'Something went wrong, please try again later.',
                });
            });
        }
    };

    const eventNameHandler = (event) => {
        setName(event.target.value);
    };

    const eventDateHandler = (event) => {
        console.log(event.target.value);
        setDate(event.target.value);
    };

    const handleSubmit = (event) => {
        alert('A name was submitted: ' + this.state.value);
        event.preventDefault();
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
    function searchEventByTime(date) {
        searchEventTime(date)
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
    

    return (
        <>
            <Box sx={{ flexGrow: 1 }}>
                <Grid
                    container
                    padding={{ xs: 2, md: 5 }}
                    columns={{ xs: 3, sm: 12 }}
                >
                    <Grid item xs={4} padding={{ sm: 2 }}>
                        <FormControl fullWidth>
                            <Input
                                placeholder="Tên sự kiện..."
                                onChange={eventNameHandler}
                                name="searchEvent"
                                id="searchEventName"
                                type="text"
                                onKeyPress={(event) => {
                                    if (event.key === 'Enter') {
                                        searchEventlist(name);
                                    }
                                }}
                            />
                        </FormControl>
                    </Grid>
                    <Grid item xs={4} padding={{ sm: 2 }}>
                        <FormControl fullWidth>
                            <Input
                                onChange={eventDateHandler}
                                name="searchEvent"
                                id="searchEventTime"
                                type="date"
                                onKeyPress={(event) => {
                                    if (event.key === 'Enter') {
                                        searchEventByTime(date);
                                    }
                                }}
                                min="20-02-2022" max="20-02-2032"
                            />
                        </FormControl>
                    </Grid>
                    <Grid item xs={4} padding={{ sm: 2 }}>
                        <FormControl fullWidth variant="standard">
                            <Select id="searchStatus" onChange={handleChange}>
                                <MenuItem value={0}>Tất cả</MenuItem>
                                <MenuItem value={1}>Sắp diễn ra</MenuItem>
                                <MenuItem value={2}>Đã diễn ra</MenuItem>
                            </Select>
                        </FormControl>
                    </Grid>
                    {/* <Grid item xs={3} padding={{ sm: 2 }}>
                        <FormControl fullWidth>
                            <Button variant="contained" onClick={handleSubmit}>
                                Tìm kiếm
                            </Button>
                        </FormControl>
                    </Grid> */}
                </Grid>
            </Box>
            <Box sx={{ flexGrow: 1 }}>
            {events.length === 0 ? (
                    <Stack sx={{
                        width: '370px',
                        alignItems: 'center',
                        justifyContent: 'center',
                        margin: '0 auto',
                        paddingTop: '20px',
                    }}
                    spacing={2}>
                            Sự kiện bạn tìm kiếm hiện không có.
                    </Stack>
            ) : (
                <Grid
                    container
                    padding={{ xs: 2, md: 5 }}
                    spacing={{ xs: 2, md: 3 }}
                    columns={{ xs: 4, sm: 8, md: 12 }}
                >
                    {events?.map((event) => (
                        <Grid item xs={2} sm={4} md={4} key={event?.event_id}>
                            <Card sx={{height: '650px'}}>
                                <CardMedia
                                    component="img"
                                    sx={{height: '450px'}}
                                    image={event?.image_url}
                                    alt={event.event_name}
                                />
                                <CardContent>
                                    <Typography
                                        gutterBottom
                                        variant="h5"
                                        component="div"
                                    >
                                        {event.event_name}
                                    </Typography>
                                    <Typography
                                        variant="body2"
                                        color="text.secondary"
                                    >
                                        {event.event_start} - {event.event_end}
                                    </Typography>
                                </CardContent>
                                <CardActions>
                                    <Button size="small">Chi tiết</Button>
                                </CardActions>
                            </Card>
                        </Grid>
                    ))}                      
                </Grid>
            )}
            </Box>
        </>
    );
};

export default AdminHome;
