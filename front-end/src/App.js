import React from 'react';
import { useAuthActions } from './recoil/auth';
import Routes from './routes/router.js';
import { BrowserRouter as Router } from 'react-router-dom';
// 

function App() {
    const { autoLogin } = useAuthActions();
    autoLogin();
    return (
        <React.Fragment>
            <Router>
                {Routes}
            </Router>
        </React.Fragment>
    );
}

export default App;
