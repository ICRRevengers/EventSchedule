import { get, remove, post } from '../../utils/ApiCaller';

const useAdminEvents = () => {
    const getEvents = () => get({ endpoint: '/api/Event/get-event-list' })

    const getStudentsFromEvent = (id) =>
        get({
            endpoint: `/api/EventParticipated/get-user-list-from-event?id=${id}`,
        })
    
    const deleteEvent = (id) =>
        remove({
            endpoint: `/api/Event/delete-event?id=${id}`,
        })

    const searchEvent = (name) => 
        get({
            endpoint: `/api/Event/get-event-by-name?name=${name}`,
        })

    const createEvent = (name, content, eventStart, eventEnd, status) => 
        post({
            endpoint: `/api/Event/add-event`,
            body: {
                eventName: name,
                eventContent: content,
                eventStart: eventStart,
                eventEnd: eventEnd,
                createdBy: "ABC",
                eventCode: "1",
                eventStatus: status,
                paymentStatus: true,
                categoryID: "1",
                locationID: "1",
                adminID: 1
              }
        })
    return {
        getEvents,
        getStudentsFromEvent,
        deleteEvent,
        searchEvent,
        createEvent
    };
};
export default useAdminEvents;
