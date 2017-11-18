﻿import React from 'react';
import { Route } from 'react-router';

import MainPage from './containers/MainPage';
import CheckMap from './containers/CheckMap';


export default [
    {
        path: '/',
        component: MainPage
    },
    {
        path: '/map/:guid',
        component: CheckMap
    }
]
