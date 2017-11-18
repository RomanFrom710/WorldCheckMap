import React, { Component } from 'react';
import {
    ComposableMap,
    ZoomableGroup,
    Geographies,
    Geography,
} from 'react-simple-maps';

import WorldMap from '../components/check-map/WorldMap';


export default class CheckMap extends Component {
    render() {
        return (
            <div>
                <WorldMap />
            </div>
        );
    }
}
