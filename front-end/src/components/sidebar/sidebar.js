import { useEffect, useRef, useState } from 'react';
import { Link, useLocation } from 'react-router-dom';
import SideNav, { Toggle, Nav, NavItem, NavIcon, NavText } from '@trendmicro/react-sidenav';
import './sidebar.scss';

const sidebarNavItems = [
    {
        display: 'Admin',
        icon: <i className='bx bx-home'></i>,
        to: '/admin',
        section: 'admin'
    },
    {
        display: 'Post new event',
        icon: <i className='bx bx-star'></i>,
        to: '/postevent',
        section: 'postevent'
    },
    {
        display: 'Event list',
        icon: <i className='bx bx-calendar'></i>,
        to: '/eventlist',
        section: 'eventlist'
    },
    {
        display: 'Profile',
        icon: <i className='bx bx-user'></i>,
        to: '/profile',
        section: 'profile'
    },
]

const Sidebar = () => {
    <SideNav
    onSelect={(selected) => {
        // Add your code here
    }}
>
    <SideNav.Toggle />
    <SideNav.Nav defaultSelected="home">
        <NavItem eventKey="home">
            <NavIcon>
                <i className="fa fa-fw fa-home" style={{ fontSize: '1.75em' }} />
            </NavIcon>
            <NavText>
                Home
            </NavText>
        </NavItem>
        <NavItem eventKey="charts">
            <NavIcon>
                <i className="fa fa-fw fa-line-chart" style={{ fontSize: '1.75em' }} />
            </NavIcon>
            <NavText>
                Charts
            </NavText>
            <NavItem eventKey="charts/linechart">
                <NavText>
                    Line Chart
                </NavText>
            </NavItem>
            <NavItem eventKey="charts/barchart">
                <NavText>
                    Bar Chart
                </NavText>
            </NavItem>
        </NavItem>
    </SideNav.Nav>
</SideNav>
};

export default Sidebar;