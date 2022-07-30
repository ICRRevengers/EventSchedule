import { get, post } from '../../utils/ApiCaller';

const useUserEvents = () => {
    const getEventIJoined = (id) =>
        get({
            endpoint: `/api/EventParticipated/get-all-event-i-joined?id=${id}`,
        });
    const getDetailFromEvent = (id) =>
        get({
            endpoint: `/api/Event/get-event-by-id?id=${id}`,
        });
  
    const joinInEvent = (eventID, userID, data, paymentStatus, usersStatus) =>
        post({
            endpoint: "/api/EventParticipated/add-user-join-event",
            body: {
                eventID: eventID,
                userID: userID,
                dateParticipated: data,
                payment_status: paymentStatus,
                users_status: usersStatus
            }
        })
  
    const getPayment = (id) =>
        get({
            endpoint: `/api/Payment/get-Payment?id=${id}`,
        });

    const getUserProfile = (id) =>
        get({
            endpoint: `/api/User/get-user-by-id?id=${id}`,
        });

    return {
        getDetailFromEvent,
        getPayment,
        getEventIJoined,
        joinInEvent,
        getUserProfile
    };
};
export default useUserEvents;
