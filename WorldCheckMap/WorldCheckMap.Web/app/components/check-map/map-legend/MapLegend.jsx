import React, { Component } from 'react';
import PropTypes from 'prop-types';
import {
    ComposableMap,
    ZoomableGroup,
    Geographies,
    Geography,
} from 'react-simple-maps';

import './map-legend.less';


export default class MapLegend extends Component {
    static propTypes = {
        typeColors: PropTypes.object.isRequired
    };

    render() {
        const statuses = Object.keys(this.props.typeColors);

        const legendItems = statuses.map(status => (
            <span className="legend-item" key={status}>
                <span className="color-block" style={{ backgroundColor: this.props.typeColors[status] }}></span>
                <span className="title">{status}</span>
            </span>
        ));

        return (
            <div className="legend-container">
                {legendItems}
            </div>
        );
    }
}
