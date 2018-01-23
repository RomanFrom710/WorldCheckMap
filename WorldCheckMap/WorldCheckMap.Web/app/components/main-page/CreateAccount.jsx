import React, { Component } from 'react';
import PropTypes from 'prop-types';
import BlockUi from 'react-block-ui';

import './create-account.less';


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
            <BlockUi tag="div" className="create-account-container" blocking={this.props.isAccountCreating}>
                    <input
                        type="text"
                        placeholder="Your name..."
                        aria-label="Account name"
                        className="form-control account-name-input"
                        onChange={this._handleInputChange}
                    />
                    <button className="btn btn-primary create-account" onClick={this._handleCreateButtonClick}>
                        Create an account
                    </button>
            </BlockUi>
        );
    }
}
