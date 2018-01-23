import React, { Component } from 'react';
import { connect } from 'react-redux';
import { actions as toastrActions } from 'react-redux-toastr';

import CreateAccount from '../components/main-page/CreateAccount';
import DemoMap from '../components/maps/DemoMap';
import { createAccount } from '../thunks/account-thunks';


const mapStateToProps = state => ({
    countries: state.countries.list,
    isAccountCreating: state.account.isInProgress.creating
});

const mapDispatchToProps = dispatch => ({
    createAccount: accountInfo => dispatch(createAccount(accountInfo)),
    onEmptyAccountName: () => dispatch(toastrActions.add({
        type: 'error',
        message: 'Please fill the account name'
    }))
});

class MainPage extends Component {
    render() {
        return (
            <div>
                <h1 className="text-center">Share your travelling experience!</h1>
                <CreateAccount
                    createAccount={this.props.createAccount}
                    isAccountCreating={this.props.isAccountCreating}
                    onEmptyAccountName={this.props.onEmptyAccountName}
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
