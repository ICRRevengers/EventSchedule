import React, { Component } from "react";
import GoogleButton from 'react-google-button'

class Login extends Component {
    render() {
        return (
            <>
                <div className="login row mr-0 ml-0 ">
                    <form className="col-12 col-md-6 text-center">
                        <p className="col-12">If you are <strong>club's admin</strong>, login here</p>
                        <div className="form-group row">
                            <div className="form-group col-12 col-md-6 offset-md-3">
                                <label className="sr-only" htmlFor="inputEmail">Admin account</label>
                                <input type="email" className="form-control" id="inputAccount"
                                    placeholder="Admin account" />
                            </div>
                            <div className="form-group col-12 col-md-6 offset-md-3">
                                <label className="sr-only" htmlFor="inputPassword">Password</label>
                                <input type="password" className="form-control" id="inputPassword"
                                    placeholder="Password" />
                            </div>
                        </div>
                    </form>
                    <div className="col-12 col-md-6 text-center">
                        <p className="col-12 pl-0">If you are <strong>student</strong>, login with fpt.edu.vn</p>
                        <GoogleButton className="googleButton offset-2 offset-md-3"
                            onClick={() => { console.log('Google button clicked') }}
                        />
                    </div>
                </div>
            </>
        )
    }
}

export default Login;