import * as accountActions from '../actions/account-actions';
import * as accountApi from '../api/account-api';


export function createAccount(dispatch, accountInfo) {
    dispatch(async function(dispatch) {
        dispatch(accountActions.createAccount.request());
        try {
            const result = await accountApi.createAccount(accountInfo);
            dispatch(accountActions.createAccount.success(result));
        } catch (err) {
            dispatch(accountActions.createAccount.failure(err));
        }
    });
}
