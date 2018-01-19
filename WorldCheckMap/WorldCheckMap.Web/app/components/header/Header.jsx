import React, { Component } from 'react';
import { Link } from 'react-router-dom';


export default class Header extends Component {
    render() {
        return (
            <nav className="navbar navbar-inverse">
                <div className="container">
                    <div className="navbar-header">
                        <Link to="/" className="navbar-brand">WorldCheckMap</Link>
                    </div>
                </div>
            </nav>
        );
    }
}
