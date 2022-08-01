import React, { useState } from 'react';
import emailjs from '@emailjs/browser';
import { useSnackbar } from '../../HOCs';
import { Stack, TextField, Button } from '@mui/material';
import '../../App.scss';

const Contact = () => {
    // const form = useRef();
    const [result, showResult] = useState(false);
    const showSackbar = useSnackbar();

    const sendEmail = (e) => {
        e.preventDefault();

        emailjs
            .sendForm('essgmail', 'template_ess', e.target, 'qgWIwkNalDiLxrVfi')
            .then(
                () => {
                    showSackbar({
                        severity: 'success',
                        children: 'Sent sucessfully',
                    });
                },
                (error) => {
                    console.log(error.text);
                },
            );
        e.target.reset();
        showResult(true);
    };

    return (
        <>
            <Stack
                component="form"
                sx={{
                    width: '370px',
                    alignItems: 'center',
                    justifyContent: 'center',
                    margin: '0 auto',
                    paddingTop: '30px',
                    paddingBottom: '30px'
                }}
                spacing={2}
                onSubmit={sendEmail}
            >
                <TextField
                    label="Họ và tên"
                    variant="outlined"
                    color="warning"
                    name="user_name"
                    focused
                    required
                    fullWidth
                />
                <TextField
                    label="Email"
                    variant="outlined"
                    color="warning"
                    type='email'
                    name="user_email"
                    focused
                    required
                    fullWidth
                />
                <TextField
                    label="Số điện thoại"
                    variant="outlined"
                    color="warning"
                    type='tel'
                    name="user_phone"
                    focused
                    required
                    fullWidth
                />
                <TextField
                    label="Lời nhắn"
                    variant="outlined"
                    color="warning"
                    name="message"
                    focused
                    required
                    fullWidth
                />
                <Button
                    variant="contained"
                    color="warning"
                    type='submit'
                >Gửi</Button>
            </Stack>
        </>
    );
};

export default Contact;
