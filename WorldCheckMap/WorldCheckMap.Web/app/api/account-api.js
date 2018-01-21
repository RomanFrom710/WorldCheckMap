import api from './api-client';


export function createAccount(accountInfo) {
    return api.post('accounts', accountInfo);
}

export function getAccount(key) {
    return api.get(`accounts/${key}`);
}

export function updateState(updateStateCommand) {
    return api.put(`accounts`, updateStateCommand);
}
