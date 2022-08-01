import axios from 'axios';
import { useState, useEffect } from 'react';
import GoogleButton from 'react-google-button';
import '../../App.scss';
import { APP_API_URL } from '../../config';
import { useLocation } from 'react-router-dom';
import queryString from 'query-string';
import { useSnackbar } from '../../HOCs';
import { useAuthActions } from '../../recoil/auth';
import HeaderFooter from '../../components/layout/defaultLayout/header-footer/HeaderFooter';
import { Stack, Button, TextField, FormLabel } from '@mui/material';
import { margin } from '@mui/system';

function Login() {
    const { search } = useLocation();
    const showSnackbar = useSnackbar();
    const { token, error } = queryString.parse(search);
    const { login } = useAuthActions();

    const [adminUserName, setAdminUserName] = useState('');
    const [adminPassword, setAdminPassword] = useState('');

    useEffect(() => {
        if (error && error === 'fpt-invalid-email') {
            showSnackbar({
                severity: 'error',
                children: 'Your email is not allowed to access.',
            });
        } else if (error) {
            showSnackbar({
                severity: 'error',
                children: 'Something went wrong, please try again later.',
            });
        } else if (token) {
            login(token);
        }
    }, []);

    const loginGoogle = () => {
        window.location.assign(
            `${APP_API_URL}/api/Authentication/google-login`,
        );
    };

    const adminLogin = (event) => {
        event.preventDefault();
        axios({
            url: `${APP_API_URL}/api/Admin/login-admin`,
            method: 'post',
            data: {
                adminMail: adminUserName,
                adminPassword: adminPassword,
            },
        })
            .then((res) => {
                login(res.data.data);
            })
            .catch((error) => {
                showSnackbar({
                    severity: 'error',
                    children: error.response.data.message,
                });
            });
    };

    const userNameHandle = (event) => {
        setAdminUserName(event.target.value);
    };

    const passwordHandle = (event) => {
        setAdminPassword(event.target.value);
    };

    return (
        <HeaderFooter>
            <Stack
                component="form"
                sx={{
                    width: '370px',
                    alignItems: 'center',
                    justifyContent: 'center',
                    margin: '0 auto',
                    paddingTop: '20px',
                }}
                spacing={2}
            >
                <p>
                    Nếu bạn là <b>quản trị viên</b>, đăng nhập tại đây
                </p>
                <TextField
                    id="outlined-email-input"
                    label="Tài khoản"
                    type="email"
                    onChange={userNameHandle}
                    required
                    fullWidth
                />
                <TextField
                    id="outlined-password-input"
                    label="Mật khẩu"
                    type="password"
                    autoComplete="current-password"
                    onChange={passwordHandle}
                    required
                    fullWidth
                />
                <Button variant="contained" onClick={adminLogin}>
                    {' '}
                    Đăng nhập{' '}
                </Button>
                
            </Stack>
            <Stack
                component="form"
                sx={{
                    width: '400px',
                    alignItems: 'center',
                    justifyContent: 'center',
                    margin: '0 auto',
                    padding: '35px 0',
                }}
                spacing={2}
            >
                <p>
                    Nếu bạn là <strong>sinh viên</strong>,
                    đăng nhập với fpt.edu.vn
                </p>
                <GoogleButton className="googleButton" onClick={loginGoogle} />
            </Stack>
        </HeaderFooter>
    );
}

export default Login;
