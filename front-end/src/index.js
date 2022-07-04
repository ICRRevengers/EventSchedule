import React, { startTransition } from 'react';
import ReactDOM from 'react-dom/client';
import './index.css';
import App from './App';
import './components/globalStyles/globalStyle.css';
import SnackbarProvider from './HOCs';
import { RecoilRoot } from 'recoil';
import { BrowserRouter as Router } from 'react-router-dom';
const root = ReactDOM.createRoot(document.getElementById('root'));
root.render(
    <React.StrictMode>
        <RecoilRoot>
            <Router>
                <SnackbarProvider>
                    <App />
                </SnackbarProvider>
            </Router>
        </RecoilRoot>
    </React.StrictMode>,
);
