import React, { Component } from 'react';
import {
  Navbar,
  NavbarBrand
}
  from 'reactstrap';

import { NavLink } from 'react-router-dom';

class Header extends Component {
  constructor(props) {
    super(props);
  }

  render() {
    
    return (
      <React.Fragment>
        <Navbar className='md'>
          <div className="container">
            <NavbarBrand className='navbar-brand mr-auto' href="/home">
              <span><img src='favicon.ico' width='40px' alt='FESC' /></span> FPT Event Schedule
            </NavbarBrand>
            <div className='row ml-0 lr-0'>
              <NavLink className="nav-link navbar-content" to='/home'>Trang chủ</NavLink>
              <NavLink className="nav-link navbar-content" to='/aboutus'>Về chúng tôi</NavLink>
              <NavLink className="nav-link navbar-content" to='/contactus'>Liên hệ</NavLink>
              <NavLink className="nav-link navbar-content" to='/login'>Đăng nhập</NavLink>
            </div>
          </div>
        </Navbar>
      </React.Fragment>
    );
  }
}

export default Header;
