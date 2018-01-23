import React, { Component } from 'react';
import PropTypes from 'prop-types';
import randomColor from 'randomcolor';
import geographies from 'react-simple-maps/topojson-maps/world-110m.json';
import {
    ComposableMap,
    ZoomableGroup,
    Geographies,
    Geography,
} from 'react-simple-maps';

import './map-styles.less';


export default class DemoMap extends Component {
    static propTypes = {
        countries: PropTypes.array.isRequired
    };

    _changeColorIntervalMs = 500;
    _selectedCountriesCount = 10;
    _defaultColor = 'white';

    componentDidMount() {
        const updateState = () => this.setState({
            currentColor: randomColor(),
            selectedCountries: [...new Array(this._selectedCountriesCount)].map(() => Math.floor(Math.random() * this.props.countries.length))
        });

        updateState();
        this._intervalId = setInterval(updateState, this._changeColorIntervalMs);
    }

    componentWillUnmount() {
        clearInterval(this._intervalId);
    }

    _getCountryColor = index => {
        return this.state.selectedCountries.find(c => c === index)
            ? this.state.currentColor
            : this._defaultColor;
    }

    render() {
        return (
            <div className="map-container">
                <ComposableMap>
                    <Geographies geography={geographies}  disableOptimization={true}>
                        {(geographies, projection) => geographies.map((geography, i) => (
                            <Geography
                                key={`geography-${i}`}
                                cacheId={`geography-${i}`}
                                geography={geography}
                                projection={projection}
                                style={{
                                    default: {
                                        fill: this._getCountryColor(i),
                                        stroke: 'black',
                                        strokeWidth: 0.5,
                                        outline: 'none'
                                    },
                                    hover: { fill: this._defaultColor, stroke: 'black' },
                                    pressed: { fill: this._defaultColor, stroke: 'black' }
                                }}
                            />
                        ))}
                    </Geographies>
                </ComposableMap>
            </div>
        );
    }
}
