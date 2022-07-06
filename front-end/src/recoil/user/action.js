import { get } from '../../utils/ApiCaller';

const useUserEvents = () => {
    const getEvents = () => get({ endpoint: '/api/Event/get-event-list' });

    const getDetailFromEvent = (id) =>
        get({
            endpoint: `/api/EventParticipated/get-user-list-from-event?id=${id}`,
        });
   
    return {
        getEvents,
        getDetailFromEvent,
    };
};
export default useUserEvents;