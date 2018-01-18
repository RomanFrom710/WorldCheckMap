import api from './api-client';


export function createAccount(accountInfo) {
    return api.post('accounts', accountInfo);
}
