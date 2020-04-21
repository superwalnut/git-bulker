import { Nav, Navbar, Container } from 'react-bootstrap';

const Header = () => (
    <Navbar className="navbar navbar-expand-lg fixed-top navbar-dark bg-primary">
        <Container>
            <Navbar.Brand href="/">git-bulker</Navbar.Brand>
            <Navbar.Toggle aria-controls="basic-navbar-nav" />
            <Navbar.Collapse id="basic-navbar-nav">
            <Nav className="mr-auto">
                <Nav.Link href="/">Home</Nav.Link>
                <Nav.Link href="/projects">Projects</Nav.Link>
                <Nav.Link href="/tags">Tags</Nav.Link>
                <Nav.Link href="/simplegit">Git</Nav.Link>
            </Nav>
            </Navbar.Collapse>
        </Container>
  </Navbar>
);

export default Header;