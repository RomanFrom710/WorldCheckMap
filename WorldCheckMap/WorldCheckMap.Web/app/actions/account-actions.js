import { createRequestActions } from './action-patterns';


export const createAccount = createRequestActions('account.create');
export const getAccount = createRequestActions('account.get');
