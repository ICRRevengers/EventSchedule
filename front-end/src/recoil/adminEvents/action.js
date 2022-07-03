import { get } from "../../utils/ApiCaller"
import { APP_API_URL } from "../../config"

const useAdminEvents = () => {
    const getEvents =  () => {
        return get(`${APP_API_URL}/api/Event/get-event-list`)
    }
    return {
        getEvents
    }
}   

export default useAdminEvents