import { Navigate, Route } from 'react-router-dom'
import { useRecoilValue } from 'recoil'

import authAtom from '../recoil/auth'
const PrivateRoute = (props) => {
    const auth = useRecoilValue(authAtom)
    const {role, ...rest} = props

    if (!auth.email) {
        return <Navigate to="/" />
    }

    if (role.includes('admin')) {
        if (auth.role !== 'admin' && auth.role !== "club") {
            return <Navigate to="/" />
        }
    } else if (role.includes('club')) {
        if (role.includes('user')) {
            if (auth.role === 'admin') {
                return <Navigate to="/admin" />
            }
        } else {
            if (auth.role === 'admin') {
                return <Navigate to="/admin" />
            } else if (auth.role === 'user') {
                return <Navigate to="/" />
            }
        }
    }

    return <Route {...rest} />
}
export default PrivateRoute

