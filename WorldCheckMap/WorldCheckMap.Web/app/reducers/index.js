import { combineReducers } from 'redux';
import { routerReducer } from 'react-router-redux';

import account from './account-reducer';
import countries from './countries-reducer';


export default combineReducers({
    account,
    countries,
    routerReducer
});
