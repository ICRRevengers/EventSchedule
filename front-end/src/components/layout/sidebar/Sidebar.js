import Wrapper from '../defaultLayout/wrapper/Wrapper';
import { Link } from 'react-router-dom';

const pages = [
    {
        title: 'Danh sách sự kiện',
        href: '/manage/events',
    },
    {
        title: 'Đăng sự kiện mới',
        href: '/manage/postevent',
    },
    {
        title: 'Hồ sơ',
        href: '/manage/profile',
    },
];

const Sidebar = () => {
    return (
        <>
            <Wrapper
                className="bg-[#000050] h-[auto] min-h-[100vh] w-[300px] text-[#fff]"
                content="p-[20px]"
            ></Wrapper>
            <div className="fixed text-[#fff] w-[300px]   mx-[auto]   p-[20px]">
                <div className="font-bold text-[20px] text-center mb-[20px]">
                    Dành cho quản trị viên
                </div>
                {pages.map((page) =>  {
                    return (
                        <Link to={page.href} >
                        <h1 className="border-b border-[#ffffff86] mb-[10px] p-[10px]">{page.title}</h1>
                        </Link>
                    )})}
                
            </div>
        </>
    );
};

export default Sidebar;
