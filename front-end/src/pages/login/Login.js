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


function Login() {
    const { search } = useLocation();
    const showSnackbar = useSnackbar();
    const { token, error } = queryString.parse(search);
    const { login} = useAuthActions();

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
        window.location.assign(`${APP_API_URL}/api/Authentication/google-login`);
    };

    const adminLogin = (event) => {
        console.log(adminUserName, adminPassword);
        event.preventDefault()
        axios({
            url:`${APP_API_URL}/api/Admin/login-admin`,
            method:'post',
            data: {
                adminMail: adminUserName,
                adminPassword: adminPassword,
            },
        }).then(res => {
            login(res.data.data)
        }).catch(error => {
            showSnackbar({
                severity: 'error',
                children: error.response.data.message,
            });
        })
    }

    const userNameHandler = (event) => {
        setAdminUserName(event.target.value);
    };

    const passwordHandler = (event) => {
        setAdminPassword(event.target.value);
    };

    return (
        <HeaderFooter>
            <div className="login ">
                <form className="admin-form" onSubmit={adminLogin}>
                    <p className="">
                        Nếu bạn là <strong>quản trị viên</strong>, đăng nhập ở
                        đây
                    </p>
                    <div className="">
                        <div className="form-row">
                            <input
                                // type="email"
                                className="form-input"
                                id="inputAccount"
                                onChange={userNameHandler}
                                placeholder="Tài khoản"
                            />
                        </div>
                        <div className="form-row">
                            <input
                                type="password"
                                className="form-input"
                                id="inputPassword"
                                onChange={passwordHandler}
                                placeholder="Mật khẩu"
                            />
                        </div>
                        <div className="form-row">
                            <button className="form-submit" type="submit">
                                Đăng nhập
                            </button>
                        </div>
                    </div>
                </form>
                <div className="student-form">
                    <p className="">
                        Nếu bạn là <strong>sinh viên</strong>, đăng nhập với
                        fpt.edu.vn
                    </p>
                    <GoogleButton
                        className="googleButton"
                        onClick={loginGoogle}
                    />
                </div>
            </div>
        </HeaderFooter>
    );
}

export default Login;
