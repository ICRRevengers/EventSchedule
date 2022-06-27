import * as React from 'react';
import Card from '@mui/material/Card';
import CardActions from '@mui/material/CardActions';
import CardContent from '@mui/material/CardContent';
import CardMedia from '@mui/material/CardMedia';
import Button from '@mui/material/Button';
import Typography from '@mui/material/Typography';

export default function CardEvent() {
  return (
    <Card sx={{ maxWidth: 300 }}>
      <CardMedia
        component="img"
        height="200"
        image="assets/images/event.png"
        alt="event"
      />
      <CardContent>
        <Typography gutterBottom variant="h5" component="div">
          BTS is coming
        </Typography>
        <Typography variant="body2" color="text.secondary">
        Look no further! BTS coming to FPTU are the simplest way for you to experience a live Kpop recording.
        </Typography>
      </CardContent>
      <CardActions>
        <Button size="small">Learn More</Button>
      </CardActions>
    </Card>
  );
}
