import { get, remove, post, put } from '../../utils/ApiCaller';

const useAdminInfo = () => {
    const getAdmin = (id) => 
        get({ 
            endpoint: `/api/Admin/get-admin-by-id?id=${id}`,
        });

    const updateProfile = (id, name, phone, pass) =>
        put({
            endpoint: `/api/Admin/update-admin?adminId=${id}`,
            body:{
                adminName: name,
                adminPhone: phone,
                adminPassword: pass,
            }
        });

    return {
        getAdmin,
        updateProfile,
    };
};
export default useAdminInfo;
