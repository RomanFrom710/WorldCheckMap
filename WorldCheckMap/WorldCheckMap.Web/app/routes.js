import React from 'react';
import { Route } from 'react-router';

import MainPage from './containers/MainPage';
import AccountPage from './containers/AccountPage';


export default [
    {
        path: '/map/:guid',
        component: AccountPage
    },
    {
        path: '/share/:id',
        component: AccountPage
    },
    {
        path: '/',
        component: MainPage
    }
];
