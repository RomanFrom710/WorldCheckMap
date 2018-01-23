import React, { Component } from 'react';
import { connect } from 'react-redux';

import CreateAccount from '../components/main-page/CreateAccount';
import DemoMap from '../components/maps/DemoMap';
import { createAccount } from '../thunks/account-thunks';


const mapStateToProps = state => ({
    countries: state.countries.list,
    isAccountCreating: state.account.isInProgress.creating
});

const mapDispatchToProps = dispatch => ({
    createAccount: accountInfo => dispatch(createAccount(accountInfo))
});

class MainPage extends Component {
    render() {
        return (
            <div>
                <h1>Share your travelling experience!</h1>
                <CreateAccount
                    createAccount={this.props.createAccount}
                    isAccountCreating={this.props.isAccountCreating}
                />
                <DemoMap countries={this.props.countries} />
            </div>
        );
    }
}

export default connect(
    mapStateToProps,
    mapDispatchToProps
)(MainPage);
