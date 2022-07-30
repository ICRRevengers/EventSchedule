import { get, post } from '../../utils/ApiCaller';

const useFeedback = () => {
    const addFeedback = (feedback) =>
        post({
            endpoint: '/api/FeedBack/add-feedback-to-event',
            body: feedback,
        });
    
    const getAllFeedback = (eventId) => get({ endpoint: `/api/FeedBack/get-event-feedback?id=${eventId}` })

    return { addFeedback, getAllFeedback }
};

export default useFeedback
