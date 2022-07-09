import { get, remove, post } from '../../utils/ApiCaller';

const useAdminClubs = () => {
    const getClubs = () => get({ endpoint: '/api/Admin/get-list-admin' })

    const deleteClub = (id) =>
        remove({
            endpoint: `?id=${id}`,
        })

    const searchClubs = (name) => 
        get({
            endpoint: `/api/Admin/get-admin-by-name?name=${name}`,
        })

    const addClub = (name, phone, email, password, role) => 
        post({
            endpoint: `/api/Admin/Add-Admin`,
            body: {
                adminName: name,
                adminPhone: phone,
                adminEmail: email,
                adminPassword: password,
                adminRole: role
              }
        })
    return {
        getClubs,
        deleteClub,
        searchClubs,
        addClub
    };
};
export default useAdminClubs;
