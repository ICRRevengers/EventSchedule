import { get } from '../../utils/ApiCaller';

const useUserEvents = () => {
    const getDetailFromEvent = (id) =>
        get({
            endpoint: `/api/Event/get-event-by-id?id=${id}`,
        });
   
    return {
        getDetailFromEvent,
    };
};
export default useUserEvents;