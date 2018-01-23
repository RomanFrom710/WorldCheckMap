import React, { Component } from 'react';
import PropTypes from 'prop-types';
import geographies from 'react-simple-maps/topojson-maps/world-110m.json';
import {
    ComposableMap,
    ZoomableGroup,
    Geographies,
    Geography,
} from 'react-simple-maps';

import MapLegend from '../map-legend/MapLegend';
import './world-map.less';


export default class WorldMap extends Component {
    static propTypes = {
        countryStatuses: PropTypes.object.isRequired,
        countryCodeToStatusMap: PropTypes.instanceOf(Map).isRequired,
        selectCountry: PropTypes.func,
        showTooltip: PropTypes.func,
        hideTooltip: PropTypes.func
    };

    componentWillMount() {
        const statuses = this.props.countryStatuses;

        this._statusColors = {
            [statuses.none.name]: '#dddddd',
            [statuses.wish.name]: '#ff0000',
            [statuses.been.name]: '#00ff00',
            [statuses.lived.name]: '#0000ff'
        }
    }

    _selectionColor = '#aaaaaa';

    _getCountryColor(countryCode) {
        const statusCode = this.props.countryCodeToStatusMap.get(countryCode);
        const statusName = Object.values(this.props.countryStatuses).find(v => v.code === statusCode).name;
        return this._statusColors[statusName];
    }

    _handleCountryClick = event => {
        const countryCode = event.properties.ISO_A3;
        this.props.selectCountry(countryCode);
    };

    _handleMouseMove = (geography, event) => {
        if (!this.props.showTooltip) {
            return;
        }

        const x = event.clientX;
        const y = event.clientY + window.pageYOffset;
        this.props.showTooltip({
            origin: { x, y },
            content: geography.properties.NAME
        });
    }

    render() {
        return (
            <div>
                <MapLegend typeColors={this._statusColors} />
                <ComposableMap>
                    <ZoomableGroup>
                        <Geographies geography={geographies} disableOptimization={true}>
                            {(geographies, projection) => geographies.map((geography, i) => (
                                <Geography
                                    key={`geography-${i}`}
                                    cacheId={`geography-${i}`}
                                    onClick={this._handleCountryClick}
                                    geography={geography}
                                    projection={projection}
                                    onMouseMove={this._handleMouseMove}
                                    onMouseLeave={this.props.hideTooltip}
                                    style={{
                                        default: {
                                            fill: this._getCountryColor(geography.properties.ISO_A3),
                                            stroke: 'black',
                                            strokeWidth: 0.5,
                                            outline: 'none'
                                        },
                                        hover: { fill: this._selectionColor },
                                        pressed: { fill: this._selectionColor }
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
