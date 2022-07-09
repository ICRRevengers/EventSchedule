import Wrapper from '../defaultLayout/wrapper/Wrapper';
import { Link } from 'react-router-dom';
import authAtom from '../../../recoil/auth/atom';
import { useRecoilValue } from 'recoil';

const Sidebar = () => {
    const auth = useRecoilValue(authAtom);
    return (
        <>
            <Wrapper
                className="bg-[#779ECC] h-[auto] min-h-[100vh] w-[300px] text-[#fff]"
                content="p-[20px]"
            ></Wrapper>
            <div className="fixed text-[#fff] w-[300px] mx-[auto] p-[20px]">
                <div className="font-bold text-[20px] text-center mb-[20px]">
                    Dành cho quản trị viên
                </div>
                <Link to={`/admin/manage/events`}>
                    <h1 className="border-b border-[#ffffff86] mb-[10px] p-[10px]">
                        Danh sách sự kiện
                    </h1>
                </Link>
                <Link to={`/admin/manage/postevent`}>
                    <h1 className="border-b border-[#ffffff86] mb-[10px] p-[10px]">
                        Đăng sự kiện mới
                    </h1>
                </Link>
                <Link to={`/admin/manage/profile/${auth.userId}`}>
                    <h1 className="border-b border-[#ffffff86] mb-[10px] p-[10px]">
                        Hồ sơ
                    </h1>
                </Link>
                {auth.role === 'admin' ? (
                    <>
                        <Link to={`/admin/manage/club`}>
                            <h1 className="border-b border-[#ffffff86] mb-[10px] p-[10px]">
                                Quản lý câu lạc bộ
                            </h1>
                        </Link>
                        <Link to={`/admin/manage/add-new-admin`}>
                            <h1 className="border-b border-[#ffffff86] mb-[10px] p-[10px]">
                                Tạo tài khoản mới
                            </h1>
                        </Link>
                    </>
                ) : (
                    <></>
                )}
            </div>
        </>
    );
};

export default Sidebar;
