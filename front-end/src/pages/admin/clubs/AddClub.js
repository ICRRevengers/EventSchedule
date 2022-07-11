import React, { useState } from 'react';
import Sidebar from '../../../components/layout/sidebar/Sidebar';
import {
    FormControl,
    Input,
    InputLabel,
    Paper,
    MenuItem,
    Grid,
    Button,
    Typography,
    Select,
    TextareaAutosize,
} from '@mui/material';
import { useSnackbar } from '../../../HOCs';
import useAdminClubs from '../../../recoil/manageClubs/action';

const AddClub = () => {
    const [name, setName] = useState('');
    const [phone, setPhone] = useState('');
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');
    const [role, setRole] = useState('club');
    const { addClub } = useAdminClubs();

    const showSackbar = useSnackbar();

    const nameHandle = (event) => {
        setName(event.target.value);
    };

    const phoneHandle = (event) => {
        setPhone(event.target.value);
    };

    const emailHandle = (event) => {
        setEmail(event.target.value);
    };

    const passHandle = (event) => {
        setPassword(event.target.value);
    };

    const roleHandle = (event) => {
        setRole(event.target.value);
    };

   
    function createNew() {
        addClub(name, phone, email, password, role)
            .then((resposne) => {
                showSackbar({
                    severity: 'success',
                    children: resposne.data,
                });
            })
            .catch((error) => {
                showSackbar({
                    severity: 'error',
                    children: 'Something went wrong, please try again later.',
                });
            });
    }

    return (
        <div className="flex">
            <Sidebar />
            <Grid
                container
                sx={{ maxWidth: 980 }}
                justify="center"
                alignContent="center"
            >
                <Grid item xs={6} md={4}>
                    <Paper
                        elevation={4}
                        style={{
                            padding: '20px 15px',
                            marginTop: '30px',
                            marginLeft: '150px',
                            minWidth: '680px',
                        }}
                    >
                        <Typography variant="headline" gutterBottom>
                            Quản trị viên mới
                        </Typography>
                        <FormControl fullWidth margin="normal">
                            <InputLabel>Tên *</InputLabel>
                            <Input
                                fullWidth
                                required
                                value={name}
                                onChange={nameHandle}
                            />
                        </FormControl>
                        <FormControl fullWidth margin="normal">
                            <InputLabel>Số điện thoại *</InputLabel>
                            <Input
                                value={phone}
                                onChange={phoneHandle}
                                fullWidth
                                required
                            />
                        </FormControl>
                        <FormControl fullWidth margin="normal">
                            <InputLabel>Email *</InputLabel>
                            <Input
                                onChange={emailHandle}
                                value={email}
                                fullWidth
                                required
                            />
                        </FormControl>
                        <FormControl fullWidth margin="normal">
                            <InputLabel>Password *</InputLabel>
                            <Input
                                type='password'
                                onChange={passHandle}
                                value={password}
                                fullWidth
                                required
                            />
                        </FormControl>
                        <FormControl fullWidth margin="normal">
                            <Select
                                onChange={roleHandle}
                                value={role}
                            >
                                <MenuItem value="club">Câu lạc bộ</MenuItem>
                                <MenuItem value="admin">Quản trị viên</MenuItem>
                            </Select>
                        </FormControl>
                        
                        <FormControl fullWidth margin="normal">
                            <Button
                                variant="extendedFab"
                                color="primary"
                                type="submit"
                                onClick={createNew}
                            >
                                Tạo mới
                            </Button>
                        </FormControl>
                    </Paper>
                </Grid>
            </Grid>
        </div>
    );
};
export default AddClub;
