import { Navbar, Container, Nav, NavDropdown } from "react-bootstrap";
import { LinkContainer } from 'react-router-bootstrap';

export default function Menu() {
    return (
        <header>
            <Navbar collapseOnSelect expand="lg">
                <Container>
                    <LinkContainer to="/">
                        <Navbar.Brand>Home</Navbar.Brand>
                    </LinkContainer>

                    <Navbar.Toggle aria-controls="responsive-navbar-nav" />

                    <Navbar.Collapse id="responsive-navbar-nav">
                        <Nav className="me-auto">
                            <LinkContainer to="/weather-forecast">
                                <Nav.Link>Weather Forecast</Nav.Link>
                            </LinkContainer>

                            <NavDropdown title="Other" id="basic-nav-dropdown">
                                <LinkContainer to="/test">
                                    <NavDropdown.Item>Test</NavDropdown.Item>
                                </LinkContainer>
                            </NavDropdown>
                        </Nav>
                    </Navbar.Collapse>
                </Container>
            </Navbar>
        </header>
    );
}