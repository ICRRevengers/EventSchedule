import './components/globalStyles/globalStyle.css';
import SnackbarProvider from './HOCs';
import { RecoilRoot } from 'recoil';

import React from 'react';
import ReactDOM from 'react-dom';
import './index.css';
import App from './App';

ReactDOM.render(
    <React.StrictMode>
        <RecoilRoot>
            <SnackbarProvider>
                <App />
            </SnackbarProvider>
        </RecoilRoot>
    </React.StrictMode>,
    document.getElementById('root'),
);
