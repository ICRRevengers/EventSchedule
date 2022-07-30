import { get, remove, post, put } from '../../utils/ApiCaller';

const useAdminEvents = () => {
    const getEvents = () => get({ endpoint: '/api/Event/get-event-list' });

    const getStudentsFromEvent = (id) =>
        get({
            endpoint: `/api/EventParticipated/get-user-list-from-an-event?id=${id}`,
        });

    const deleteEvent = (id) =>
        remove({
            endpoint: `/api/Event/delete-event?id=${id}`,
        });

    const searchEvent = (name) =>
        get({
            endpoint: `/api/Event/get-event-by-name?name=${name}`,
        });

    const getLocations = () =>
        get({
            endpoint: `/api/Event/Get-Location-Open`,
        });

    const getCategories = () =>
        get({
            endpoint: `/api/Event/get-category-list`,
        });

    const createEvent = (
        name,
        content,
        eventStart,
        eventEnd,
        status,
        categoryID,
        locationID,
        id,
        paymentUrl,
        paymentFee,
        imageUrl
    ) =>
        post({
            endpoint: `/api/Event/add-event`,
            body: {
                eventName: name,
                eventContent: content,
                eventStart: eventStart,
                eventEnd: eventEnd,
                eventStatus: status,
                categoryID: categoryID,
                locationID: locationID,
                adminID: id,
                paymentUrl: paymentUrl,
                paymentFee: paymentFee,
                imageUrl: imageUrl,
            },
        });

    const updatePayment = (status, userId, eventId) =>
        put({
            endpoint: '/api/Payment/update-payment',
            params: {
                status: status,
                userId: userId,
                eventId: eventId,
            },
        });

    const updateEvent = (     
            eventId,
            name,
            content,
            eventStart,
            eventEnd,
            status,
            categoryID,
            locationID,
            id,
            paymentUrl,
            paymentFee,
            imageUrl
        ) =>
        put({
            endpoint: '/api/Event/update-event',
            body: {
                eventID: eventId,
                eventName: name,
                eventContent: content,
                eventStart: eventStart,
                eventEnd: eventEnd,
                eventStatus: status,
                categoryID: categoryID,
                locationID: locationID,
                adminID: id,
                paymentUrl: paymentUrl,
                paymentFee: paymentFee,
                imageUrl: imageUrl,
            },
        });

    const getEventDetails = (id) =>
        get({
            endpoint: `/api/Event/get-event-by-id?id=${id}`,
        });

    return {
        getEvents,
        getStudentsFromEvent,
        deleteEvent,
        searchEvent,
        getLocations,
        getCategories,
        createEvent,
        updatePayment,
        updateEvent,
        getEventDetails
    };
};
export default useAdminEvents;
