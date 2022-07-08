import { Send } from '@mui/icons-material';
import { Box, Button, FormControl, Modal, Rating, TextField, Typography } from '@mui/material';
import { blueGrey, grey } from '@mui/material/colors';
import React, { useState } from 'react';

const CreateFeedback = ({ open, onClose}) => {

    const [ratingValue, setRatingValue] = useState(0)

    const ratingChangeHandler = (newValue) => {
        console.log(newValue);
        setRatingValue(newValue)
    }

    return (
        <Modal open={open} onBackdropClick={onClose}>
            <Box
                sx={{
                    position: 'absolute',
                    top: '50%',
                    left: '50%',
                    transform: 'translate(-50%, -50%)',
                    bgcolor: 'background.paper',
                    borderRadius: 4,
                    overflow: 'hidden',
                    boxShadow: 24,
                }}
            >
                <Box
                    sx={{
                        py: 3,
                        px: 3,
                        bgcolor: 'primary.main',
                        color: grey[100],
                    }}
                >
                    <Typography variant="h5">
                        How do you feel about the event?
                    </Typography>
                </Box>
                <Box sx={{ py: 4, px: 3 }}>
                    <Box>
                        <Typography
                            fontWeight={700}
                            sx={{ color: blueGrey[900], mb: 0.5, ml: 0.5 }}
                        >
                            Rate this event
                        </Typography>
                        <Box display="flex" alignItems="center">
                            <Rating
                                value={ratingValue}
                                onChange={(_, newValue) =>
                                    ratingChangeHandler(newValue)
                                }
                                sx={{ mr: 1 }}
                            />
                        </Box>
                    </Box>
                    <Box sx={{ mt: 3, ml: 0.5 }}>
                        <Typography
                            fontWeight={700}
                            sx={{ color: blueGrey[900], mb: 1.5 }}
                        >
                            Your feedback!
                        </Typography>
                        <FormControl fullWidth>
                            <TextField
                                // value={feedbackContent.value}
                                multiline
                                minRows={3}
                                maxRows={10}
                                placeholder="Feedback here"
                                // onChange={feedbackChangeHandler}
                            />
                        </FormControl>
                    </Box>
                    <Box
                        display="flex"
                        justifyContent="flex-end"
                        sx={{ mt: 2 }}
                    >
                        <Button
                            variant="contained"
                            color="error"
                            onClick={onClose}
                        >
                            Cancel
                        </Button>
                        <Button
                            variant="contained"
                            endIcon={<Send />}
                            sx={{ ml: 2 }}
                            type="submit"
                        >
                            Send feedback
                        </Button>
                    </Box>
                </Box>
            </Box>
        </Modal>
    );
};

export default CreateFeedback;
