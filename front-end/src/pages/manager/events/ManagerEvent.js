import Sidebar from '../../../components/layout/sidebar/Sidebar';
import Button from '../../../components/button/Button';
import myevents from '../data/data';
import { Table } from 'reactstrap';
import '../../../App.scss'

const ManagerEvents = () => (
    <div className="flex">
        <Sidebar />
        <Table className='m-[20px] w-[900px]'>
                <thead>
                    <tr>
                        <th>Tên sự kiện</th>
                        <th>Người tham gia</th>
                        <th>Chi tiết sự kiện</th>
                        <th>Cập nhật</th>
                        <th>Xóa sự kiện</th>
                    </tr>
                </thead>
                <tbody>
                    {myevents.map((item) => {
                        return (
                            <tr className='hover:bg-[#f99779]'>
                                <td>{item.Title}</td>
                                <td><Button href='/manage/participated'>Danh sách</Button></td>
                                <td><Button href='/management/eventdetail'>Xem</Button></td>
                                <td><Button href='/manage/update'>Cập nhật</Button></td>
                                <td><Button>Xóa</Button></td>
                            </tr>
                        )
                    })}
                </tbody>
            </Table>
    </div>
);

export default ManagerEvents;
