import React, { Component } from 'react';
import { connect } from 'react-redux';

import CreateAccount from '../components/main-page/CreateAccount';
import { createAccount } from '../thunks/account-thunks';


const mapStateToProps = state => ({

});

const mapDispatchToProps = dispatch => ({
    createAccount: accountInfo => createAccount(dispatch, accountInfo)
});

class MainPage extends Component {
    render() {
        return (
            <CreateAccount createAccount={this.props.createAccount} />
        );
    }
}

export default connect(
    mapStateToProps,
    mapDispatchToProps
)(MainPage);
