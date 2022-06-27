import { AiOutlineMail, AiOutlineHome } from 'react-icons/ai';
import { Link } from 'react-router-dom';
import Wrapper from '../wrapper/Wrapper';

const titles1 = [
    {
        title: 'FPT Event Schedule',
        href: '/',
    },
    {
        title: 'Về chúng tôi',
        href: '/aboutus',
    },
    {
        title: 'Liên hệ',
        href: '/contactus',
    },
];

const titles2 = [
    {
        title: 'daihoc.hcm@fpt.edu.vn',
        icon: <AiOutlineMail className="h-[16px] w-[16px]" />,
        href: '#',
    },
    {
        title: (
            <span>
                E2A-7, Đường D1, Khu Công Nghệ Cao,
                Phường Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh
            </span>
        ),
        icon: <AiOutlineHome className="min-h-[16px] min-w-[16px]" />,
        href: '#',
    },
];
const title3 = [
    {
        title: (
            <span>
                FESC - FPT Event Schedule là trang web giúp bạn tìm hiểu sự kiện sắp diễn ra.
                Đồng thời bạn có thể dễ dàng xem lại sự kiện đã được tổ chức trong quá khứ.
            </span>
        ),
        href: '#',
    },
];

const Footer = ({ children }) => {
    return (
        <>
            <Wrapper className=" bg-[#f24405]" content="p-[20px]">
                <div className="flex grow text-[#fff] mt-[15px] justify-between flex-col  md:flex-row">
                    <div className="text-[14px] flex flex-col ">
                        {titles1.map((title1, index) => (
                            <Link
                                className="mb-[10px]"
                                to={title1.href}
                                key={index}
                            >
                                {title1.title}
                            </Link>
                        ))}
                    </div>
                    <div className="text-[14px] flex flex-col max-w-[500px]">
                        {titles2.map((title2, index) => (
                            <span
                                className="mb-[10px] flex items-center "
                                to={title2.href}
                                key={index}
                            >
                                {title2.icon} &ensp;{title2.title}
                            </span>
                        ))}
                    </div>
                    <div className="text-[14px] flex flex-col max-w-[500px]">
                        {title3.map((title3, index) => (
                            <Link
                                className="mb-[10px]"
                                to={title3.href}
                                key={index}
                            >
                                {title3.title}
                            </Link>
                        ))}
                    </div>
                </div>
            </Wrapper>
            {children}
        </>
    );
};

export default Footer;
