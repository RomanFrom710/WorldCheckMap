import * as accountActions from '../actions/account-actions';
import * as accountApi from '../api/account-api';


export async function createAccount(dispatch) {
    dispatch(accountActions.createAccount.request());
    try {
        const result = await accountApi.createAccount();
        dispatch(accountActions.createAccount.success(result));
    } catch(err) {
        dispatch(accountActions.createAccount.failure(err));
    }
}
