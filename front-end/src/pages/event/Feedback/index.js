import { RateReview } from '@mui/icons-material';
import { Fab, Tooltip } from '@mui/material';
import React, { useState } from 'react';
import { useParams } from 'react-router-dom';
import { useFeedback } from '../../../recoil/feedback';
import ViewListFeedback from './ViewFeedbacks';

const Feedback = () => {
    const { id } = useParams();
    const [openFeedback, setOpenFeedback] = useState(false);
    const { getAllFeedback } = useFeedback();

    const openViewFeedbackHandler = () => {
        setOpenFeedback(true);
    };

    const closeViewFeedbackHandler = () => {
        setOpenFeedback(false);
    };

    return (
        <React.Fragment>
            <Fab
                color="primary"
                sx={{ position: 'fixed', bottom: 50, right: 25 }}
                onClick={openViewFeedbackHandler}
                variant="extended"
            >
                <Tooltip title="Feedback" sx={{ mr: 1 }}>
                    <RateReview />
                </Tooltip> 
                Feedback
            </Fab>
            {openFeedback && (
                <ViewListFeedback
                    open={openFeedback}
                    eventId={id}
                    onClose={closeViewFeedbackHandler}
                    getFeedbacksOfEvent={getAllFeedback}
                />
            )}
        </React.Fragment>
    );
};

export default Feedback;
