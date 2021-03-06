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
                    children: 'Delete successfully',
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
                    Nh???p t??n s??? ki???n c???n t??m ??? ????y ...
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
                            <TableCell>M?? s???</TableCell>
                            <TableCell align="center">T??n qu???n tr??? vi??n</TableCell>
                            <TableCell align="center">S??? ??i???n tho???i</TableCell>
                            <TableCell align="center">Email</TableCell>
                            <TableCell align="center">Vai tr??</TableCell>
                            <TableCell align="center">X??a</TableCell>
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
                                        X??a
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
