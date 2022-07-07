import { get } from '../../utils/ApiCaller';

const useUserEvents = () => {
    const getDetailFromEvent = (id) =>
        get({
            endpoint: `/api/Event/get-event-by-id?id=${id}`,
        });

    const getPayment = (id) =>
        get({
            endpoint: `/api/Payment/get-Payment?id=${id}`,
        });
   
    return {
        getDetailFromEvent,
        getPayment
    };
};
export default useUserEvents;