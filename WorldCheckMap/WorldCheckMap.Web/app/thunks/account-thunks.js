import { push } from 'react-router-redux';
import { actions as toastrActions } from 'react-redux-toastr';

import * as accountActions from '../actions/account-actions';
import * as accountApi from '../api/account-api';


export function createAccount(accountInfo) {
    return async function(dispatch) {
        dispatch(accountActions.createAccount.request());

        try {
            const newAccount = await accountApi.createAccount(accountInfo);
            dispatch(accountActions.createAccount.success(newAccount));
            dispatch(push(`/map/${newAccount.guid}`));
        } catch (err) {
            dispatch(accountActions.createAccount.failure(err));
        }
    };
}

export function getAccount(key) {
    return async function(dispatch) {
        dispatch(accountActions.getAccount.request());

        try {
            const account = await accountApi.getAccount(key);
            dispatch(accountActions.getAccount.success(account));
        } catch (err) {
            dispatch(accountActions.getAccount.failure(err));

            dispatch(push('/'));
            dispatch(toastrActions.add({
                type: 'error',
                title: 'Account is not found',
                message: 'Please check the account key'
            }));
        }
    };
}

export function updateSelectedCountryStatus(status) {
    return async function(dispatch, getState) {
        dispatch(accountActions.updateState.request());

        try {
            const state = getState();
            const updateCommand = {
                countryStatus: status,
                countryId: state.countries.selected.id,
                accountGuid: state.account.info.guid
            };

            await accountApi.updateState(updateCommand);
            dispatch(accountActions.updateState.success(updateCommand));
        } catch (err) {
            dispatch(accountActions.updateState.failure(err));
        }
    };
}
