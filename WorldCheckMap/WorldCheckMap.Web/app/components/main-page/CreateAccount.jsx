import React, { Component } from 'react';
import PropTypes from 'prop-types';
import BlockUi from 'react-block-ui';


export default class CreateAccount extends Component {
    static propTypes = {
        createAccount: PropTypes.func.isRequired,
        isAccountCreating: PropTypes.bool
    };

    name = '';

    _handleInputChange = event => {
        this.name = event.target.value;
    };

    _handleCreateButtonClick = () => {
        this.props.createAccount({ name: this.name });
    };

    render() {
        return (
            <BlockUi tag="div" blocking={this.props.isAccountCreating}>
                <button className="btn btn-primary" onClick={this._handleCreateButtonClick}>
                    Create an account
                </button>
                <input type="text" className="form-control" onChange={this._handleInputChange} />
            </BlockUi>
        );
    }
}
