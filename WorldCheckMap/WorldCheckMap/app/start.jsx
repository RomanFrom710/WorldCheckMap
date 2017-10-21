import React from 'react';
import { render } from 'react-dom';
import { AppContainer } from 'react-hot-loader';

import 'bootstrap/less/bootstrap.less';

render(
    <AppContainer>
        <p>Hi thereee</p>
    </AppContainer>,
    document.getElementById('react-root')
);