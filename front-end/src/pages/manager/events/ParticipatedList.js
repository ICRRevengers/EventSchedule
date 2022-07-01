import Sidebar from '../../../components/layout/sidebar/Sidebar';
import { Table } from 'reactstrap';
import { useEffect, useState } from 'react';
import axios from 'axios';
import '../../../App.scss';
import { useParams } from 'react-router-dom';
import Loading from '../../../components/loading/loading';
import { Typography } from '@mui/material';

function ParticipatedList() {
    const { id } = useParams();
    const [loading, setLoading] = useState(false);
    const [students, setStudents] = useState([]);

    useEffect(() => {
        setLoading(true);
        axios
            .get(
                `http://localhost:5000/api/EventParticipated/get-user-list-from-an-event?id=${id}`,
            )
            .then((res) => {
                const data = res.data
                setStudents(data);
                setTimeout(() => {
                    setLoading(false);
                }, 500);
            })
            .catch((error) => {
                console.log(error.response);
                setTimeout(() => {
                    setLoading(false);
                }, 500);
            });
    }, []);

    const columns = [
        { field: 'userId', headerName: 'MSSV', width: 70 },
        { field: 'userName', headerName: 'Họ tên sinh viên', width: 130 },
        {
            field: 'phone',
            headerName: 'Số điện thoại',
            type: 'number',
            width: 100,
        },
        { field: 'email', headerName: 'Email', type: 'email', width: 100 },
        {
            field: 'dateRegistered',
            headerName: 'Ngày đăng kí tham gia',
            type: 'datetime',
            width: 100,
        },
        { field: 'paymentstatus', headerName: 'Thanh toán', width: 70 },
    ];

    return loading ? (
        <Loading />
    ) : (
        <div className="flex">
            <Sidebar />
            {students.length === 0 ? <Typography>
                <h1 className="text-[#000050] font-bold text-[50px] p-[50px] text-center">
                    Sự kiện <br/> hiện chưa có người đăng kí
                </h1>
            </Typography> : (
                <Table className="m-[20px] w-[900px]">
                <thead>
                    <tr>
                        <th>MSSV</th>
                        <th>Tên sinh viên</th>
                        <th>Ngày đăng kí</th>
                        <th>Thanh toán</th>
                        <th>Đã tham gia</th>
                    </tr>
                </thead>
                <tbody>
                    {students?.map((student) => {
                        return (
                            <tr className="hover:bg-[#f99779]">
                                <td>{student?.users_id}</td>
                                <td>{student?.users_name}</td>
                                <td>{new Intl.DateTimeFormat('en-US', { year: 'numeric', month: 'short', day: '2-digit' }).format(new Date(Date.parse(student.date_participated         )))}</td>
                                <td>
                                    <input type="checkbox" value="true" />
                                </td>
                                <td>
                                    <input type="checkbox" value="true" />
                                </td>
                            </tr>
                        );
                    })}
                </tbody>
            </Table>
            )}
        </div>
    );
}

export default ParticipatedList;
