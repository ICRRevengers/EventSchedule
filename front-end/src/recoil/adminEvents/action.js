import { get } from "../../utils/ApiCaller"
import { APP_API_URL } from "../../config"

const AdminManagement = () => {

    const useAdminEvents = () => {
        const getEvents = () => {
            return get(`${APP_API_URL}api/Event/get-event-list`)
        }
    }

    const useStudentfromEvent = (id) => {
        const getStudents = (id) => {
            return get(`${APP_API_URL}/api/EventParticipated/get-user-list-from-event?id=${id}`)
        }
    }
    return useAdminEvents, useStudentfromEvent
}
export default AdminManagement;