import { useSetRecoilState } from 'recoil';
import LocalStorageUtils from '../../utils/LocalStorageUtils';
import { useHistory } from 'react-router-dom';
import authAtom from './atom';
import jwtDecode from 'jwt-decode';

const useAuthActions = () => {
    const history = useHistory();
    const setAuth = useSetRecoilState(authAtom);

    const login = (token) => {
        LocalStorageUtils.setUser(token);
        const {userId, email, name, exp, role } = jwtDecode(token);
        setAuth({userId, email, name, exp, role, token });
        if (role === 'user') {
            history.push('/');
        } else {
            history.push('/admin/manage/events');
        }
    };

    const autoLogin = () => {
        const token = LocalStorageUtils.getToken();
        const user = LocalStorageUtils.getUser();
        if (user && typeof user === 'object') {
            const expireTime = user.exp * 1000 + Date.now();
            if (user?.exp && expireTime > Date.now()) {
                setAuth({
                    userId : user.userId,
                    email: user.email,
                    nmame: user.name,
                    exp: user.exp,
                    token,
                    role: user.role,
                });
            } else {
                logout();
            }
        } else {
            setAuth({
                userId: '',
                token: null,
                email: '',
                name: '',
                role: '',
                exp: 0,
            });
        }
    };

    const logout = () => {
        LocalStorageUtils.deleteUser();
        setAuth({
            userId: '',
            token: null,
            email: '',
            name: '',
            organization: '',
            image: '',
            role: '',
            exp: 0,
        });
    };

    return {
        login,
        autoLogin,
        logout,
    };
};

export default useAuthActions;
