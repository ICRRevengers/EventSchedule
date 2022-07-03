import { Fragment } from 'react';
import { Routes, Route } from 'react-router-dom';
import { publicRoutes } from './routes/router.js';
import HeaderFooter from './components/layout/defaultLayout/header-footer/HeaderFooter';
import { useAuthActions } from './recoil/auth';
function App() {
    const { autoLogin } = useAuthActions();
    autoLogin();
    return (
        <Routes>
            {publicRoutes.map((route, index) => {
                const Page = route.component;
                let Layout = HeaderFooter;
                if (route.layout) {
                    Layout = route.layout;
                } else if (route.layout === null) {
                    Layout = Fragment;
                }
                return (
                    <Route
                        key={index}
                        path={route.path}
                        element={
                            <Layout>
                                <Page />
                            </Layout>
                        }
                    />
                );
            })}
        </Routes>
    );
}

export default App;
