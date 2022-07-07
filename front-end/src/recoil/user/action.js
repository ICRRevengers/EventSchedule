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
   
    return {
        getDetailFromEvent,
        getEventIJoined
    };
};
export default useUserEvents;