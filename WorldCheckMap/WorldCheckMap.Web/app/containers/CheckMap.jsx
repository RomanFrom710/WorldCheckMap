import React, { Component } from 'react';
import { connect } from 'react-redux';
import {
    ComposableMap,
    ZoomableGroup,
    Geographies,
    Geography,
} from 'react-simple-maps';

import WorldMap from '../components/check-map/WorldMap';


const mapStateToProps = state => ({
    countries: state.countries,
    accountInfo: state.account.info
});

const mapDispatchToProps = dispatch => ({

});

class CheckMap extends Component {
    render() {
        return (
            <div>
                <WorldMap />
            </div>
        );
    }
}

export default connect(
    mapStateToProps,
    mapDispatchToProps
)(CheckMap);