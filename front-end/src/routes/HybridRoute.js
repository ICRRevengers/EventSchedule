import React from 'react'

import { Redirect, Route } from 'react-router-dom'
import { useRecoilValue } from 'recoil'

import authAtom from '../recoil/auth'

const HybridRoute = (props) => {
    const { publicComponent, privateComponent, ...rest } = props
    const auth = useRecoilValue(authAtom)

    const component = auth.email ? privateComponent : publicComponent
    if (auth.email && ( auth.role === 'admin' || auth.role === 'club')) {
        return <Redirect to="/admin" />
    }

    return <Route component={component} {...rest} />
}

export default HybridRoute
