import { handleActions } from 'redux-actions';


const initialState = {
    list: []
};

export default handleActions({
    // Empty reducers container is needed because countries are presented in the global initial state.
}, initialState);
