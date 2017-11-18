import React, { Component } from 'react';
import { createStore, applyMiddleware } from 'redux';
import { Provider } from 'react-redux';
import { ConnectedRouter, routerMiddleware } from 'react-router-redux';
import { renderRoutes } from 'react-router-config';
import { createBrowserHistory } from 'history';

import reducers from './reducers';
import routes from './routes';
import Header from './components/header/Header';

const history = createBrowserHistory();
const routerEnhancer = applyMiddleware(routerMiddleware(history));
const store = createStore(reducers, routerEnhancer);

export default class App extends Component {
    render() {
        return (
            <Provider store={store}>
                <div>
                    <Header />
                    <div className="container">
                        <ConnectedRouter history={history}>
                            {renderRoutes(routes)}
                        </ConnectedRouter>
                    </div>
                </div>
            </Provider>
        );
    }
}
