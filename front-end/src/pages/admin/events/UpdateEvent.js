import React from "react";
import Wrapper from "../../../components/layout/defaultLayout/wrapper/Wrapper";
import Sidebar from "../../../components/layout/sidebar/Sidebar";

const UpdateEvent = () => {

    return (
        <div className="flex">
            <Sidebar />
            <Wrapper>
                <form className='Create-event max-w-[700px]' method='post' >
                    <div className='form-row' >
                        <label className="form-label ">Tên sự kiện</label>
                        <input className='form-input' type="text" name="event_name" />
                    </div>
                    <div className='form-row' >
                        <label className="form-label">Thời gian diễn ra sự kiện</label>
                        <input className="form-input" type="datetime-local" name="event_time"/>
                    </div>
                    <div className='form-row' >
                        <label className="form-label">Trạng thái</label>
                        <select className="form-input" name="event_status" required>
                            <option value="true">Online</option>
                            <option value="false">Offline</option>
                        </select>
                    </div>
                    <div className='form-row' >
                        <label className="form-label">Địa điểm tổ chức</label>
                        <select className="form-input" name="event_location" required>
                            <option value="HTA">Hội trường A</option>
                            <option value="HTB">Hội trường B</option>
                        </select>
                    </div>
                    <div className='form-row' >
                        <label className="form-label">Thể loại sự kiện</label>
                        <select className="form-input" name="event_category" required>
                            <option value="Music">Âm nhạc</option>
                            <option value="Art">Hội họa</option>
                        </select>
                    </div>
                    <div className='form-row' >
                        <label className="form-label">Link thanh toán (Momo)</label>
                        <input className="form-input" type="url" name="event_payment" required />
                    </div>
                    <div className='form-row' >
                        <label className='form-label'>Nội dung/Thông tin sự kiện</label>
                        <textarea className='form-input h-[200px]' name="message" required />
                    </div>
                    <div className='form-row' >
                        <input className="form-submit bg-[#000050]" type="submit" value='Cập nhật' />
                    </div>
                </form>
            </Wrapper>
        </div>
    )
}
export default UpdateEvent;