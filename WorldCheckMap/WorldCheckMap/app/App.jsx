import React, { Component } from 'react';

import Header from './containers/Header';
import WorldMap from './containers/WorldMap';


export default class App extends Component {
    render() {
        return (
            <div>
                <Header />
                <div className="container">
                    <WorldMap />
                </div>
            </div>
        );
    }
}
