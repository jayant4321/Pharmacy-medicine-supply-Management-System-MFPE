import {Nav,Navbar,Container,NavDropdown} from "react-bootstrap"
import 'bootstrap/dist/css/bootstrap.min.css';
import { Outlet, Link } from "react-router-dom"
import AddBusinessIcon from '@mui/icons-material/AddBusiness';
import HomeIcon from '@mui/icons-material/Home';
import LoginIcon from '@mui/icons-material/Login';
export default function MainLogin() {
  return (
    <>
   <Navbar bg="dark" variant="dark">
    <Container>
    <Navbar.Brand as={Link} to="/"><AddBusinessIcon className="header_logo" fontSize="medium" /><b>Pharamacy Medicine Supply Management</b></Navbar.Brand>
    <Nav className="me-auto">
      <Nav.Link as={Link} to="/"><strong style={{color:"white"}}><HomeIcon className="header_logo" fontSize="small" /><span></span>Home</strong></Nav.Link>
      <Nav.Link as={Link} to="/Login"><strong style={{color:"white"}}><LoginIcon className="header_logo" fontSize="small" /><span>Login</span></strong></Nav.Link>
    </Nav>
    </Container>
  </Navbar>
</>
  );
}