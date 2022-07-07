import React, { useEffect, useState } from "react";
import axios from "axios";
import AuthContext from './AuthContext'
import { useContext } from "react";
import { useNavigate } from 'react-router-dom'
function Value() {
    const [email, setEmail] = useState("")
    const [password, setPassword] = useState("")
    const [correct,setcorrect]=useState(undefined)
    const {loggedIn,getloggedin}=useContext(AuthContext)
    let history=useNavigate()
    async function login(e){
        e.preventDefault()
        try {
            const logindata={
                    "username":"Jayant",
                     "password":"Jayant@123"
            }
            
            console.log("login data",logindata)
            const data=localStorage.getItem("token")
            console.log(data)
            let config = {
                headers: {
                  'Authorization': 'Bearer ' + data
                }}
            const loggedinres=await axios.get("https://localhost:5001/api/Values",config,{ withCredentials: true })
            console.log(loggedinres.data)
            
        } catch (error) {
            console.log(error)
        }
    }
    return (
        <>  
            <form onSubmit={login}>
                <input type="text" placeholder="Email" onChange={(e) => { setEmail(e.target.value) }} />
                <input type="password" onChange={(e) => { setPassword(e.target.value) }} />
                <button type="submit">Login</button>
            </form>

        </>
    )
}

export default Value;