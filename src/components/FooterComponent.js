import React from 'react';
import { Nav } from 'reactstrap';
import { Link } from 'react-router-dom';

function Footer(props) {
    return (
        <footer className="footer">
            <div className="row mr-0 ml-0">
                    <div className="col-12">
                        <ul className='row mr-0 ml-0 pl-1 text-justify'>
                            <li className='col-5 col-md-6'>FESC - FPT Event Schedule là trang web giúp bạn tìm hiểu sự kiện sắp diễn ra.<br />
                                Đồng thời bạn có thể dễ dàng xem lại sự kiện đã được tổ chức trong quá khứ.</li>
                            <li className='col-7 col-md-6'>
                                <address className='pr-3'>
                                    E2A-7, Đường D1, Khu Công Nghệ Cao, <br />
                                    Phường Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh <br />
                                    <i className="fa fa-envelope fa-lg"></i> :
                                    <a href="mailto:daihoc.hcm@fpt.edu.vn">daihoc.hcm@fpt.edu.vn</a>
                                </address>
                            </li>
                        </ul>
                    </div>
            </div>
            <Nav className='linkpage'>
                <li><Link to='/home'>Trang chủ |</Link></li>
                <li><Link to='/aboutus'>Về chúng tôi |</Link></li>
                <li><Link to='/contactus'>Liên hệ</Link></li>
            </Nav>
        </footer>
    );
}
export default Footer;