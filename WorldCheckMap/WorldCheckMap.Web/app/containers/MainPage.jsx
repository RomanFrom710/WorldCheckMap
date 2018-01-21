import React, { Component } from 'react';
import { connect } from 'react-redux';

import CreateAccount from '../components/main-page/CreateAccount';
import { createAccount } from '../thunks/account-thunks';


const mapStateToProps = state => ({
    isAccountCreating: state.account.isLoading
});

const mapDispatchToProps = dispatch => ({
    createAccount: accountInfo => dispatch(createAccount(accountInfo))
});

class MainPage extends Component {
    render() {
        return (
            <CreateAccount
                createAccount={this.props.createAccount}
                isAccountCreating={this.props.isAccountCreating}
            />
        );
    }
}

export default connect(
    mapStateToProps,
    mapDispatchToProps
)(MainPage);
