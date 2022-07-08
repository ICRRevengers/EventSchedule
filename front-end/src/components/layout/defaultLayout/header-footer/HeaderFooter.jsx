import Header from '../header/Header';
import Footer from '../footer/Footer';


const HeaderFooter = ({ children }) => (
    <>
        <Header />
       
        {children}
        <Footer />
    </>
);

export default HeaderFooter;
