import React, { Component } from 'react';
import PropTypes from 'prop-types';


export default class CountryStateViewer extends Component {
    static propTypes = {
        countryStatuses: PropTypes.object.isRequired,
        selectedCountry: PropTypes.object,
        accountName: PropTypes.string
    };

    render() {
        const selectedCountry = this.props.selectedCountry;
        if (!selectedCountry) {
            return null;
        }

        const statusVerb = Object.values(this.props.countryStatuses)
            .find(v => v.code === selectedCountry.status).statusVerb;

        return (
            <div>
                <h2>{selectedCountry.name}</h2>
                <p>{this.props.accountName} {statusVerb} here</p>
            </div>
        );
    }
}
