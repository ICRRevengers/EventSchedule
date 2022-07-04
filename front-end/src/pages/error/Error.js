import { Link } from "react-router-dom";

const Error = () => (
    <>
        <div className="h-[100vh] ">
            <h1 className="text-[#f24405] font-bold text-[100px] text-center">404</h1>
            <div className=" text-[30px] font-[1000] text-center">
                Không tìm thấy nội dung
            </div>
            <h3 className="text-center">URL của nội dung này đã bị thay đổi hoặc không còn tồn tại.<br /> Nếu bạn đang lưu URL này hãy thử truy cập lại từ trang chủ thay vì dùng URL đã lưu</h3>
            <div className="bg-[#f24405] mx-auto w-[200px] text-center mt-[20px] text-white rounded-full border p-[10px]"> <Link to='/'>Truy cập trang chủ</Link></div>
        </div>
        
    </>

);

export default Error;
