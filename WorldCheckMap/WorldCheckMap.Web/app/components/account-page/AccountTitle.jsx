import React, { Component } from 'react';
import PropTypes from 'prop-types';


export default class AccountTitle extends Component {
    static propTypes = {
        name: PropTypes.string
    };

    render() {
        const name = this.props.name;
        if (!name) {
            return null;
        }

        return (
            <h1 className="text-center">{name}'s World Check Map</h1>
        );
    }
}
