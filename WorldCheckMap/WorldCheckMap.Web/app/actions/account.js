import { createAction } from 'redux-actions';
import { createRequestActions } from './patterns';


export const createAccount = createRequestActions('account.create');
