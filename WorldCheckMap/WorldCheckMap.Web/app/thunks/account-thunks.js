import { push } from 'react-router-redux';

import * as accountActions from '../actions/account-actions';
import * as accountApi from '../api/account-api';


export function createAccount(dispatch, accountInfo) {
    dispatch(async function(dispatch) {
        dispatch(accountActions.createAccount.request());

        try {
            const newAccount = await accountApi.createAccount(accountInfo);
            dispatch(accountActions.createAccount.success(newAccount));
            dispatch(push(`/map/${newAccount.guid}`));
        } catch (err) {
            dispatch(accountActions.createAccount.failure(err));
        }
    });
}
