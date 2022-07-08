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
import { useAdminInfo } from '../../../recoil/adminInfo';
import { useSnackbar } from '../../../HOCs';
import { useEffect } from 'react';
import authAtom from '../../../recoil/auth/atom';
import { useSetRecoilState } from 'recoil';

const AdminProfile = () => {

    const setAuth = useSetRecoilState(authAtom);
    const [name, setName] = useState('');
    const [phone, setPhone] = useState('');
    const [adminPassword, setPassword] = useState('');
    const { updateInfo, getInfo } = useAdminInfo();

    const [admins, setAdmin] = useState();

    const showSackbar = useSnackbar();

    const nameHandle = (event) => {
        setName(event.target.value);
    };

    const phoneHandle = (event) => {
        setPhone(event.target.value);
    };

    const passwordHandle = (event) => {
        setPassword(event.target.value);
    };

    // function updateAdmin() {
    //     updateInfo(id, name, phone, adminPassword )
    //         .then((resposne) => {
    //             showSackbar({
    //                 severity: 'error',
    //                 children: resposne.data,
    //             });
    //         })
    //         .catch((error) => {
    //             showSackbar({
    //                 severity: 'error',
    //                 children: 'Something went wrong, please try again later.',
    //             });
    //         });
    // }

    // useEffect(() => {
    //     getInfo()
    //         .then((resposne) => {
    //             const data = resposne.data.data;
    //             setAdmin(data);
    //         })
    //         .catch(() => {
    //             showSackbar({
    //                 severity: 'error',
    //                 children: 'Something went wrong, please try again later.',
    //             });
    //         });
    // }, []);

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
                            Hồ sơ của bạn
                        </Typography>
                        <FormControl fullWidth margin="normal">
                            <InputLabel>Tên</InputLabel>
                            <Input
                                name="adminName"
                                fullWidth
                                required
                                value={name}
                                onChange={nameHandle}
                            />
                        </FormControl>
                        <FormControl fullWidth margin="normal">
                            <InputLabel>Số điện thoại</InputLabel>
                            <Input
                                name="adminPhone"
                                type="tel"
                                fullWidth
                                required
                                value={phone}
                                onChange={phoneHandle}
                            />
                        </FormControl>
                        <FormControl fullWidth margin="normal">
                            <InputLabel>Mật khẩu</InputLabel>
                            <Input
                                type='password'
                                name="adminPassword"
                                fullWidth
                                required
                                value={adminPassword}
                                onChange={passwordHandle}
                            />
                        </FormControl>

                        <FormControl fullWidth margin="normal">
                            <Button
                                variant="extendedFab"
                                color="primary"
                                type="submit"
                                // onClick={updateAdmin}
                            >
                                Cập nhật
                            </Button>
                        </FormControl>
                    </Paper>
                </Grid>
            </Grid>
        </div>
    );
};
export default AdminProfile;
