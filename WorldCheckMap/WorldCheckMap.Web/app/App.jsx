import React, { Component } from 'react';
import { createStore, applyMiddleware } from 'redux';
import { Provider } from 'react-redux';
import thunk from 'redux-thunk';
import { composeWithDevTools } from 'redux-devtools-extension';
import { ConnectedRouter, routerMiddleware } from 'react-router-redux';
import { renderRoutes } from 'react-router-config';
import { createBrowserHistory } from 'history';

import reducers from './reducers';
import routes from './routes';
import Header from './components/header/Header';


const history = createBrowserHistory();

var initialState = {
    countries: {
        list: INITIAL_STATE.countries,
        statuses: INITIAL_STATE
    }
};
window.INITIAL_STATE = undefined;

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
                    </div>
                </ConnectedRouter>
            </Provider>
        );
    }
}
