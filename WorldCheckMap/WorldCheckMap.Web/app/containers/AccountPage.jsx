﻿import React, { Component } from 'react';
import { connect } from 'react-redux';
import BlockUi from 'react-block-ui';
import { actions as toastrActions } from 'react-redux-toastr';
import {
    ComposableMap,
    ZoomableGroup,
    Geographies,
    Geography,
} from 'react-simple-maps';

import WorldMap from '../components/account-page/WorldMap';
import AccountTitle from '../components/account-page/AccountTitle';
import AccountShare from '../components/account-page/AccountShare';
import CountryStateEditor from '../components/account-page/CountryStateEditor';
import CountryStateViewer from '../components/account-page/CountryStateViewer';

import { getAccount, updateSelectedCountryStatus } from '../thunks/account-thunks';
import { selectCountry } from '../actions/country-actions';
import { accountShareUrl } from '../routes';
import { getCountriesWithStates, getCountryCodeToStatusMap } from '../reducers/selectors';


const mapStateToProps = (state, ownProps) => ({
    countriesWithStates: getCountriesWithStates(state),
    countryCodeToStatusMap: getCountryCodeToStatusMap(state),
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
    updateStatus: status => dispatch(updateSelectedCountryStatus(status)),
    onShareLinkCopy: () => dispatch(toastrActions.add({
        type: 'success',
        title: 'The link has been copied to the clipboard'
    }))
});

class AccountPage extends Component {
    componentDidMount() {
        this.props.getAccount(this.props.accountKey);
    }

    _getShareUrl() {
        const account = this.props.accountInfo;
        if (!account) {
            return null;
        }

        const baseUrl = window.location.origin;
        return `${baseUrl}${accountShareUrl}/${account.id}`;
    }

    render() {
        const account = { ...this.props.accountInfo };
        const selectedCountry = this.props.selectedCountry;

        const selectedCountryInfo = selectedCountry && this.props.countriesWithStates.find(c => c.id === selectedCountry.id);

        const countryStateComponent = this.props.isReadOnly ?
            <CountryStateViewer selectedCountry={selectedCountryInfo} accountName={account.name} /> :
            <CountryStateEditor selectedCountry={selectedCountryInfo} updateStatus={this.props.updateStatus} />;

        const shareComponent = this.props.isReadOnly
            ? null
            : <AccountShare shareUrl={this._getShareUrl()} onLinkCopy={this.props.onShareLinkCopy} />;

        return (
            <BlockUi tag="div" blocking={this.props.isAccountLoading}>
                <AccountTitle name={account.name} />
                <div className="row">
                    <div className="col-md-9">
                        <WorldMap countryCodeToStatusMap={this.props.countryCodeToStatusMap} selectCountry={this.props.selectCountry} />
                    </div>
                    <div className="col-md-3">
                        <BlockUi tag="div" blocking={this.props.isAccountUpdating}>
                            {countryStateComponent}
                        </BlockUi>
                    </div>
                </div>
                {shareComponent}
            </BlockUi>
        );
    }
}

export default connect(
    mapStateToProps,
    mapDispatchToProps
)(AccountPage);