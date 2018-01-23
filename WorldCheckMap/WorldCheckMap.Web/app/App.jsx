import React, { Component } from 'react';
import { createStore, applyMiddleware } from 'redux';
import { Provider } from 'react-redux';
import thunk from 'redux-thunk';
import { ConnectedRouter, routerMiddleware } from 'react-router-redux';
import { renderRoutes } from 'react-router-config';
import { createBrowserHistory } from 'history';
import ReduxToastr from 'react-redux-toastr';
import { Tooltip } from 'redux-tooltip';
import { composeWithDevTools } from 'redux-devtools-extension';

import reducers from './reducers';
import routes from './routes';
import Header from './components/header/Header';


const history = createBrowserHistory();

const initialState = {
    countries: {
        list: INITIAL_DATA.countries,
        statusesInfo: INITIAL_DATA.countryStatuses
    }
};

const middlewares = applyMiddleware(routerMiddleware(history), thunk);
const store = createStore(reducers, initialState, composeWithDevTools(middlewares));

export default class App extends Component {
    render() {
        return (
            <Provider store={store}>
                <ConnectedRouter history={history}>
                    <div>
                        <Header />
                        <div className="container">
                            {renderRoutes(routes)}
                        </div>
                        <ReduxToastr />
                        <Tooltip />
                    </div>
                </ConnectedRouter>
            </Provider>
        );
    }
}
