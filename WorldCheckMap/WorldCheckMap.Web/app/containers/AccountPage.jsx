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
import CountryStateEditor from '../components/check-map/CountryStateEditor';
import CountryStateViewer from '../components/check-map/CountryStateViewer';
import { getAccount } from '../thunks/account-thunks';


const mapStateToProps = (state, ownProps) => ({
    countries: state.countries.list,
    accountInfo: state.account.info,
    isAccountLoading: state.account.isLoading,
    isReadOnly: !ownProps.match.params.guid,
    accountKey: ownProps.match.params.guid || ownProps.match.params.id
});

const mapDispatchToProps = dispatch => ({
    getAccount: key => getAccount(dispatch, key)
});

class AccountPage extends Component {
    componentDidMount() {
        this.props.getAccount(this.props.accountKey);
    }

    render() {
        const countryStateComponent = this.props.isReadOnly ?
            <CountryStateViewer /> :
            <CountryStateEditor />;

        return (
            <BlockUi tag="div" blocking={this.props.isAccountLoading}>
                <WorldMap countries={this.props.countries} />
                {countryStateComponent}
            </BlockUi>
        );
    }
}

export default connect(
    mapStateToProps,
    mapDispatchToProps
)(AccountPage);