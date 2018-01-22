import { handleActions, combineActions } from 'redux-actions';

import { getAccount, createAccount, updateState } from '../actions/account-actions';


const initialState = {
    isInProgress: {
        loading: false,
        creating: false,
        updating: false
    },
    info: null
};

export default handleActions({
    [getAccount.request]: state => ({ ...state, isInProgress: { ...initialState.isInProgress, loading: true } }),
    [combineActions(
        getAccount.success,
        getAccount.failure
    )]: state => ({ ...state, isInProgress: { ...initialState.isInProgress, loading: false } }),
    [getAccount.success]: (state, { payload: account }) => ({ ...state, info: account }),


    [createAccount.request]: state => ({ ...state, isInProgress: { ...initialState.isInProgress, creating: true } }),
    [combineActions(
        createAccount.success,
        createAccount.failure
    )]: state => ({ ...state, isInProgress: { ...initialState.isInProgress, creating: false } }),

    [updateState.request]: state => ({ ...state, isInProgress: { ...initialState.isInProgress, updating: true } }),
    [combineActions(
        updateState.success,
        updateState.failure
    )]: state => ({ ...state, isInProgress: { ...initialState.isInProgress, updating: false } }),

    [updateState.success]: (state, { payload: updateInfo }) => {
        const newState = { ...state };
        newState.info.countryStates = newState.info.countryStates.map(cs => ({ ...cs }));

        const existentStatus = newState.info.countryStates.find(cs => cs.countryId === updateInfo.countryId);
        if (existentStatus) {
            existentStatus.status = updateInfo.countryStatus;
        } else {
            newState.info.countryStates.push({
                countryId: updateInfo.countryId,
                status: updateInfo.countryStatus
            });
        }

        return newState;
    }
}, initialState);
