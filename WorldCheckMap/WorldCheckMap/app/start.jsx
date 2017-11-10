import React from 'react';
import { render } from 'react-dom';

import App from './app';

import 'bootstrap/less/bootstrap.less';


if (module.hot) {
    module.hot.accept();
}

render(
    <App />,
    document.getElementById('react-root')
);