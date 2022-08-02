import React, { useEffect, useState } from 'react';
import Sidebar from '../../../components/layout/sidebar/Sidebar';
import {
    FormControl,
    Input,
    InputLabel,
    Paper,
    MenuItem,
    Grid,
    Button,
    Typography,
    Select,
    TextareaAutosize,
    TextField,
    CircularProgress,
    Box,
} from '@mui/material';
import { useAdminEvents } from '../../../recoil/adminEvents';
import { useSnackbar } from '../../../HOCs';
import { useRecoilValue } from 'recoil';
import authAtom from '../../../recoil/auth/atom';
import { storage } from '../../../firebase';
import { DateTimePicker } from '@mui/x-date-pickers/DateTimePicker';
import { LocalizationProvider } from '@mui/x-date-pickers/LocalizationProvider';
import { AdapterDateFns } from '@mui/x-date-pickers/AdapterDateFns';
import { useParams } from 'react-router-dom';

const LoadingComponent = () => (
    <Box
      sx={{
        width: "100%",
        height: "100vh",
        display: "flex",
        justifyContent: "center",
        alignItems: "center",
      }}
    >
      <CircularProgress color="secondary" size={50} />
    </Box>
);

const UpdateEvent = () => {
    const { id } = useParams();
    const auth = useRecoilValue(authAtom);
    const [name, setName] = useState('');
    const [content, setContent] = useState('');
    const [eventStart, setEventStart] = useState(new Date('2022-07-19T15:00:00.000Z'));
    const [eventEnd, setEventEnd] = useState(new Date('2022-07-19T15:00:00.000Z'));
    const [eventStatus, setEventStatus] = useState(false);
    const [categoryID, setCategoryID] = useState('');
    const [locationID, setLocationID] = useState('');
    const [paymentFee, setFee] = useState('');
    const [paymentUrl, setPaymentUrl] = useState('');
    const [imageUrl, setImageUrl] = useState('');
    const [image, setImage] = useState('');
    const [loading, setLoading] = useState(false);
    const { getCategories, getLocations, updateEvent, getEventDetails } = useAdminEvents();

    const [locations, setLocation] = useState([]);
    const [categories, setCategory] = useState([]);

    const showSackbar = useSnackbar();

    const nameHandle = (event) => {
        setName(event.target.value);
    };

    const contentHandle = (event) => {
        setContent(event.target.value);
    };

    const eventStartHandle = (event) => {
        setEventStart(event);
    };

    const eventEndHandle = (event) => {
        setEventEnd(event);
    };

    const eventStatusHandle = (event) => {
        setEventStatus(event.target.value);
    };

    const locationHandle = (event) => {
        setLocationID(event.target.value);
    };

    const categoryHandle = (event) => {
        setCategoryID(event.target.value);
    };

    const FeeHandle = (event) => {
        setFee(event.target.value);
    };

    const paymentUrlHandle = (event) => {
        setPaymentUrl(event.target.value);
    };

    const imageHandle = (event) => {
        if (event.target.files[0]) {
            setImage(event.target.files[0]);
        }
    };

    const handleUpload = () => {
        const uploadTask = storage.ref(`images/${image.name}`).put(image);
        uploadTask.on(
            'state_changed',
            (snapshot) => {},
            (error) => {
                console.log(error);
            },
            () => {
                storage
                    .ref('images')
                    .child(image.name)
                    .getDownloadURL()
                    .then((url) => {
                        console.log(url);
                    });
            },
        );
    };

    console.log('images', image);

    function updatePost() {
        return updateEvent(
            id,
            name,
            content,
            eventStart,
            eventEnd,
            eventStatus,
            categoryID,
            locationID,
            auth.userId,
            paymentUrl,
            paymentFee,
            imageUrl
        )
            .then(() => {
                showSackbar({
                    severity: 'success',
                    children: 'Add sucessfully',
                });
            })
            .catch((error) => {
                console.log(error);
                showSackbar({
                    severity: 'error',
                    children: 'Something went wrong, please try again later.',
                });
            });
    }

    function getLocationlist() {
        return getLocations().then((resposne) => {
            const data = resposne.data.data;
            setLocation(data);
        });
    }

    function getCategorylist() {
        return getCategories().then((resposne) => {
            const data = resposne.data.data;
            setCategory(data);
        });
    }

    function getDetails() {
        setLoading(true)
        return getEventDetails(id).then((resposne) => {
            const data = resposne.data.data;
            console.log(data[0]);
            setName(data[0].event_name)
            setContent(data[0].event_content)
            setEventStart(data[0].event_start)
            setEventEnd(data[0].event_end)
            setEventStatus(data[0].event_status)
            setCategoryID(data[0].category_id)
            setLocationID(data[0].location_id)
            setFee(data[0].payment_fee)
            setPaymentUrl(data[0].payment_url)
            setImageUrl(data[0].image_url)
            setLoading(false)
        });
    }

    useEffect(() => {
        Promise.all([getLocationlist(), getCategorylist(), getDetails()]).catch(() => {
            showSackbar({
                severity: 'error',
                children: 'Something went wrong, please try again later.',
            });
        });
    }, []);

    if (loading) {
        return <LoadingComponent />;
    }
    return (
        <div className="flex">
            <Sidebar />
            <Grid
                container
                sx={{ maxWidth: 980 }}
                justify="center"
                alignContent="center"
            >
                <Grid item xs={6} md={4}>
                    <Paper
                        elevation={4}
                        style={{
                            padding: '20px 15px',
                            marginTop: '30px',
                            marginLeft: '150px',
                            minWidth: '680px',
                        }}
                    >
                        <Typography variant="headline" gutterBottom>
                            Sự kiện mới
                        </Typography>
                        <FormControl fullWidth margin="normal">
                            <InputLabel>Tên sự kiện *</InputLabel>
                            <Input
                                // label="Tên sự kiện"
                                name="eventname"
                                fullWidth
                                required
                                value={name}
                                onChange={nameHandle}
                            />
                        </FormControl>
                        <LocalizationProvider dateAdapter={AdapterDateFns}>
                            <FormControl fullWidth margin="normal">
                                {/* <InputLabel>Thời gian bắt đầu *</InputLabel>  */}
                                <DateTimePicker
                                    label="Thời gian bắt đầu *"
                                    ampm={false}
                                    name="eventstart"
                                    // type="datetime-local"
                                    value={eventStart}
                                    onChange={eventStartHandle}
                                    fullWidth
                                    required
                                    renderInput={(params) => (
                                        <TextField {...params} />
                                    )}
                                />
                            </FormControl>
                            <FormControl fullWidth margin="normal">
                                {/* <InputLabel>Thời gian kết thúc *</InputLabel> */}
                                <DateTimePicker
                                    label="Thời gian kết thúc *"
                                    ampm={false}
                                    name="eventend"
                                    // type="datetime-local"
                                    value={eventEnd}
                                    onChange={eventEndHandle}
                                    fullWidth
                                    required
                                    renderInput={(params) => (
                                        <TextField {...params} />
                                    )}
                                />
                            </FormControl>
                        </LocalizationProvider>
                        <FormControl fullWidth margin="normal">
                            <Select
                                defaultValue="false"
                                name="eventstatus"
                                onChange={eventStatusHandle}
                                value={eventStatus}
                                required
                            >
                                <MenuItem value="true">Online</MenuItem>
                                <MenuItem value="false">Offline</MenuItem>
                            </Select>
                        </FormControl>

                        <FormControl fullWidth margin="normal">
                            <InputLabel>Địa điểm tổ chức</InputLabel>
                            <Select
                                label="Địa điểm tổ chức"
                                displayEmpty
                                name="location"
                                onChange={locationHandle}
                                value={locationID}
                                required
                            >
                                {locations?.map((location) => (
                                    <MenuItem value={location.location_id}>
                                        {location.location_detail}
                                    </MenuItem>
                                ))}
                            </Select>
                        </FormControl>

                        <FormControl fullWidth margin="normal">
                            <InputLabel>Thể loại</InputLabel>
                            <Select
                                label="Thể loại"
                                displayEmpty
                                name="category"
                                onChange={categoryHandle}
                                value={categoryID}
                                required
                            >
                                {categories?.map((category) => (
                                    <MenuItem value={category.category_id}>
                                        {category.category_name}
                                    </MenuItem>
                                ))}
                            </Select>
                        </FormControl>

                        <FormControl fullWidth margin="normal">
                            <TextareaAutosize
                                name="eventcontent"
                                minRows={5}
                                placeholder="Nội dung sự kiện"
                                onChange={contentHandle}
                                value={content}
                                fullWidth
                                required
                            />
                        </FormControl>
                        <FormControl fullWidth margin="normal">
                            <InputLabel>Chi phí tham gia sự kiện </InputLabel>
                            <Input
                                name="paymentfee"
                                type="number"
                                value={paymentFee}
                                onChange={FeeHandle}
                                required
                                fullWidth
                            />
                        </FormControl>
                        {paymentFee !== 0 ? (
                            <FormControl fullWidth margin="normal">
                                <InputLabel>Link thanh toán (momo)</InputLabel>
                                <Input
                                    name="paymenturl"
                                    // type="url"
                                    value={paymentUrl}
                                    onChange={paymentUrlHandle}
                                    required
                                    fullWidth
                                />
                            </FormControl>
                        ) : (
                             <></>
                        )}

                        {/* <FormControl fullWidth margin="normal">
                            <Input
                                name="eventimage1"
                                type="file"
                                onChange={imageHandle}
                            />
                            <Button onClick={handleUpload}>Tải ảnh này</Button>
                        </FormControl> */}
                        <FormControl fullWidth margin="normal">
                            <Button
                                variant="extendedFab"
                                color="primary"
                                type="submit"
                                onClick={updatePost}
                            >
                                Cập nhật sự kiện
                            </Button>
                        </FormControl>
                    </Paper>
                </Grid>
            </Grid>
        </div>
    );
};
export default UpdateEvent;
