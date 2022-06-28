import Home from '../pages/home/Home';
import Error from '../pages/error/Error';
import ManagerEvents from '../pages/manager/events/ManagerEvent';
import Header from '../components/layout/defaultLayout/header/Header';
import Aboutus from '../pages/aboutus/Aboutus';
import Contact from '../pages/contact/Contact';
import Login from '../pages/login/Login';

const publicRoutes = [
    { path: '/', component: Home },
    { path: '/aboutus', component: Aboutus },
    { path: '/contactus', component: Contact },
    { path: '/login', component: Login },
    {
        path: '/manage/events',
        component: ManagerEvents,
        layout: Header
    },
    { path: '/*', component: Error, layout: null },
];

const privateRoutes = [];

export { publicRoutes, privateRoutes };
