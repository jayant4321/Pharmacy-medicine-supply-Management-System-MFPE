import {Nav,Navbar,Container,NavDropdown} from "react-bootstrap"
import 'bootstrap/dist/css/bootstrap.min.css';
import { Outlet, Link } from "react-router-dom"
import AddBusinessIcon from '@mui/icons-material/AddBusiness';
import HomeIcon from '@mui/icons-material/Home';
import LogoutIcon from "@mui/icons-material/Logout";
import MedicationIcon from '@mui/icons-material/Medication';
import MedicationLiquidIcon from '@mui/icons-material/MedicationLiquid';
export default function Main() {
  return (
    <>
   <Navbar bg="dark" variant="dark">
    <Container>
    <Navbar.Brand as={Link} to="/"><AddBusinessIcon className="header_logo" fontSize="medium" /><b>Pharamacy Medicine Supply Management</b></Navbar.Brand>
    <Nav className="me-auto">
      <Nav.Link as={Link} to="/"><strong style={{color:"white"}}><HomeIcon className="header_logo" fontSize="small" /><span></span>Home</strong></Nav.Link>
      <Nav.Link as={Link} to="/Logout"><strong style={{color:"white"}}><LogoutIcon className="header_logo" fontSize="small" /><span>Logout</span></strong></Nav.Link>
      <Nav.Link as={Link} to="/Pharmacysupply"><strong style={{color:"white"}}><MedicationIcon className="header_logo" fontSize="small" />Pharmacy Supply</strong></Nav.Link>
      <Nav.Link as={Link} to="/MedicalRepresentative"><strong style={{color:"white"}}><MedicationLiquidIcon className="header_logo" fontSize="small" />Medical Representative</strong></Nav.Link>
    </Nav>
    </Container>
  </Navbar> 
</>
  );
}
