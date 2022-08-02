import { Box, Container, Grid} from '@mui/material';
import React, { useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';
import EventDetailHeader from './eventdetailheader';
import EventDetailBottom from './eventdetailbottom';
import { useUserEvents } from '../../recoil/user';
import { useSnackbar } from '../../HOCs';
import Feedback from './Feedback';

const EventDetailAdmin = () => {
    const [eveDetails, setEventDetail] = useState({});
    const { id } = useParams();
    const { getDetailFromEvent } = useUserEvents();
    const showSackbar = useSnackbar();
    useEffect(() => {
        getDetailFromEvent(id)
            .then((resposne) => {
                const data = resposne.data.data;
                console.log(data);
                setEventDetail(data[0]);
            })
            .catch(() => {
                showSackbar({
                    severity: 'error',
                    children: 'Something went wrong, please try again later.',
                });
            });
    }, []);

    return (
        <React.Fragment>
            <Feedback/>
            <Box sx={{ m: 20 }}>
                <Container sx={{ m: 1 }}>
                    <Grid container spacing={3}>
                        <Grid item lg={12} md={12} xs={12}>
                            <EventDetailHeader item={eveDetails} />
                        </Grid>
                        <Grid item lg={12} md={12} xs={12}>
                            <EventDetailBottom item={eveDetails} />
                        </Grid>
                    </Grid>
                </Container>
            </Box>
        </React.Fragment>
    );
};

export default EventDetailAdmin;
