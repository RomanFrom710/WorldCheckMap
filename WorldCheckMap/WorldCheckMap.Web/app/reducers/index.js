import { combineReducers } from 'redux';
import { routerReducer as router } from 'react-router-redux';
import { reducer as toastr } from 'react-redux-toastr';
import { reducer as tooltip } from 'redux-tooltip';

import account from './account-reducer';
import countries from './countries-reducer';


export default combineReducers({
    account,
    countries,
    router,
    toastr,
    tooltip
});
