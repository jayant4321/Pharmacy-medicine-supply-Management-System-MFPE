import {Nav,Navbar,Container,NavDropdown} from "react-bootstrap"
import 'bootstrap/dist/css/bootstrap.min.css';
import { Outlet, Link } from "react-router-dom"
export default function MainLogin() {
  return (
    <>
   <Navbar bg="primary" variant="dark">
    <Container>
    <Navbar.Brand as={Link} to="/">Pharamacy Medicine Supply Management</Navbar.Brand>
    <Nav className="me-auto">
      <Nav.Link as={Link} to="/">Home</Nav.Link>
      <Nav.Link as={Link} to="/Login">Login</Nav.Link>
    </Nav>
    </Container>
  </Navbar>
</>
  );
}