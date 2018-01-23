import React, { Component } from 'react';
import PropTypes from 'prop-types';
import BlockUi from 'react-block-ui';

import './create-account.less';


export default class CreateAccount extends Component {
    static propTypes = {
        createAccount: PropTypes.func.isRequired,
        onEmptyAccountName: PropTypes.func,
        isAccountCreating: PropTypes.bool
    };

    name = '';

    _handleInputChange = event => {
        this.name = event.target.value;
    };

    _handleCreateButtonClick = () => {
        if (this.name) {
            this.props.createAccount({ name: this.name });
        } else {
            this.props.onEmptyAccountName && this.props.onEmptyAccountName();
        }
    };

    render() {
        return (
            <BlockUi tag="div" className="create-account-container" blocking={this.props.isAccountCreating}>
                    <input
                        type="text"
                        placeholder="Your name..."
                        aria-label="Account name"
                        className="form-control account-name-input"
                        required={true}
                        onChange={this._handleInputChange}
                    />
                    <button className="btn btn-primary create-account" onClick={this._handleCreateButtonClick}>
                        Create an account
                    </button>
            </BlockUi>
        );
    }
}
