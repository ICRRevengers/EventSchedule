import * as React from 'react';
import Card from '@mui/material/Card';
import CardActions from '@mui/material/CardActions';
import CardContent from '@mui/material/CardContent';
import CardMedia from '@mui/material/CardMedia';
import Button from '@mui/material/Button';
import Typography from '@mui/material/Typography';
import { useEffect, useState } from 'react';
import { useAdminEvents } from '../../recoil/adminEvents';
import { useSnackbar } from '../../HOCs';
import axios from 'axios';
import { APP_API_URL } from '../../config';

const UserHome = () => {
    const [events, setEvents] = useState([]);
    const showSackbar = useSnackbar();
    const { getEvents } = useAdminEvents()
    useEffect(() => {
        axios
        .get(`${APP_API_URL}api/Event/get-event-list`)
            .then((resposne) => {
                const data = resposne.data;
                setEvents(data);
                console.log(data);
            })
            .catch(() => {
                showSackbar({
                    severity: 'error',
                    children: 'Something went wrong, please try again later.',
                });
            });
    }, []);
  return (
    <Card sx={{ maxWidth: 345, marginLeft: 10, marginBottom: 5}}>
      <CardMedia
        component="img"
        height="140"
        image="/assets/images/campus.jpg"
        alt="green iguana"
      />
      <CardContent>
        <Typography gutterBottom variant="h5" component="div">
          Lizard
        </Typography>
        <Typography variant="body2" color="text.secondary">
          Lizards are a widespread group of squamate reptiles, with over 6,000
          species, ranging across all continents except Antarctica
        </Typography>
      </CardContent>
      <CardActions>
        <Button size="small">Share</Button>
        <Button size="small">Learn More</Button>
      </CardActions>
    </Card>
  );
}

export default UserHome;