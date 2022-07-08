import { post } from '../../utils/ApiCaller';

const useFeedback = () => {
    const addFeedback = (feedback) =>
        post({
            endpoint: '/api/FeedBack/add-feedback-to-event',
            body: feedback,
        });

    return { addFeedback }
};

export default useFeedback
