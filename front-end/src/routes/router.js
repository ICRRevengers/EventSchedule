import Error from '../pages/error/Error';
import ManageEvents from '../pages/admin/events/ManageEvent';
import Header from '../components/layout/defaultLayout/header/Header';
import Aboutus from '../pages/aboutus/Aboutus';
import Contact from '../pages/contact/Contact';
import Login from '../pages/login/Login';
import Create from '../pages/admin/events/CreateEvent';
import UpdateEvent from '../pages/admin/events/UpdateEvent';
import ParticipatedList from '../pages/admin/events/ParticipatedList';
import AdminProfile from '../pages/admin/profile/AdminProfile';
import UserProfile from '../pages/user/profile/userprofile';
import { Route, Routes } from 'react-router-dom';
import HeaderFooter from '../components/layout/defaultLayout/header-footer/HeaderFooter';
import AdminLayout from '../components/layout/adminLayout';
import PublicRoute from './PublicRoute';
import AdminHome from '../pages/home/AdminHome';
import UserHome from '../pages/home/UserHome';
import EventDetailAdmin from '../pages/event/eventdetailadmin';
import EventDetailUser from '../pages/event/eventdetailuser';

const publicRoutes = [
    { path: '/aboutus', element: Aboutus, layout: 'user', name: 'about us' },
    {
        path: '/contactus',
        element: Contact,
        layout: 'user',
        name: 'contact us',
    },
    { path: '/login', element: Login, layout: 'user', name: 'login' },
    ,
    { path: '/', element: UserHome, layout: 'user', name: 'home'}

];

//    { path: '/*', element: Error, layout: null },

const privateRoutes = [
    {
        path: '/admin/manage/events',
        element: ManageEvents,
        layout:'admin',
        name:'manage events',
        role:['admin', 'club']
    },
    {
        path: '/admin/manage/postevent',
        element: Create,
        layout:'admin',
        name:'create event',
        role:['admin', 'club']
    },
    {
        path: '/admin/manage/update',
        element: UpdateEvent,
        layout:'admin',
        name:'update event',
        role:['admin', 'club']
    },
    {
        path: '/admin/manage/participated/:id',
        element: ParticipatedList,
        layout:'admin',
        name:'manage participant',
        role:['admin', 'club']
    },
    {
        path: '/admin/manage/profile',
        element: AdminProfile,
        layout:'admin',
        name:'manage profile',
        role:['admin', 'club']
    },
    {
        path: '/user/profile',
        element: UserProfile,
        layout: 'user',
        name: 'user profile',
        role:['user']
    },
];

const Routess = (
    <Routes>
        <Route path="/admin">
            <AdminLayout></AdminLayout>
        </Route>
        <Route>
            <HeaderFooter>
                {publicRoutes.map(({layout, ...route}) => layout === 'user' && (
                    <PublicRoute exact={true} {...route} key={route.name}/>
                ))}
            </HeaderFooter>
        </Route>
    </Routes>
);

export default Routess;

export { publicRoutes, privateRoutes };
