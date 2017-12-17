import React, { Component } from 'react';
import { createStore, applyMiddleware } from 'redux';
import { Provider } from 'react-redux';
import thunk from 'redux-thunk';
import { ConnectedRouter, routerMiddleware } from 'react-router-redux';
import { renderRoutes } from 'react-router-config';
import { createBrowserHistory } from 'history';

import reducers from './reducers';
import routes from './routes';
import Header from './components/header/Header';


const history = createBrowserHistory();

const middlewares = applyMiddleware(routerMiddleware(history), thunk);
const store = createStore(reducers, window.INITIAL_STATE, middlewares);
window.INITIAL_STATE = undefined;

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
