import React, { Component } from 'react';
import PropTypes from 'prop-types';


export default class CreateAccount extends Component {
    static propTypes = {
        createAccount: PropTypes.func.isRequired
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
            <div>
                <button className="btn btn-primary" onClick={this._handleCreateButtonClick}>
                    Create an account
                </button>
                <input type="text" className="form-control" onChange={this._handleInputChange} />
            </div>
        );
    }
}
