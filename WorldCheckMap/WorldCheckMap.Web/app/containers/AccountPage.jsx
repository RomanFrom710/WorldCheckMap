import React, { Component } from 'react';
import { connect } from 'react-redux';
import BlockUi from 'react-block-ui';
import {
    ComposableMap,
    ZoomableGroup,
    Geographies,
    Geography,
} from 'react-simple-maps';

import WorldMap from '../components/check-map/WorldMap';
import AccountTitle from '../components/check-map/AccountTitle';
import CountryStateEditor from '../components/check-map/CountryStateEditor';
import CountryStateViewer from '../components/check-map/CountryStateViewer';
import { getAccount, updateSelectedCountryStatus } from '../thunks/account-thunks';
import { selectCountry } from '../actions/country-actions';
import countryStatuses from '../enums/country-statuses';


const mapStateToProps = (state, ownProps) => ({
    countries: state.countries.list,
    selectedCountry: state.countries.selected,
    accountInfo: state.account.info,
    isAccountLoading: state.account.isInProgress.loading,
    isAccountUpdating: state.account.isInProgress.updating,
    isReadOnly: !ownProps.match.params.guid,
    accountKey: ownProps.match.params.guid || ownProps.match.params.id
});

const mapDispatchToProps = dispatch => ({
    getAccount: key => dispatch(getAccount(key)),
    selectCountry: countryCode => dispatch(selectCountry(countryCode)),
    updateStatus: status => dispatch(updateSelectedCountryStatus(status))
});

class AccountPage extends Component {
    componentDidMount() {
        this.props.getAccount(this.props.accountKey);
    }

    _getSelectedCountryInfo() {
        const selectedCountry = this.props.selectedCountry;
        if (!selectedCountry) {
            return null;
        }

        const existentCountryState = this.props.accountInfo.countryStates &&
            this.props.accountInfo.countryStates.find(cs => cs.countryId === selectedCountry.id);

        return {
            ...selectedCountry,
            status: (existentCountryState && existentCountryState.status) || countryStatuses.none.code
        };
    }

    render() {
        const account = this.props.accountInfo;
        const countryStates = account && account.countryStates;
        const accountName = account && account.name;

        const countryStateComponent = this.props.isReadOnly ?
            <CountryStateViewer selectedCountry={this._getSelectedCountryInfo()} accountName={accountName} /> :
            <CountryStateEditor selectedCountry={this._getSelectedCountryInfo()} updateStatus={this.props.updateStatus} />;

        return (
            <BlockUi tag="div" blocking={this.props.isAccountLoading}>
                <AccountTitle name={accountName} />
                <div className="row">
                    <div className="col-md-9">
                        <WorldMap countryStates={countryStates} selectCountry={this.props.selectCountry} />
                    </div>
                    <div className="col-md-3">
                        <BlockUi tag="div" blocking={this.props.isAccountUpdating}>
                            {countryStateComponent}
                        </BlockUi>
                    </div>
                </div>
            </BlockUi>
        );
    }
}

export default connect(
    mapStateToProps,
    mapDispatchToProps
)(AccountPage);