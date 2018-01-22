import React, { Component } from 'react';
import PropTypes from 'prop-types';

import statuses from '../../enums/country-statuses';


export default class CountryStateViewer extends Component {
    static propTypes = {
        selectedCountry: PropTypes.object,
        accountName: PropTypes.string
    };

    _getStatusVerb() {
        const country = this.props.selectedCountry;
        if (!country) {
            return null;
        }

        const status = country.status;
        switch (status) {
            case statuses.wish.code:
                return 'wish to be';
            case statuses.been.code:
                return 'has been';
            case statuses.lived.code:
                return 'lived';
            case statuses.none.code:
            default:
                return 'wasn\'t';
        }
    }

    render() {
        const selectedCountry = this.props.selectedCountry;
        if (!selectedCountry) {
            return null;
        }

        return (
            <div>
                <h2>{selectedCountry.name}</h2>
                <p>{this.props.accountName} {this._getStatusVerb()} here</p>
            </div>
        );
    }
}
