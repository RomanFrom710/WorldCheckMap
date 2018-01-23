import React, { Component } from 'react';
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
    accountInfo: state.account.info,
    countriesWithStates: getCountriesWithStates(state),
    countryCodeToStatusMap: getCountryCodeToStatusMap(state),
    statusesInfo: state.countries.statusesInfo,
    selectedCountry: state.countries.selected,

    isReadOnly: !ownProps.match.params.guid,
    accountKey: ownProps.match.params.guid || ownProps.match.params.id,

    isAccountLoading: state.account.isInProgress.loading,
    isAccountUpdating: state.account.isInProgress.updating
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

    _getCountryStateComponent() {
        const selectedCountry = this.props.selectedCountry;
        const accountName = this.props.accountInfo && this.props.accountInfo.name;
        if (!selectedCountry) {
            return null;
        }

        const selectedCountryInfo = this.props.countriesWithStates.find(c => c.id === selectedCountry.id);

        return this.props.isReadOnly ?
            <CountryStateViewer
                selectedCountry={selectedCountryInfo}
                accountName={accountName}
                countryStatuses={this.props.statusesInfo}
            /> :
            <CountryStateEditor
                selectedCountry={selectedCountryInfo}
                updateStatus={this.props.updateStatus}
                countryStatuses={this.props.statusesInfo}
            />;
    }

    _getShareComponent() {
        const account = this.props.accountInfo;
        if (!account) {
            return null;
        }

        const baseUrl = window.location.origin;
        const shareUrl = `${baseUrl}${accountShareUrl}/${account.id}`;

        return this.props.isReadOnly
            ? null
            : <AccountShare shareUrl={shareUrl} onLinkCopy={this.props.onShareLinkCopy} />;
    }

    render() {
        const accountName = this.props.accountInfo && this.props.accountInfo.name;

        return (
            <BlockUi tag="div" blocking={this.props.isAccountLoading}>
                <AccountTitle name={accountName} />
                <div className="row">
                    <div className="col-md-9">
                        <WorldMap
                            countryStatuses={this.props.statusesInfo}
                            countryCodeToStatusMap={this.props.countryCodeToStatusMap}
                            selectCountry={this.props.selectCountry}
                        />
                    </div>
                    <div className="col-md-3">
                        <BlockUi tag="div" blocking={this.props.isAccountUpdating}>
                            {this._getCountryStateComponent()}
                        </BlockUi>
                    </div>
                </div>
                {this._getShareComponent()}
            </BlockUi>
        );
    }
}

export default connect(
    mapStateToProps,
    mapDispatchToProps
)(AccountPage);