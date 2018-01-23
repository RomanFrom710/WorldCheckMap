import { handleActions } from 'redux-actions';

import { selectCountry } from '../actions/country-actions';


const initialState = {
    list: [],
    statusesInfo: [],
    selected: null
};

export default handleActions({
    [selectCountry]: (state, { payload: countryCode }) => ({ ...state, selected: state.list.find(c => c.code === countryCode) })
}, initialState);
