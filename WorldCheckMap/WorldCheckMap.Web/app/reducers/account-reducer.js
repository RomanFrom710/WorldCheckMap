import { handleActions } from 'redux-actions';

import * as accountActions from '../actions/account-actions';


const initialState = null;

export default handleActions({
    [accountActions.createAccount.success]: (state, { payload }) => payload
}, initialState);
