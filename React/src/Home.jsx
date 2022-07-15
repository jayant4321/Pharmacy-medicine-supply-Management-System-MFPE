import "./Home.css";
import "react-responsive-carousel/lib/styles/carousel.min.css"; // requires a loader
import { Carousel } from "react-responsive-carousel";
import { Navbar } from "react-bootstrap";
import {Card, CardGroup,Button} from "react-bootstrap";
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
      <h1 style={{color:"#A7685A"}}><b><u><i>Welcome to Pharamacy Medicine Supply Management</i></u> </b></h1>

      <div className="cardHome">

      <CardGroup>
  <Card>
    <Card.Img variant="top" src="https://drive.google.com/uc?id=1NQS8hpjuS3U0fJDDZhBBj5MxxJ9OpqQE" />
    <Card.Body>
      <Card.Title style={{color:"#5946B1"}}>100% Genuine Medicine</Card.Title>
      <Card.Text>
      All medicines/healthcare products sold are 
      procured from our sister company -  with a reputation of selling only 100% genuine products.
      </Card.Text>
    </Card.Body>
    <Button variant="danger">Last updated 15 days ago</Button>
  </Card>
  <Card>
    <Card.Img variant="top" src="https://drive.google.com/uc?id=1Qcpp_qdGn5k2M5t56WPitwdJGJ9ErCvS" />
    <Card.Body>
      <Card.Title style={{color:"#364E2B"}}>Most Trusted Online Medical Store Of India</Card.Title>
      <Card.Text>
      As pioneers in the healthcare segment, we understand the importance of trust.
       And that is why, over the years, we worked on building that trust.{' '}
      </Card.Text>
    </Card.Body>
    <Button variant="danger">Last updated 15 days ago</Button>
  </Card>
  <Card>
    <Card.Img variant="top" src="https://drive.google.com/uc?id=1ixjvt6C_jCIS9HtLvrlyMdVx5Kgdwqhd" />
    <Card.Body>
      <Card.Title style={{color:"#5946B1"}}>Fastest Home Delivery Of Your Order</Card.Title>
      <Card.Text>
      When it comes to medicines, most of us do not want to take a chance. Which is why most of us prefer 
      going to a store physically to get medicines. But you know what happens at the stores.
      </Card.Text>
    </Card.Body>
    <Button variant="danger">Last updated 15 days ago</Button>
  </Card>
</CardGroup>
<CardGroup>
  <Card>
    <Card.Img variant="top" src="https://drive.google.com/uc?id=1w1nbMwD5Xwe24S3Luwe-VroYcQQ-VG2D" />
    <Card.Body>
      <Card.Title style={{color:"#364E2B"}}>Largest Online Pharmacy In India</Card.Title>
      <Card.Text>
      With more than 4,500 stores in India, Apollo Pharmacy is not just 
      the largest online pharmacy store in India but in Asia as well. 
      </Card.Text>
    </Card.Body>
    <Button variant="danger">Last updated 15 days ago</Button>
  </Card>
  <Card>
    <Card.Img variant="top" src="https://drive.google.com/uc?export=download&id=14_whxvz8eufv8ch01dwRaLdpS8PshWwl" />
    <Card.Body>
      <Card.Title style={{color:"#5946B1"}}>Best Pharmacologist Available To Check Medicine Interactions</Card.Title>
      <Card.Text>
      Sometimes, the medicines prescribed by your doctor may react with your existing medications, food, beverage, 
      or supplements. This is known as medicine interaction and may prevent your medicine to perform as expected. {' '}
      </Card.Text>
    </Card.Body>
    <Button variant="danger">Last updated 15 days ago</Button>
  </Card>
  <Card>
    <Card.Img variant="top" src="https://drive.google.com/uc?id=1HeNLqlSWnNJBsy1lSNfodb8_Apy5_NL1" />
    <Card.Body>
      <Card.Title style={{color:"#364E2B"}}>Additional Services I Will Receive</Card.Title>
      <Card.Text>
      Besides purchasing medicines, the additional services you can avail on our
       platform are doctor consultations, symptom checker, ordering diagnostic tests, and digitization of your health records. 
      </Card.Text>
    </Card.Body>
    <Button variant="danger">Last updated 15 days ago</Button>
  </Card>
</CardGroup>
      </div>
    </div>
    </>   
  );
}

export default Home;