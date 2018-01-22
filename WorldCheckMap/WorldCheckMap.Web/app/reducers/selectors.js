import { createSelector } from 'reselect';

import countryStatuses from '../enums/country-statuses';


const countriesSelector = state => state.countries.list;
const countryStatesSelector = state => state.account.info && state.account.info.countryStates;

export const getCountriesWithStates = createSelector(
    [countriesSelector, countryStatesSelector],
    (countries, countryStates) => {
        const states = countryStates || [];

        return countries.map(country => {
            const state = states.find(s => s.countryId === country.id);
            const status = (state && state.status) || countryStatuses.none.code;
            return { ...country, status };
        });
    }
);

export const getCountryCodeToStatusMap = createSelector(
    [getCountriesWithStates],
    countriesWithStates => new Map(countriesWithStates.map(c => [c.code, c.status]))
);
