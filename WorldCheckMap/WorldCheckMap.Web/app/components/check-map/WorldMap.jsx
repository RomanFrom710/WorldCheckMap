import React, { Component } from 'react';
import {
    ComposableMap,
    ZoomableGroup,
    Geographies,
    Geography,
} from 'react-simple-maps';


export default class WorldMap extends Component {
    render() {
        return (
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
        );
    }
}
