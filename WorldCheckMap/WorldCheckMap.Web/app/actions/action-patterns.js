import { createAction } from 'redux-actions';


export function createRequestActions(type) {
    return {
        request: createAction(`${type}.request`),
        success: createAction(`${type}.success`),
        failure: createAction(`${type}.failure`)
    };
}
