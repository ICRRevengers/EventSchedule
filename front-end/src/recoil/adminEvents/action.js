import { get } from '../../utils/ApiCaller';
import {post} from '../../utils/ApiCaller'

const useAdminEvents = () => {
    const getEvents = () => get({ endpoint: '/api/Event/get-event-list' });

    const getStudentsFromEvent = (id) =>
        get({
            endpoint: `/api/EventParticipated/get-user-list-from-event?id=${id}`,
        });

    const loginAdmin = (username, password) => 
        post({
            endpoint: `/api/Admin/login-admin`,
            body: {
                adminMail: username,
                adminPassword: password,
            },
        })
        
    return {
        getEvents,
        getStudentsFromEvent,
        loginAdmin
    };
};
export default useAdminEvents;
