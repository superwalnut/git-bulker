import Header from './Header';
import Footer from './Footer';
import HeadSection from './HeadSection';
import { Container } from 'react-bootstrap';

const Layout = ({children}) => (
  <Container>
    <HeadSection />
    <Header />
    <div className="content mb-5">
        {children}
    </div>    
    <Footer />
  </Container>
);

export default Layout;