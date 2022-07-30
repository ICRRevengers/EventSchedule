import {
    // Button,
    Card,
    CardContent,
    CardHeader,
    Divider,
    Grid,
    Typography,
    CardMedia
} from '@mui/material';

const EventDetailBottom = (props) => {
    const { item } = props;
    return (
        <>
            <Card>
                <CardHeader title="Detail" />
                <CardContent sx={{ mb: 10 }}>
                    <Grid container spacing={3}>
                        <Grid item xs={12}>
                            <Divider>Event</Divider>
                        </Grid>
                        <Grid item lg={12} md={12} xs={12}>
                            <Typography
                                color="textPrimary"
                                gutterBottom
                                variant="h4"
                            >
                                Tại sao nên tham gia sự kiện này?
                            </Typography>
                            <Typography
                                color="textPrimary"
                                gutterBottom
                                variant="h6"
                                sx={{ fontWeight: 'normal' }}
                            >
                                {item?.event_content}
                            </Typography>
                            <br />
                            <Typography
                                color="textPrimary"
                                gutterBottom
                                variant="h4"
                            >
                                Video
                            </Typography>
                            <Typography
                                color="textPrimary"
                                gutterBottom
                                variant="h6"
                                sx={{ fontWeight: 'normal' }}
                            >
                                {item?.video_url} 
                            </Typography>
                        </Grid>
                    </Grid>
                </CardContent>
            </Card>
        </>
    );
};

export default EventDetailBottom;
