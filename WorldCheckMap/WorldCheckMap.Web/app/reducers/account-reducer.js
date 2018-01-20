import { handleActions, combineActions } from 'redux-actions';

import * as accountActions from '../actions/account-actions';


const initialState = {
    isLoading: false,
    info: null
};

export default handleActions({
    [combineActions(
        accountActions.getAccount.request,
        accountActions.createAccount.request
    )]: state => ({ ...state, isLoading: false }),

    [combineActions(
        accountActions.createAccount.success,
        accountActions.createAccount.failure,
        accountActions.getAccount.success,
        accountActions.getAccount.failure
    )]: state => ({ ...state, isLoading: false })
}, initialState);
