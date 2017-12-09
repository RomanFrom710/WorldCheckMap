import { combineReducers } from 'redux';
import { routerReducer } from 'react-router-redux';

import countries from './countries-reducer';


export default combineReducers({
    countries,
    routerReducer
});
