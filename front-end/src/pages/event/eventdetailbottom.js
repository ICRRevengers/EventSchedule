import {
    // Button,
    Card,
    CardContent,
    CardHeader,
    Divider,
    Grid,
    Typography,
    CardMedia,
    Box,
} from '@mui/material';

const EventDetailBottom = (props) => {
    const { item } = props;
    return (
        <>
            <Card>
                <CardContent sx={{ mb: 10 }}>
                    <Grid container spacing={3}>
                        <Grid item lg={12} md={12} xs={12}>
                            <Typography
                                color="textPrimary"
                                gutterBottom
                                variant="h4"
                            >
                                Tại sao nên tham gia sự kiện này?
                            </Typography>
                            <Box sx={{ display: 'flex' }}>
                                <Typography
                                    color="textPrimary"
                                    gutterBottom
                                    variant="h6"
                                    sx={{
                                        fontWeight: 'normal',
                                        flexBasis: '66%',
                                    }}
                                >
                                    {item?.event_content}
                                </Typography>
                                <Box sx={{ flexBasis: '50%' }}>
                                    <Box
                                        sx={{
                                            display: 'flex',
                                            alignItems: 'center',
                                            textAlign: 'justify'
                                        }}
                                    >
                                        <Box sx={{ flexBasis: '80%' }}>
                                            <Box
                                                component="img"
                                                alt="school-image"
                                                src={item?.image_url}
                                                sx={{
                                                    width: '100%',
                                                    // aspectRatio: '1 / 1',bbbbbb
                                                    objectFit: 'container',
                                                    margin: '0 5%'
                                                }}
                                            />
                                        </Box>
                                    </Box>
                                </Box>
                            </Box>
                        </Grid>
                    </Grid>
                </CardContent>
            </Card>
        </>
    );
};

export default EventDetailBottom;
