import { handleActions, combineActions } from 'redux-actions';

import * as accountActions from '../actions/account-actions';


const initialState = {
    isCreating: false,
    name: null,
    id: null,
    guid: null,
    countryStates: []
};

export default handleActions({
    [accountActions.createAccount.request]: state => ({ ...state, isCreating: true }),

    [combineActions(
        accountActions.createAccount.success,
        accountActions.createAccount.failure
    )]: state => ({ ...state, isCreating: false })
}, initialState);
