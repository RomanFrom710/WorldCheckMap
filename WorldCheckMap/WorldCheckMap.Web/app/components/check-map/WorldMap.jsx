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
        countries: PropTypes.array.isRequired,
        countryStates: PropTypes.array
    };

    _statusColors = {
        [statuses.none]: '#ffffff',
        [statuses.wish]: '#ff0000',
        [statuses.been]: '#00ff00',
        [statuses.lived]: '#0000ff'
    };

    render() {
        return (
            <div>
                <MapLegend typeColors={this._statusColors} />
                <ComposableMap>
                    <ZoomableGroup>
                        <Geographies geographyUrl={require('react-simple-maps/topojson-maps/world-110m.json')}>
                            {(geographies, projection) => geographies.map((geography, i) => (
                                <Geography
                                    key={`geography-${i}`}
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
