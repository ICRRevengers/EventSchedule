import { get, remove } from '../../utils/ApiCaller';

const useAdminEvents = () => {
    const getEvents = () => get({ endpoint: '/api/Event/get-event-list' });

    const getStudentsFromEvent = (id) =>
        get({
            endpoint: `/api/EventParticipated/get-user-list-from-event?id=${id}`,
        });
    
    const deleteEvent = (id) =>
        remove({
            endpoint: `/api/Event/delete-event?id=${id}`,
        })
    return {
        getEvents,
        getStudentsFromEvent,
        deleteEvent
    };
};
export default useAdminEvents;
