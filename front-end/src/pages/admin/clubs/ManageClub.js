import Sidebar from '../../../components/layout/sidebar/Sidebar';
import '../../../App.scss';
import { useEffect, useState } from 'react';
import {
    InputLabel,
    Table,
    TableBody,
    TableCell,
    TableContainer,
    TableHead,
    TableRow,
    TextField,
} from '@mui/material';
import Paper from '@mui/material/Paper';
import Button from '@mui/material/Button';
import { useAdminClubs } from '../../../recoil/manageClubs';
import { useSnackbar } from '../../../HOCs';

const ManageClubs = () => {
    const [clubs, setClubs] = useState([]);
    const showSackbar = useSnackbar();
    const { getClubs, searchClubs, deleteClub } = useAdminClubs();
    const [name, setName] = useState('');

    function deleteItem(id) {
        deleteClub(id)
            .then((resposne) => {
                const deletedArray = clubs.filter(
                    (club) => club.admin_id !== id,
                );
                setClubs(deletedArray);
                showSackbar({
                    severity: 'success',
                    children: resposne.data,
                });
            })
            .catch(() => {
                showSackbar({
                    severity: 'error',
                    children: 'Something went wrong, please try again later.',
                });
            });
    }

    const eventNameHandler = (event) => {
        setName(event.target.value);
    };

    function searchClublist(name) {
        searchClubs(name)
            .then((resposne) => {
                const data = resposne.data.data;
                setClubs(data);
            })
            .catch((error) => {
                showSackbar({
                    severity: 'error',
                    children: 'Something went wrong, please try again later.',
                });
            });
    }

    useEffect(() => {
        getClubs()
            .then((resposne) => {
                const data = resposne.data.data;
                setClubs(data);
            })
            .catch(() => {
                showSackbar({
                    severity: 'error',
                    children: 'Something went wrong, please try again later.',
                });
            });
    }, []);

    return (
        <div className="flex">
            <Sidebar />
            <TableContainer component={Paper} sx={{ maxWidth: 980 }}>
                <InputLabel
                    sx={{ paddingLeft: 2, paddingTop: 2 }}
                    className="adminLabel"
                >
                    Nhập tên sự kiện cần tìm ở đây ...
                </InputLabel>
                <TextField
                    sx={{ padding: 2 }}
                    id="filled-basic"
                    variant="filled"
                    onChange={eventNameHandler}
                    onKeyPress={(club) => {
                        if (club.key === 'Enter') {
                            searchClublist(name);
                        }
                    }}
                    fullWidth
                />
                <Table
                    sx={{ minWidth: 650, marginTop: 2 }}
                    aria-label="club list"
                >
                    <TableHead>
                        <TableRow>
                            <TableCell>Mã số</TableCell>
                            <TableCell align="center">Tên quản trị viên</TableCell>
                            <TableCell align="center">Số điện thoại</TableCell>
                            <TableCell align="center">Email</TableCell>
                            <TableCell align="center">Vai trò</TableCell>
                            <TableCell align="center">Xóa</TableCell>
                        </TableRow>
                    </TableHead>
                    <TableBody>
                        {clubs?.map((club) => (
                            <TableRow
                                key={clubs?.admin_id}
                                sx={{
                                    '&:last-child td, &:last-child th': {
                                        border: 0,
                                    },
                                }}
                            >
                                <TableCell component="th" scope="row">
                                    {club?.admin_id}
                                </TableCell>
                                <TableCell align="center">
                                    {club?.admin_name}
                                </TableCell>
                                <TableCell align="center">
                                    {club?.admin_phone}
                                </TableCell>
                                <TableCell align="center">
                                    {club?.admin_email}
                                </TableCell>
                                <TableCell align="center">
                                    {club?.admin_role}
                                </TableCell>
                                <TableCell align="center">
                                    <Button
                                        onClick={(e) =>
                                            deleteItem(club.admin_id)
                                        }
                                        variant="contained"
                                    >
                                        Xóa
                                    </Button>
                                </TableCell>
                            </TableRow>
                        ))}
                    </TableBody>
                </Table>
            </TableContainer>
        </div>
    );
};

export default ManageClubs;
