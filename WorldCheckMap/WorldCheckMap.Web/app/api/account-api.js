import api from './api-client';


export function createAccount() {
    return api.post('account/create');
}
