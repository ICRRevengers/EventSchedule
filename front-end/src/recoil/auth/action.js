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
        const { email, name, exp, role } = jwtDecode(token);
        setAuth({ email, name, exp, role, token });
        history.push('/');
        history.push('/admin/manage/events');
    };

    const autoLogin = () => {
        const token = LocalStorageUtils.getToken();
        const user = LocalStorageUtils.getUser();
        if (user && typeof user === 'object') {
            const expireTime = user.exp * 1000 + Date.now();
            if (user?.exp && expireTime > Date.now()) {
                setAuth({
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
        logout
    };
};

export default useAuthActions;
