import React from 'react';
import { useEffect, useState } from 'react';
import axios from 'axios';
import { styled } from '@mui/material/styles';
import Grid from '@mui/material/Grid';
import Paper from '@mui/material/Paper';
import Typography from '@mui/material/Typography';
import ButtonBase from '@mui/material/ButtonBase';

const Img = styled('img')({
    margin: 'auto',
    display: 'block',
    maxWidth: '100%',
    maxHeight: '100%',
});

const Aboutus = () => {
    const [clubs, setClubs] = useState([]);

    useEffect(() => {
        axios
            .get(`http://localhost:5000/api/Admin/get-list-admin`)
            .then((res) => {
                const data = res.data.data;
                setClubs(data);
            })
            .catch((error) => {
                console.log(error);
            });
    }, []);
    return (
        <Paper
            sx={{
                p: 2,
                margin: 'auto',
                marginBottom: 3,
                maxWidth: 1000,
                flexGrow: 1,
                backgroundColor: (theme) =>
                    theme.palette.mode === 'dark' ? '#1A2027' : '#fff',
            }}
        >
            {clubs.map((club) => (
            <Grid container spacing={2} key={club?.admin_id} sx={{paddingBottom : 2 }}>
                <Grid item>
                    <ButtonBase sx={{ width: 128, height: 128 }}>
                        <Img
                            alt="complex"
                            src={club.image_url}
                        />
                    </ButtonBase>
                </Grid>
                <Grid item xs={12} sm container>
                    <Grid item xs container direction="column" spacing={2}>
                        <Grid item xs>
                            <Typography
                                gutterBottom
                                variant="subtitle1"
                                component="div"
                                sx={{color: '#f22405'}}
                            >
                                {club?.admin_name}
                            </Typography>
                            <Typography variant="body2" gutterBottom>
                                {club?.admin_phone}
                            </Typography>
                            <Typography variant="body2" gutterBottom>
                                {club?.admin_email}
                            </Typography>
                        </Grid>
                    </Grid>
                    <Grid item>
                        <Typography variant="subtitle1" component="div">
                            {club?.admin_id}
                        </Typography>
                    </Grid>
                </Grid>
            </Grid>
            ))}
        </Paper>
    );
};

export default Aboutus;
