import {
    Alert, Stack, LinearProgress,
    Box, Button, Card,
    CardActions,
    CardContent, Dialog, DialogActions, DialogContent, DialogContentText, DialogTitle, Divider, Grid, Snackbar, TextareaAutosize, Typography
} from "@mui/material";
import { useState } from "react";
import axios from "axios";
import { Link as RouterLink } from "react-router-dom";



const EventDetailHeader = (props) => {
    const [load, setLoad] = useState(false);
    const { item } = props;
    const [open, setOpen] = useState(false);
    const [CV, setCV] = useState();
    const [message, setMessage] = useState("");
    const [messageApply, setMessageApply] = useState("");
    const [statusApply, setStatusApply] = useState(0);
    const [messageUploadCVSuccess, setMessageUploadCVSuccess] = useState("");
    const [experience, setExperience] = useState("");

    const [openModal, setOpenModal] = useState(false);
    const handleClickModal = () => {
        setOpenModal(true);
    };
    const handleCloseModal = (event, reason) => {
        if (reason === 'clickaway') {
            return;
        }

        setOpenModal(false);
    };

    // const [upload, setUpload] = useState(false);
    const [attachment, setAttachment] = useState([])
    // const axiosPrivate = useAxiosPrivate();

    const handleClose = (event, reason) => {
        setMessage("");
        setMessageUploadCVSuccess("");
        setAttachment([]);
        setCV();
        setExperience("");

        if (reason && reason === "backdropClick")
            return;
        setOpen(false);

    };
    
    const handleApply = (event, reason) => {
        if (attachment.length) {
            // apply();
            setMessage("");
            setMessageUploadCVSuccess("");
            setAttachment([]);
            setCV();
            setExperience("");
            // setMessageApply("");
            if (reason && reason === "backdropClick")
                return;
            setOpen(false);
        } else {
            setMessage("You haven't upload CV")
        }


    };
    // console.log(item?.company?.name);
    const handleCV = (e) => {
        const file = e.target.files[0];

        setCV(file);
        setMessage("");
        setMessageUploadCVSuccess("");
        console.log("CV", CV);
    }
    const handleUploadCV = () => {
        if (CV) {

            uploadCV();
        }
        else {
            setMessage("No file chosen")
        }
    }
    const uploadCV = async () => {
        // try {
        //     setMessage("");
        //     const formData = new FormData();
        //     formData.append("files", CV);
        //     const response = await axios.post("/storage", formData, {
        //         headers: {
        //             'Content-Type': 'multipart/form-data'
        //         }
        //     });
        //     setAttachment(response.data);
        //     setMessageUploadCVSuccess("Your CV is uploaded")
        // } catch (error) {
        //     console.log(error);
        // }
    }
    console.log("Attatchment: ", attachment);
    console.log("Experience: ", experience);
    return (
        <>
            <Card>
                <CardContent>
                    <Box
                        sx={{
                            display: "flex",
                            flexDirection: "row",
                        }}
                    >
                        <Grid>
                            <Typography color="textPrimary" gutterBottom variant="h2" sx={{ fontWeight: 'regular' }}>
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
                    <Button size="large" variant="contained" fullWidth
                        sx={{
                            marginBottom: "0.2%",
                            fontSize: "larger"
                        }}
                        component={RouterLink}
                        to={`/user/paymentpage/${item?.event_id}`}
                    >Join In now</Button>
                </CardActions>

                <Divider />

            </Card>

            <Dialog
                open={open}
                onClose={handleClose}
                disableEscapeKeyDown={false}
                fullWidth
                maxWidth="lg"
            >
                <DialogTitle>
                    <Typography color="textPrimary" gutterBottom variant="h3" sx={{ fontWeight: 'regular' }}>
                        {/* {item?.name} */}
                    </Typography>
                </DialogTitle>
                <DialogContent>
                    <Grid container spacing={1}>
                        <Grid item xs={2}>
                            <DialogContentText color="textPrimary">
                                Your Form
                            </DialogContentText>
                        </Grid>
                        <Grid item xs={3}>
                            <input type="file" onChange={handleCV} />
                        </Grid>
                        <Grid item xs={3}>
                            <Button
                                variant="contained"
                                size="small"
                                sx={{
                                    backgroundColor: "green",
                                    boxShadow: "none"
                                }}
                                onClick={handleUploadCV}
                            >Upload CV</Button>
                        </Grid>
                        <Grid item xs={3} marginLeft="-15%">
                            {message && <Typography color="error">{message}</Typography>}
                            {messageUploadCVSuccess && <Typography color="green">{messageUploadCVSuccess}</Typography>}
                        </Grid>

                    </Grid>
                    <br />
                    <Grid container spacing={0}>
                        <Grid item xs={2}>Your thinking</Grid>
                        <Grid item xs={9}>
                            <TextareaAutosize
                                minRows={5} style={{ width: "70%" }}
                                value={experience}
                                onChange={(e) => setExperience(e.target.value)}
                            />
                        </Grid>
                    </Grid>



                </DialogContent>
                <DialogActions sx={{ marginLeft: "30%" }}>
                    <Grid container>
                        <Grid item xs={2}>
                            <Button onClick={handleClose} sx={{ fontSize: "large" }}>Cancel</Button>
                        </Grid>
                        <Grid item xs={2}>
                            <Button onClick={handleApply} sx={{ fontSize: "large" }}>Apply</Button>
                        </Grid>
                    </Grid>
                </DialogActions>
            </Dialog>
            {load && <Stack direction="row" spacing={3} sx={{ marginLeft: "30%", marginTop: "3%" }}

            >
                <Typography marginTop={-1.2} sx={{ fontSize: "large" }}>
                    Apply is on proccessing. Wait a minute
                </Typography>
                <LinearProgress sx={{ width: "35%", margin: "0" }} />
            </Stack>
            }
            <Snackbar
                open={openModal} autoHideDuration={6000}
                onClose={handleCloseModal}
                anchorOrigin={{
                    vertical: 'top',
                    horizontal: 'center',
                }}
            >
                <Alert onClose={handleCloseModal}
                    severity={
                        statusApply === 0 ? "success" : "error"
                    }
                    sx={{
                        width: '200%',
                        backgroundColor: statusApply === 0 ? "green" : "red",
                        color: "white"
                    }}>
                    {messageApply}
                </Alert>
            </Snackbar>

        </>
    );
};


export default EventDetailHeader;