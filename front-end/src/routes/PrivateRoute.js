import { Redirect, Route } from 'react-router-dom'
import { useRecoilValue } from 'recoil'

import authAtom from '../recoil/auth'
const PrivateRoute = (props) => {
    const auth = useRecoilValue(authAtom)
    const {role, ...rest} = props

    if (!auth.email) {
        return <Redirect to="/" />
    }

    if (role.includes('user')) {
        if (auth.role !== 'user') {
            return <Redirect to="/admin" />
        }
    } else if (role.includes('admin')) {
        if (role.includes('club')) {
            if (auth.role === 'user') {
                return <Redirect to="/" />
            }
        } else {
            if (auth.role === 'user') {
                return <Redirect to="/" />
            } else if (auth.role === 'user') {
                return <Redirect to="/admin" />
            }
        }
    }

    return <Route {...rest} />
}
export default PrivateRoute

