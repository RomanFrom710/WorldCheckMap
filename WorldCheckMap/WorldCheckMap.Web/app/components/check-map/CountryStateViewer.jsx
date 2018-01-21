import React, { Component } from 'react';
import PropTypes from 'prop-types';

import statuses from '../../enums/country-statuses';


export default class CountryStateViewer extends Component {
    static propTypes = {
        selectedCountry: PropTypes.object,
        accountName: PropTypes.string
    };

    _getStatusVerb() {
        if (!this.props.selectedCountry) {
            return null;
        }

        const status = this.props.selectedCountry.status;
        if (status === statuses.none) {
            return 'wasn\'t';
        } else if (status === statuses.wish) {
            return 'wish to be';
        } else {
            return status.toLowerCase();
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
