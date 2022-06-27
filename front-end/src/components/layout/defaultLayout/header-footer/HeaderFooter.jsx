import Header from '../header/Header';
import Footer from '../footer/Footer';
import Carousel from '../../../eventslider/EventSlider';

const HeaderFooter = ({ children }) => (
    <>
        <Header />
        <Carousel />
        {children}
        <Footer />
    </>
);

export default HeaderFooter;
