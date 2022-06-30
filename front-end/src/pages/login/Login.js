import axios from 'axios';
import { useState } from 'react';
import GoogleButton from 'react-google-button';
import '../../App.scss';
import { useNavigate } from 'react-router-dom';

function Login() {
    const navigate = useNavigate();
    const [adminUserName, setAdminUserName] = useState('');
    const [adminPassword, setAdminPassword] = useState('');
    const [error, setError] = useState({
        username: null,
        password: null,
    });

    const loginGoogle = () => {
        window.location.assign(
            'http://localhost:5000/api/Authentication/google-login',
        );
    };

    const loginAdmin = (event) => {
        event.preventDefault();
        axios
            .get(
                `http://localhost:5000/api/Admin/login-admin?clubName=${adminUserName}&clubPassword=${adminPassword}`,
            )
            .then((res) => {
                navigate('/manage/events')
            })
            .catch((error) => {
                console.log(error.response.data);
            });
    };

    const userNameHandler = (event) => {
        setAdminUserName(event.target.value);
    };

    const passwordHandler = (event) => {
        setAdminPassword(event.target.value);
    };

    return (
        <>
            <div className="login ">
                <form className="admin-form" onSubmit={loginAdmin}>
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
        </>
    );
}

export default Login;
