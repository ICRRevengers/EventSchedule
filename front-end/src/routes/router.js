import React from 'react';
import { Redirect, Route, Switch } from 'react-router-dom';
import HeaderFooter from '../components/layout/defaultLayout/header-footer/HeaderFooter';
import AdminLayout from '../components/layout/adminLayout';
import PublicRoute from './PublicRoute';
import HybridRoute from './HybridRoute';
import PrivateRoute from './PrivateRoute';
import { lazy } from 'react';
import { Suspense } from 'react';
import Loading from '../components/loading/loading';

const publicRoutes = [
    {
        path: '/login',
        component: lazy(() => import('../pages/login/Login')),
        name: 'login',
        layout: false,
    },
];

const hybridRoutes = [
    {
        path: '/aboutus',
        publicComponent: lazy(() => import('../pages/aboutus/Aboutus')),
        privateComponent: lazy(() => import('../pages/aboutus/Aboutus')),
        layout: 'user',
        name: 'about us',
    },
    {
        path: '/contactus',
        publicComponent: lazy(() => import('../pages/contact/Contact')),
        privateComponent: lazy(() => import('../pages/contact/Contact')),
        layout: 'user',
        name: 'contact us',
    },
    {
        path: '/',
        publicComponent: lazy(() => import('../pages/home/UserHome')),
        privateComponent: lazy(() => import('../pages/home/UserHome')),
        layout: 'user',
        name: 'user home',
    },
];

const privateRoutes = [
    {
        path: '/admin',
        component: lazy(() => import('../pages/home/AdminHome')),
        layout: 'admin',
        name: 'admin home',
        role: ['admin', 'club'],
    },
    {
        path: '/admin/manage/events',
        component: lazy(() => import('../pages/admin/events/ManageEvent')),
        layout: 'admin',
        name: 'manage events',
        role: ['admin', 'club'],
    },
    {
        path: '/admin/manage/postevent',
        component: lazy(() => import('../pages/admin/events/CreateEvent')),
        layout: 'admin',
        name: 'create event',
        role: ['admin', 'club'],
    },
    {
        path: '/admin/manage/update/:id',
        component: lazy(() => import('../pages/admin/events/UpdateEvent')),
        layout: 'admin',
        name: 'update event',
        role: ['admin', 'club'],
    },
    {
        path: '/admin/manage/participated/:id',
        component: lazy(() => import('../pages/admin/events/ParticipatedList')),
        layout: 'admin',
        name: 'manage participant',
        role: ['admin', 'club'],
    },
    {
        path: '/admin/manage/profile/:id',
        component: lazy(() => import('../pages/admin/profile/AdminProfile')),
        layout: 'admin',
        name: 'manage profile',
        role: ['admin', 'club'],
    },
    {
        path: '/admin/manage/eventdetail/:id',
        component: lazy(() => import('../pages/event/eventdetailadmin')),
        layout: 'admin',
        name: 'manage profile',
        role: ['admin', 'club'],
    },
    {
        path: '/admin/manage/club',
        component: lazy(() => import('../pages/admin/clubs/ManageClub')),
        layout: 'admin',
        name: 'admin home',
        role: ['admin'],
    },
    {
        path: '/admin/manage/add-new-admin',
        component: lazy(() => import('../pages/admin/clubs/AddClub')),
        layout: 'admin',
        name: 'admin home',
        role: ['admin'],
    },
    {
        path: '/user/profile/:id',
        component: lazy(() => import('../pages/user/profile/userprofile')),
        layout: 'user',
        name: 'user profile',
        role: ['user'],
    },
    {
        path: '/user/eventdetail/:id',
        component: lazy(() => import('../pages/event/eventdetailuser')),
        layout: 'user',
        name: 'user profile',
        role: ['user'],
    },
    {
        path: '/user/listparticipated/:id',
        component: lazy(() =>
            import('../pages/user/listparticipated/UserParticipatedList'),
        ),
        layout: 'user',
        name: 'event i joined',
        role: ['user'],
    },
    {
        path: '/user/paymentpage/:id',
        component: lazy(() => import('../pages/event/paymentpage')),
        layout: 'user',
        name: 'user profile',
        role: ['user'],
    },
];

const Routes = (
    <Suspense fallback={<Loading />}>
        <Switch>
            {publicRoutes.map(
                ({ layout, ...route }) =>
                    !layout && (
                        <PublicRoute key={route.name} exact={true} {...route} />
                    ),
            )}
            {privateRoutes.map(
                ({ layout, ...route }) =>
                    !layout && (
                        <PrivateRoute
                            key={route.name}
                            exact={true}
                            {...route}
                        />
                    ),
            )}
            {hybridRoutes.map(
                ({ layout, ...route }) =>
                    !layout && (
                        <HybridRoute key={route.name} exact={true} {...route} />
                    ),
            )}
            <Route path="/admin">
                <AdminLayout>
                    <Suspense fallback={<Loading />}>
                        <Switch>
                            {publicRoutes.map(
                                ({ layout, ...route }) =>
                                    layout === 'admin' && (
                                        <PublicRoute
                                            exact={true}
                                            {...route}
                                            key={route.name}
                                        />
                                    ),
                            )}
                            {privateRoutes.map(
                                ({ layout, ...route }) =>
                                    layout === 'admin' && (
                                        <PrivateRoute
                                            exact={true}
                                            {...route}
                                            key={route.name}
                                        />
                                    ),
                            )}
                            {hybridRoutes.map(
                                ({ layout, ...route }) =>
                                    layout === 'admin' && (
                                        <HybridRoute
                                            exact={true}
                                            {...route}
                                            key={route.name}
                                        />
                                    ),
                            )}
                             <Redirect to="/admin" />
                        </Switch>
                    </Suspense>
                </AdminLayout>
            </Route>
            <Route>
                <HeaderFooter>
                    <Suspense fallback={<Loading />}>
                        <Switch>
                            {publicRoutes.map(
                                ({ layout, ...route }) =>
                                    layout === 'user' && (
                                        <PublicRoute
                                            exact={true}
                                            {...route}
                                            key={route.name}
                                        />
                                    ),
                            )}
                            {privateRoutes.map(
                                ({ layout, ...route }) =>
                                    layout === 'user' && (
                                        <PrivateRoute
                                            exact={true}
                                            {...route}
                                            key={route.name}
                                        />
                                    ),
                            )}
                            {hybridRoutes.map(
                                ({ layout, ...route }) =>
                                    layout === 'user' && (
                                        <HybridRoute
                                            exact={true}
                                            {...route}
                                            key={route.name}
                                        />
                                    ),
                            )}
                             <Redirect to="/" />
                        </Switch>
                    </Suspense>
                </HeaderFooter>
            </Route>
        </Switch>
    </Suspense>
);

export default Routes;
