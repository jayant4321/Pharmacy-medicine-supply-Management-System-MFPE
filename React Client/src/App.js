import AfterHome from './AfterHome';
import './App.css';
import Home from './Home';
import Login from './Login';
import MedicalRepresentative from './MedicalRepresentative';
import Pharma from './Pharma';
import {Routes,Route,Link} from "react-router-dom"
import { useContext } from "react";
import AuthContext from "./AuthContext.jsx";
import PageNotFound from './PageNotFound';
import Logout from './Logout';
import Main from './Main';
import Value from './Value';
function App() {
  const { loggedIn } = useContext(AuthContext);
  return (
    <div className="App">
      {loggedIn === false && (
        <Routes>
      <Route path="/" element={<Home/>} />
      <Route path="/Login" element={<Login/>} />
      <Route path='*' element={<PageNotFound/>} />
    </Routes>)}
    {loggedIn===true&&(
        <Routes>
        <Route path="/" element={<Home/>} />
        <Route path="/Login" element={<Login/>} />
        <Route path="/Logout" element={<Logout/>} />
        <Route path="/Pharmacysupply" element={<Pharma/>} />
        <Route path="/MedicalRepresentative" element={<MedicalRepresentative/>} />
        <Route path='*' element={<PageNotFound/>} />
      </Routes>
    )}
    
    </div>
  );
}

export default App;
