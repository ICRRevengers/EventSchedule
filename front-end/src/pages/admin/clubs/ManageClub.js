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
    const { getClubs, searchClubs, changeClubStatus } = useAdminClubs();
    const [name, setName] = useState('');
    const [clubsStatusClone, setClubsStatusClone] = useState([])

    // function deleteItem(id) {
    //     deleteClub(id)
    //         .then((resposne) => {
    //             const deletedArray = clubs.filter(
    //                 (club) => club.admin_id !== id,
    //             );
    //             setClubs(deletedArray);
    //             showSackbar({
    //                 severity: 'success',
    //                 children: 'Delete successfully',
    //             });
    //         })
    //         .catch(() => {
    //             showSackbar({
    //                 severity: 'error',
    //                 children: 'Something went wrong, please try again later.',
    //             });
    //         });
    // }


    const changeClubStatusHandler = (userId, status, index) => {
        changeClubStatus(userId, status).then(response => {
            const data = response.data.data 
            const clubsClone = [...clubs]
            clubsClone[index].admin_status = data
            const clubStatusChanged = clubsClone.map(club => club.admin_status)
            setClubsStatusClone(clubStatusChanged)
        }).catch(() => {
            showSackbar({
                severity: 'error',
                children: 'Something went wrong, please try again later.',
            });
        })
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
                const statusArray = data.map(club => club.admin_status)
                setClubsStatusClone(statusArray)
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
                            <TableCell>STT</TableCell>
                            <TableCell align="center">Tên quản trị viên</TableCell>
                            <TableCell align="center">Số điện thoại</TableCell>
                            <TableCell align="center">Email</TableCell>
                            <TableCell align="center">Vai trò</TableCell>
                            <TableCell align="center">Thay đổi trạng thái</TableCell>
                        </TableRow>
                    </TableHead>
                    <TableBody>
                        {clubs?.map((club, index) => (
                            <TableRow
                                key={clubs?.admin_id}
                                sx={{
                                    '&:last-child td, &:last-child th': {
                                        border: 0,
                                    },
                                }}
                            >
                                <TableCell component="th" scope="row">
                                    {index + 1}
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
                                    {club?.admin_status}
                                    <Button
                                        onClick={(e) =>
                                            changeClubStatusHandler(club.admin_id, !club.admin_status, index)
                                        }
                                        variant="outlined"
                                        color={clubsStatusClone[index] ? 'error' : 'success'}
                                    >
                                        {clubsStatusClone[index] ? 'Inactive' : 'Active'}
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
