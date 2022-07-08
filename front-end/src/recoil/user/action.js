import { get, post } from '../../utils/ApiCaller';

const useUserEvents = () => {
    const getEventIJoined = (id) =>
        get({
            endpoint: `/api/EventParticipated/get-all-event-i-joined?id=${id}`
        })
    const getDetailFromEvent = (id) =>
        get({
            endpoint: `/api/Event/get-event-by-id?id=${id}`,

        })
  
    const joinInEvent = (eventID, userID, dateParticipated) =>
        post({
            endpoint: "/api/EventParticipated/add-user-join-event",
            body: {
                eventID: eventID,
                userID: userID,
                dateParticipated: dateParticipated,
                paymentStatus: true,
                users_status: true,
            }
        })
  
    const getPayment = (id) =>
        get({
            endpoint: `/api/Payment/get-Payment?id=${id}`,
        });
   
    return {
        getDetailFromEvent,
        getPayment,
        getEventIJoined,
        joinInEvent


    };
};
export default useUserEvents;