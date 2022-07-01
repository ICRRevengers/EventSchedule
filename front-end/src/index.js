import React, { startTransition } from 'react';
import ReactDOM from 'react-dom/client';
import './index.css';
import App from './App';
import './components/globalStyles/globalStyle.css';

const root = ReactDOM.createRoot(document.getElementById('root'));
root.render(  
    <React.StrictMode>
        <App />
    </React.StrictMode>,
);
