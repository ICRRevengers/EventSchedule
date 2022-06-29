import Sidebar from '../../../components/layout/sidebar/Sidebar';
import Button from '../../../components/button/Button';
import myevents from '../data/data';
import { Table } from 'reactstrap';
import '../../../App.scss'

const ParticipatedList = () => (
    <div className="flex">
        <Sidebar />
        <Table className='m-[20px] w-[900px]'>
                <thead>
                    <tr>
                        <th>Tên sinh viên</th>
                        <th>Ngày đăng kí</th>
                        <th>Thanh toán</th>
                        <th>Đã tham gia</th>
                    </tr>
                </thead>
                <tbody>
                    {myevents.map((item) => {
                        return (
                            <tr className='hover:bg-[#f99779]'>
                                <td>{item.Title}</td>
                                <td>20/10/2021</td>
                                <td><input type='checkbox' value='true'/></td>
                                <td><input type='checkbox' value='true'/></td>
                            </tr>
                        )
                    })}
                </tbody>
            </Table>
    </div>
);

export default ParticipatedList;
