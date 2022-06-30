import Sidebar from '../../../components/layout/sidebar/Sidebar';
import Button from '../../../components/button/Button';
import { Table } from 'reactstrap';
import '../../../App.scss'
import { useEffect, useState } from "react";
import axios from "axios";
import { Link } from 'react-router-dom';
const ManagerEvents = () => {
    const [event, setEvent] = useState();

    useEffect(() => {
        let isMounted = true;
        const controller = new AbortController();
        
        const getEvents = async () => {
          try {
            const response = await axios.get("http://localhost:5000/api/Event/get-event-list", {
              signal: controller.signal,
              
            });
            console.log("events: ", response.data);
            if (isMounted) {
                setEvent(response.data);
              
            }
          } catch (error) {
            console.error(error);
            // if (!error?.response) {
            //   alert('No Server Response');
    
            // } else {
            //   alert('Load List Failed. Please refresh page!')
            // }
          }
        };
        getEvents();
    
        return () => {
          isMounted = false;
          controller.abort();
        };
      }, []);
    return(
    <div className="flex">
        <Sidebar />
        <Table className='m-[20px] w-[900px]'>
                <thead>
                    <tr>
                        <th>Mã số</th>
                        <th>Tên sự kiện</th>
                        <th>Người tham gia</th>
                        <th>Chi tiết sự kiện</th>
                        <th>Cập nhật</th>
                        <th>Xóa sự kiện</th>
                    </tr>
                </thead>
                <tbody>    
                    {event?.map((eve) => (
                        <tr className='hover:bg-[#f99779]'>
                            <td>{eve?.event_id}</td>
                            <td>{eve?.event_name}</td>
                            <td><Link to={`/manage/participated/${eve.event_id}`} >Danh sách</Link></td>
                            <td><Button href='/management/eventdetail'>Xem</Button></td>
                            <td><Button href='/manage/update'>Cập nhật</Button></td>
                            <td><Button>Xóa</Button></td>
                        </tr>                     
                    ))}
                    
                </tbody>
            </Table>
    </div>
    )
};

export default ManagerEvents;
