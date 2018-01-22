import React, { Component } from 'react';
import PropTypes from 'prop-types';
import {
    ComposableMap,
    ZoomableGroup,
    Geographies,
    Geography,
} from 'react-simple-maps';

import MapLegend from './map-legend/MapLegend';
import statuses from '../../enums/country-statuses';


export default class WorldMap extends Component {
    static propTypes = {
        countryStates: PropTypes.array,
        selectCountry: PropTypes.func
    };

    _statusColors = {
        [statuses.none.name]: '#ffffff',
        [statuses.wish.name]: '#ff0000',
        [statuses.been.name]: '#00ff00',
        [statuses.lived.name]: '#0000ff'
    };

    _handleCountryClick = event => {
        const countryCode = event.properties.ISO_A3;
        this.props.selectCountry(countryCode);
    };

    render() {
        return (
            <div>
                <MapLegend typeColors={this._statusColors} />
                <ComposableMap>
                    <ZoomableGroup>
                        <Geographies geography={require('react-simple-maps/topojson-maps/world-110m.json')}>
                            {(geographies, projection) => geographies.map((geography, i) => (
                                <Geography
                                    key={`geography-${i}`}
                                    onClick={this._handleCountryClick}
                                    geography={geography}
                                    projection={projection}
                                    style={{
                                        default: {
                                            stroke: "#FFF",
                                            strokeWidth: 0.5,
                                            outline: "none"
                                        }
                                    }}
                                />
                            ))}
                        </Geographies>
                    </ZoomableGroup>
                </ComposableMap>
            </div>
        );
    }
}
