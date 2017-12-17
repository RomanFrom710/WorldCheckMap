import React, { Component } from 'react';
import { connect } from 'react-redux';

import { createAccount } from '../thunks/account';


const mapStateToProps = state => ({

});

const mapDispatchToProps = dispatch => ({
    createAccount
});

class MainPage extends Component {
    render() {
        return (
            <button className="btn btn-primary">Create an account</button>
        );
    }
}

export default connect(
    mapStateToProps,
    mapDispatchToProps
)(MainPage);
