import "./Home.css";
import "react-responsive-carousel/lib/styles/carousel.min.css"; // requires a loader
import { Carousel } from "react-responsive-carousel";
import { Navbar } from "react-bootstrap";
import { useContext } from "react";
import AuthContext from './AuthContext'
import MainLogin from "./MainLogin";
import Main from "./Main";
function Home() {
   const {loggedIn,getloggedin}=useContext(AuthContext)
  return (
   <>
   {loggedIn===false &&<MainLogin/>}
   {loggedIn===true && <Main/>}
    <div className="mainDiv">
      <h1 style={{color:"Red"}}>Welcome to Pharamacy Medicine Supply Management </h1>

      <div className="cardHome">
        <Carousel autoPlay="true" infiniteLoop="true">
          <div>
            <img src="https://images.unsplash.com/photo-1586015555751-63bb77f4322a?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=900&q=40" />
            {/* <p className="legend">Legend 1</p> */}
          </div>
          <div>
            <img src="https://images.unsplash.com/photo-1576602975754-efdf313b9342?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=900&q=40" />
            {/* <p className="legend">Legend 2</p> */}
          </div>
          <div>
            <img src="https://images.unsplash.com/photo-1631549916768-4119b2e5f926?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=900&q=40" />
            {/* <p className="legend">Legend 3</p> */}
          </div>
        </Carousel>
      </div>
    </div>
    </>   
  );
}

export default Home;