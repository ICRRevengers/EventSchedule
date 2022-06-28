import Sidebar from '../../../components/layout/sidebar/Sidebar';
import { FiEdit3 } from 'react-icons/fi';
import Button from '../../../components/button/Button';
import myevents from '../data/data';
import { Table } from 'reactstrap';
import '../../../App.scss'

const ManagerEvents = () => (
    <div className="flex">
        <Sidebar />
        <Table className='m-[20px] w-[1000px]'>
                <thead>
                    <tr>
                        <th>Tên sự kiện</th>
                        <th>Chi tiết</th>
                        <th>Cập nhật</th>
                        <th>Xóa sự kiện</th>
                    </tr>
                </thead>
                <tbody>
                    {myevents.map((item) => {
                        return (
                            <tr>
                                <td>{item.Title}</td>
                                <td><Button>View</Button></td>
                                <td><Button>Update</Button></td>
                                <td><Button>Delete</Button></td>
                            </tr>
                        )
                    })}
                </tbody>
            </Table>
    </div>
);

export default ManagerEvents;
