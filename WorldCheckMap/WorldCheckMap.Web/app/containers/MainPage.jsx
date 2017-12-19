import React, { Component } from 'react';
import { connect } from 'react-redux';

import { createAccount } from '../thunks/account-thunks';


const mapStateToProps = state => ({

});

const mapDispatchToProps = dispatch => ({
    createAccount: () => dispatch(createAccount)
});

class MainPage extends Component {
    render() {
        return (
            <button className="btn btn-primary" onClick={this.props.createAccount}>
                Create an account
                </button>
        );
    }
}

export default connect(
    mapStateToProps,
    mapDispatchToProps
)(MainPage);
