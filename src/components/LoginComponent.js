import GoogleButton from 'react-google-button'

function Login() {
    return (
        <>
            <div className="login row mr-0 ml-0 ">
                <form className="col-12 col-md-6 text-center">
                    <p className="col-12">Nếu bạn là <strong>quản trị viên</strong>, đăng nhập ở đây</p>
                    <div className="form-group row">
                        <div className="form-group col-12 col-md-6 offset-md-3">
                            <input type="email" className="form-control" id="inputAccount"
                                placeholder="Tài khoản" />
                        </div>
                        <div className="form-group col-12 col-md-6 offset-md-3">
                            <input type="password" className="form-control" id="inputPassword"
                                placeholder="Mật khẩu" />
                        </div>
                    </div>
                </form>
                <div className="col-12 col-md-6 text-center">
                    <p className="col-12 pl-0">Nếu bạn là <strong>sinh viên</strong>, đăng nhập với fpt.edu.vn</p>
                    <GoogleButton className="googleButton offset-2 offset-md-3"
                        onClick={() => { console.log('Google button clicked') }}
                    />
                </div>
            </div>
        </>
    )
}

export default Login;