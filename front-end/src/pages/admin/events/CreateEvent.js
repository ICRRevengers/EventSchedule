import React, { useState } from 'react';
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
} from '@mui/material';
import { useAdminEvents } from '../../../recoil/adminEvents';
import { useSnackbar } from '../../../HOCs';

const Create = () => {
    const today = new Date(),
        date =
            today.getFullYear() +
            '-' +
            (today.getMonth() + 1) +
            '-' +
            today.getDate();

    const [name, setName] = useState('');
    const [content, setContent] = useState('');
    const [eventStart, setEventStart] = useState('2022-01-01T10:30');
    const [eventEnd, setEventEnd] = useState('2022-01-01T10:30');
    const [eventStatus, setEventStatus] = useState(false);
    const { createEvent } = useAdminEvents();

    const showSackbar = useSnackbar();

    const nameHandle = (event) => {
        setName(event.target.value);
    };

    const contentHandle = (event) => {
        setContent(event.target.value);
    };

    const eventStartHandle = (event) => {
        setEventStart(event.target.value);
    };

    const eventEndHandle = (event) => {
        setEventEnd(event.target.value);
    };

    const eventStatusHandle = (event) => {
        setEventStatus(event.target.value);
    };

    function createNew() {
        createEvent(name, content, eventStart, eventEnd, eventStatus)
            .then((resposne) => {
                showSackbar({
                    severity: 'error',
                    children: resposne.data,
                });
            })
            .catch((error) => {
                showSackbar({
                    severity: 'error',
                    children: 'Something went wrong, please try again later.',
                });
            });
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
                                name="eventname"
                                fullWidth
                                required
                                value={name}
                                onChange={nameHandle}
                            />
                        </FormControl>
                        <FormControl fullWidth margin="normal">
                            <InputLabel>Thời gian bắt đầu *</InputLabel>
                            <Input
                                name="eventstart"
                                type="datetime-local"
                                value={eventStart}
                                onChange={eventStartHandle}
                                fullWidth
                                required
                            />
                        </FormControl>
                        <FormControl fullWidth margin="normal">
                            <InputLabel>Thời gian kết thúc *</InputLabel>
                            <Input
                                name="eventstart"
                                type="datetime-local"
                                onChange={eventEndHandle}
                                value={eventEnd}
                                fullWidth
                                required
                            />
                        </FormControl>
                        <FormControl fullWidth margin="normal">
                            <Select
                                defaultValue="false"
                                name="eventstatus"
                                onChange={eventStatusHandle}
                                value={eventStatus}
                            >
                                <MenuItem value="true">Online</MenuItem>
                                <MenuItem value="false">Offline</MenuItem>
                            </Select>
                        </FormControl>
                        <FormControl fullWidth margin="normal">
                            <InputLabel>Địa điểm tổ chức</InputLabel>
                            <Select displayEmpty name="location">
                                <MenuItem value="HTA">Hội trường A</MenuItem>
                                <MenuItem value="advance">Advance</MenuItem>
                                <MenuItem value="enterprise">
                                    Enterprise
                                </MenuItem>
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
                            <InputLabel>Link thanh toán (momo)</InputLabel>
                            <Input name="paymenturl" fullWidth />
                        </FormControl>
                        <FormControl fullWidth margin="normal">
                            <Input name="eventimage1" type="file" />
                            <Input name="eventimage2" type="file" />
                            <Input name="eventimage3" type="file" />
                            <Input name="eventimage4" type="file" />
                            <Input name="eventimage5" type="file" />
                        </FormControl>
                        <FormControl fullWidth margin="normal">
                            <Button
                                variant="extendedFab"
                                color="primary"
                                type="submit"
                                onClick={createNew}
                            >
                                Đăng bài
                            </Button>
                        </FormControl>
                    </Paper>
                </Grid>
            </Grid>
        </div>
    );
};
export default Create;
