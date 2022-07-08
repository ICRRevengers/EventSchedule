import { get } from '../../utils/ApiCaller';

const useUserEvents = () => {
    const getEventIJoined = (id) =>
        get({
            endpoint: `/api/EventParticipated/get-all-event-i-joined?id=${id}`
        })
    const getDetailFromEvent = (id) =>
        get({
            endpoint: `/api/Event/get-event-by-id?id=${id}`,

        })
  

    const getPayment = (id) =>
        get({
            endpoint: `/api/Payment/get-Payment?id=${id}`,
        });
   
    return {
        getDetailFromEvent,
        getPayment,
        getEventIJoined


    };
};
export default useUserEvents;