import { get, remove, post, put } from '../../utils/ApiCaller';

const useAdminInfo = () => {
    const getInfo = () => 
        get({
            endpoint: `api/Admin/get-admin-by-id?id=2`
        })
        
    const updateInfo = (id, name, phone, pass) =>
        put({
            endpoint: `/api/Admin/update-admin`,
            body : {
                adminID: id,
                adminName: name,
                adminPhone: phone,
                adminPassword: pass
            }
        })
    return (
        updateInfo,
        getInfo
    )
}

export default useAdminInfo