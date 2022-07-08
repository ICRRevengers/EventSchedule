import { useParams, Link as RouterLink } from 'react-router-dom';
import {
    Container,
    Box,
    Stack,
    Typography,
    Card,
    Divider,
    CardContent,
    Grid,
    Avatar,
    Button,
    IconButton,
    Link,
} from '@mui/material';
import ArrowCircleLeftIcon from '@mui/icons-material/ArrowCircleLeft';
import { useUserEvents } from '../../recoil/user';
import { useSnackbar } from '../../HOCs';
import { useEffect,useState } from 'react';

const AdminStudentProfile = () => {
    const [payment, setPayment] = useState({});
    const { id } = useParams();
    const { getPayment } = useUserEvents();
    const showSackbar = useSnackbar();
    useEffect(() => {
        getPayment(id)
        .then((resposne) => {
            const data = resposne.data.data
            // console.log(data);
            setPayment(data[0]);
        })
        .catch(() => {
            showSackbar({
                severity: 'error',
                children: 'Something went wrong, please try again later.',
            });
        });
    },[])

    return (
        <Box sx={{ mb: 20 }}>
            <Container maxWidth="xl" sx={{ bgcolor: 'background.paper' }}>
                <Stack
                    direction="row"
                    alignItems="center"
                    // justifyContent="space-between"
                    mb={2}
                >
                    <IconButton
                        component={RouterLink}
                        to={`/user/eventdetail/${id}`}
                        color="primary"
                        aria-label="delete"
                        size="large"
                    >
                        <ArrowCircleLeftIcon fontSize="inherit" />
                    </IconButton>

                    <Typography
                        variant="h4"
                        // gutterBottom
                        sx={{ fontStyle: 'italic', fontWeight: 400 }}
                    >
                        Payment
                    </Typography>
                </Stack>

                <Divider sx={{ mb: 5, bgcolor: 'primary.light' }} />

                <Card
                    sx={{
                        display: 'flex',
                        flexDirection: 'row',
                    }}
                >
                    <CardContent style={{ width: '60%' }}>
                        <Grid
                            container
                            item
                            xs={12}
                            direction="column"
                            justifyContent="center"
                            alignItems="center"
                        >
                            <Grid sx={{mt: 6, mb: 7}}>
                                <Avatar
                                    src="https://coin68.com/wp-content/uploads/2019/04/momo-la-gi.png"
                                    sx={{
                                        height: 400,
                                        width: 750,
                                        borderRadius: '16px',
                                    }}
                                    variant="square"
                                />
                            </Grid>
                            {/* <Grid sx={{ p: 2, border: '1px dashed grey' }}>
                                <Link href="google.com">Link</Link>
                            </Grid> */}
                        </Grid>
                    </CardContent>

                    <Card style={{ width: '40%' }} sx={{ mt: 5, mb: 13 }}>
                        <CardContent>
                            <Grid container spacing={2}>
                                <Grid
                                    container
                                    item
                                    xs={12}
                                    sx={{ mb: 5 }}
                                    direction="row"
                                    justifyContent="center"
                                    alignItems="center"
                                >
                                    <Grid>
                                        <Typography
                                            variant="h4"
                                            sx={{ fontWeight: 'bold' }}
                                            color="primary"
                                        >
                                            You are paying for
                                        </Typography>
                                    </Grid>
                                    <Grid sx={{ ml: 3 }}>
                                        <Avatar
                                            src="data:image/png;base64,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"
                                            sx={{
                                                height: 65,
                                                width: 65,
                                            }}
                                            variant="square"
                                        />
                                    </Grid>
                                </Grid>

                                <Grid
                                    container
                                    item
                                    xs={12}
                                    direction="row"
                                    justifyContent="center"
                                    sx={{ mb: 3 }}
                                >
                                    <Grid item xs={2.5}>
                                        <Typography
                                            variant="h5"
                                            gutterBottom
                                            sx={{ fontWeight: 500 }}
                                        >
                                            Details:
                                        </Typography>
                                    </Grid>
                                    <Grid item xs={8.5}>
                                        <Typography
                                            variant="h5"
                                            gutterBottom
                                            sx={{ fontWeight: 300 }}
                                        >
                                            {payment?.payment_detail}
                                            
                                        </Typography>
                                    </Grid>
                                </Grid>

                                <Grid lg={12} md={12} xs={12} sx={{ mb: 3 }}>
                                    <Divider />
                                </Grid>

                                <Grid
                                    container
                                    item
                                    xs={12}
                                    direction="row"
                                    justifyContent="center"
                                    sx={{ mb: 3 }}
                                >
                                    <Grid item xs={2.5}>
                                        <Typography
                                            variant="h5"
                                            gutterBottom
                                            sx={{ fontWeight: 500 }}
                                        >
                                            Price:
                                        </Typography>
                                    </Grid>
                                    <Grid item xs={8.5}>
                                        <Typography
                                            variant="h5"
                                            gutterBottom
                                            sx={{ fontWeight: 300 }}
                                        >
                                           $ {payment?.payment_fee}
                                        </Typography>
                                    </Grid>
                                </Grid>

                                <Grid lg={12} md={12} xs={12} sx={{ mb: 10 }}>
                                    <Divider />
                                </Grid>

                                <Grid
                                    container
                                    item
                                    xs={12}
                                    sx={{ mb: 5 }}
                                    direction="row"
                                    justifyContent="center"
                                    alignItems="center"
                                >
                                    <Button
                                        variant="contained"
                                        color="primary"
                                        type="submit"
                                        sx={{
                                            width: '35%',
                                            height: 60,
                                        }}
                                    >
                                        <Typography
                                            sx={{
                                                fontWeight: 'bold',
                                                fontSize: 20,
                                            }}
                                        >
                                            THANH TOÁN
                                        </Typography>
                                    </Button>
                                </Grid>
                            </Grid>
                        </CardContent>
                    </Card>
                </Card>
            </Container>
        </Box>
    );
};

export default AdminStudentProfile;
