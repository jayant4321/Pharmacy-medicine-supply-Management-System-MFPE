import React, { useEffect, useState } from "react";
import axios from "axios";
import AuthContext from './AuthContext'
import Button from "@mui/material/Button";
import TextField from "@mui/material/TextField";
import { useContext } from "react";
import { useNavigate } from 'react-router-dom'
import "./Login.css"
import MainLogin from "./MainLogin";
function Login() {
    const [userName, setuserName] = useState("")
    const [password, setPassword] = useState("")
    const [correct,setcorrect]=useState(undefined)
    const {loggedIn,getloggedin}=useContext(AuthContext)
    let history=useNavigate()
    async function login(e){
        e.preventDefault()
        try {
            const logindata={
                    "username":userName,
                     "password":password
            }
            const data=localStorage.getItem("token")
            console.log("login data",logindata)
            //const loggedinres=await axios.post("https://localhost:5012/api/PharmacyAuth",logindata,{ withCredentials: true })
            const loggedinres=await axios.post("https://localhost:5016/PharmacyMedicineSupplyPortal/PharmacyAuth",logindata,{ withCredentials: true })
            setcorrect(loggedinres.data)
            console.log(loggedinres)
            console.log({correct})
            localStorage.setItem("token",loggedinres.data.token)
            getloggedin()
            history("/", { replace: true });
        } catch (error) {
            console.log(error)
        }
    }
    useEffect(()=>{if(loggedIn){history("/",{replace:true})}},[])
    return (
        <>
        {loggedIn===false &&  <>
        <MainLogin/>
      <div className="loginCard">
        <div className="centerDiv">
          <h1>Login</h1>
          <form onSubmit={login}>
            <TextField
              fullWidth
              label="username"
              id="textfield"
              onChange={(e) => {
                setuserName(e.target.value);
              }}
            />
            <TextField
              fullWidth
              label="password"
              id="textfield"
              type="password"
              onChange={(e) => {
                setPassword(e.target.value);
              }}
            />

            <br />
            <Button id="button" type="submit" variant="contained">
              Login
            </Button>
          </form>
        </div>
      </div>
    </>}

        </>
    )
}

export default Login;