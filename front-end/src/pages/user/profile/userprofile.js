import { Avatar, Divider, Grid, Typography } from '@mui/material';
import React from 'react';
import { TextField } from '@mui/material';
import { useUserEvents } from '../../../recoil/user';
import {useState, useEffect} from 'react';
import {useSnackbar} from '../../../HOCs'
import { useParams } from 'react-router-dom';

function UserProfile() {
  const [profile, setUserProfile] = useState({});
    const { id } = useParams();
    const { getUserProfile } = useUserEvents();
    const showSackbar = useSnackbar();
    useEffect(() => {
        getUserProfile(id)
        .then((resposne) => {
            const data = resposne.data.data
            console.log(data[0]);
            setUserProfile(data[0]);
        })
        .catch(() => {
            showSackbar({
                severity: 'error',
                children: 'Something went wrong, please try again later.',
            });
        });
    },[])

    return (
        <Grid
            item
            sx={{
                '& .MuiTextField-root': { m: 1, width: '25ch' },
                mt: 5,
                p: 3,
                pb: 8,
                ml: 30,
            }}
            autoComplete="off"
            lg={12}
            md={12}
            xs={12}
            container
        >
            <Grid
                item
                sx={{
                    display: 'flex',
                    flexDirection: 'colummn',
                    mb: 2,
                    ml: 5,
                }}
                lg={6}
                md={6}
                xs={6}
                container
            >
                <Typography
                    sx={{ display: 'flex', alignItems: 'center', mb: 1 }}
                    color="text.primary"
                    variant="h4"
                >
                    Your Profile
                </Typography>
            </Grid>

            <Divider color="primary" />

            <Grid
                item
                sx={{
                    display: 'flex',
                    flexDirection: 'colummn',
                    mb: 10,
                    ml: 8,
                }}
                lg={6}
                md={6}
                xs={6}
                container
            >
                <Grid
                    item
                    sx={{
                        display: 'flex',
                        flexDirection: 'colummn',
                        mb: 1,
                    }}
                    lg={12}
                    md={12}
                    xs={12}
                    container
                >
                    <Typography
                        style={{ width: '50%' }}
                        color="text.primary"
                        variant="text"
                    >
                        YOUR FULL NAME
                    </Typography>

                    {/* <TextField
                        id="outlined-read-only-input"
                        style={{ width: '50%' }}
                        Value={profile.users_name}
                        InputProps={{
                            readOnly: true,
                        }}
                    /> */}
                    <Grid item xs={10}>
                                    <Typography color="textPrimary"
                                        gutterBottom variant="h5" sx={{ fontWeight: 'normal' }}>
                                      Họ và tên: {profile?.users_name}
                                    </Typography>
                                </Grid>
                </Grid>

                <Grid
                    item
                    sx={{
                        display: 'flex',
                        flexDirection: 'colummn',
                    }}
                    lg={12}
                    md={12}
                    xs={12}
                    container
                >
                    <Typography
                        style={{ width: '50%' }}
                        color="text.primary"
                        variant="text"
                    >
                        EMAIL
                    </Typography>

                    <TextField
                        id="outlined-read-only-input"
                        style={{ width: '50%' }}
                        defaultValue={profile.users_email}
                        InputProps={{
                            readOnly: true,
                        }}
                    />
                </Grid>
            </Grid>
            <Avatar
                src="https://huongnghiepcdm.edu.vn/files/album/dai-hoc-fpt-ho-chi-minh-fpt-university-rrh1j0re.jpg"
                sx={{
                    height: 400,
                    width: 400,
                    mr: 60,
                }}
                variant="square"
            />
        </Grid>
    );
}
export default UserProfile;
