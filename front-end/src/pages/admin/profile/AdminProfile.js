import { useEffect, useState } from 'react';
import {
    Button, FormControl, Grid, Input,
    InputLabel,
    Paper, Typography
} from '@mui/material';
import React from "react";
import Sidebar from '../../../components/layout/sidebar/Sidebar';
import { useAdminInfo } from '../../../recoil/adminInfo';
import { useSnackbar } from '../../../HOCs';
import { useRecoilValue } from 'recoil';
import authAtom from '../../../recoil/auth/atom';

const AdminProfile = () => {
    const showSackbar = useSnackbar();
    const { getAdmin, updateProfile } = useAdminInfo();
    const auth = useRecoilValue(authAtom);
    const [name, setName] = useState('');
    const [phone, setPhone] = useState('');
    const [adminPassword, setPassword] = useState('');

    const nameHandle = (event) => {
        setName(event.target.value);
    };

    const phoneHandle = (event) => {
        setPhone(event.target.value);
    };

    const passwordHandle = (event) => {
        setPassword(event.target.value);
    };

    useEffect(() => {
        getAdmin(auth.userId)
            .then((resposne) => {
                const data = resposne.data.data;
                console.log(data);
                setName(data[0].admin_name)
                setPhone(data[0].admin_phone)
            })
            .catch(() => {
                showSackbar({
                    severity: 'error',
                    children: 'Something went wrong, please try again later.',
                });
            });
    }, []);

    function updateAdmin() {
        updateProfile(auth.userId, name, phone, adminPassword )
            .then((resposne) => {
                showSackbar({
                    severity: 'success',
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
                                onClick={updateAdmin}
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
