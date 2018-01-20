import { handleActions, combineActions } from 'redux-actions';

import { getAccount, createAccount } from '../actions/account-actions';


const initialState = {
    isLoading: false,
    info: null
};

export default handleActions({
    [combineActions(
        getAccount.request,
        createAccount.request
    )]: state => ({ ...state, isLoading: false }),

    [combineActions(
        createAccount.success,
        createAccount.failure,
        getAccount.success,
        getAccount.failure
    )]: state => ({ ...state, isLoading: false })
}, initialState);
