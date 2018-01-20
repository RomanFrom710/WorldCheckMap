import { combineReducers } from 'redux';
import { routerReducer } from 'react-router-redux';
import { reducer as toastrReducer } from 'react-redux-toastr'

import account from './account-reducer';
import countries from './countries-reducer';


export default combineReducers({
    account,
    countries,
    router: routerReducer,
    toastr: toastrReducer
});
