import React, { Component } from 'react';
import PropTypes from 'prop-types';


export default class CountryStateEditor extends Component {
    static propTypes = {
        countryStatuses: PropTypes.object.isRequired,
        selectedCountry: PropTypes.object,
        updateStatus: PropTypes.func.isRequired
    };

    state = { countryStatus: this.props.countryStatuses.none.code };

    componentWillReceiveProps(newProps) {
        const oldCountryId = this.props.selectedCountry && this.props.selectedCountry.id;
        const newCountryId = newProps.selectedCountry && newProps.selectedCountry.id;
        if (oldCountryId === newCountryId) {
            return;
        }

        const newCountryStatus = newProps.selectedCountry && newProps.selectedCountry.status;
        this.setState({ countryStatus: newCountryStatus || this.props.countryStatuses.none.code });
    }

    _handleSaveClick = () => this.props.updateStatus(this.state.countryStatus);

    _handleStatusChange = event => this.setState({ countryStatus: +event.target.value });

    render() {
        const selectedCountry = this.props.selectedCountry;
        if (!selectedCountry) {
            return null;
        }

        const statuses = Object.values(this.props.countryStatuses);

        return (
            <div>
                <h2>{selectedCountry.name}</h2>
                <select className="form-control" value={this.state.countryStatus} onChange={this._handleStatusChange}>
                    {statuses.map(s => (
                        <option value={s.code} key={s.code}>{s.name}</option>
                    ))}
                </select>
                <button className="btn btn-primary" onClick={this._handleSaveClick}>
                    Save
                </button>
            </div>
        );
    }
}
