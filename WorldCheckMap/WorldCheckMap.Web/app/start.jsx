import React from 'react';
import { render } from 'react-dom';

import App from './app';

import 'bootstrap/less/bootstrap.less';
import 'react-block-ui/style.css';


if (module.hot) {
    module.hot.accept();
}

render(
    <App />,
    document.getElementById('react-root')
);
