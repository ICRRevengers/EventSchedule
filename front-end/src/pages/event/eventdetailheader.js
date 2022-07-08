import {
    Box,
    Button,
    Card,
    CardActions,
    CardContent, Dialog, DialogActions, DialogTitle, Divider,
    Grid, Modal, Typography
} from '@mui/material';
import { useState } from 'react';
import { useHistory } from 'react-router-dom';

const EventDetailHeader = (props) => {
    const history = useHistory();
    const { item } = props;
    const [openPopup, setOpenPopup] = useState(false);

    const handleClose = () => setOpenPopup(false);

    const joinHandler = () => {
        if (item.payment_fee === 0) {
            setOpenPopup(true);
        } else {
            history.push(`/user/paymentpage/${item?.event_id}`);
        }
    };

    return (
        <>
            <Card>
                <CardContent>
                    <Box
                        sx={{
                            display: 'flex',
                            flexDirection: 'row',
                        }}
                    >
                        <Grid>
                            <Typography
                                color="textPrimary"
                                gutterBottom
                                variant="h2"
                                sx={{ fontWeight: 'regular' }}
                            >
                                {item?.event_name}
                            </Typography>
                            <Grid container spacing={1}>
                                <Grid item xs={10}>
                                    <Typography color="textPrimary"
                                        gutterBottom variant="h5" sx={{ fontWeight: 'normal' }}>
                                        Ngày bắt đầu: {item?.event_start}
                                    </Typography>
                                </Grid>
                                <Grid item xs={10}>
                                    <Typography color="textPrimary"
                                        gutterBottom variant="h5" sx={{ fontWeight: 'normal' }}>
                                        Ngày kết thúc: {item?.event_end}
                                    </Typography>
                                </Grid>
                                <Grid item xs={5}>
                                    <Typography color="textPrimary"
                                        gutterBottom variant="h5" sx={{ fontWeight: 'normal' }}>
                                        Địa điểm: {item?.location_detail}
                                    </Typography>
                                </Grid>
                                <Grid item xs={5}>
                                    <Typography color="textPrimary"
                                        gutterBottom variant="h5" sx={{ fontWeight: 'normal' }}>
                                        Host Club: {item?.admin_name}
                                    </Typography>
                                </Grid>
                                <Grid item xs={5}>
                                    <Typography color="textPrimary"
                                        gutterBottom variant="h5" sx={{ fontWeight: 'normal' }}>
                                        Thể loại: {item?.category_name}
                                    </Typography>
                                </Grid>
                                 <Grid item xs={7}>
                                    <Typography color="textPrimary" gutterBottom variant="h5" sx={{ fontWeight: 'normal' }}>
                                        Giá vé: {item?.payment_fee}₫
                                    </Typography>
                                </Grid>
                            </Grid>
                            <Typography color="textSecondary" gutterBottom variant="body1">
                                Status: {item.event_status ? 'Online' : 'Offline' }
                            </Typography>
                        </Grid>
                    </Box>
                </CardContent>
                <CardActions>
                    <Button
                        size="large"
                        variant="contained"
                        fullWidth
                        sx={{
                            marginBottom: '0.2%',
                            fontSize: 'larger',
                        }}
                        onClick={joinHandler}
                    >
                        Join In now
                    </Button>
                </CardActions>

                <Divider />
            </Card>
            {openPopup && (
                <Dialog
                    open={openPopup}
                    onClose={handleClose}
                    aria-labelledby="modal-modal-title"
                    aria-describedby="modal-modal-description"
                >
                    <DialogTitle>
                        {"Bấm xác nhận để chấp nhận tham gia sự kiện nhé!"}
                    </DialogTitle>
                    <DialogActions>
                        <Button onClick={handleClose}>Thoát</Button>
                        <Button onClick={handleClose} autoFocus>
                            Xác nhận
                        </Button>
                    </DialogActions>
                </Dialog>
            )}
        </>
    );
};

export default EventDetailHeader;
