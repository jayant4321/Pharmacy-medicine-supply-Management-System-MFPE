import React, { useEffect, useState } from "react";
import { useNavigate } from 'react-router-dom'
import { useContext } from "react";
import AuthContext from './AuthContext'
function Logout()
{
    let history=useNavigate()
    const {loggedIn,getloggedin}=useContext(AuthContext)
    useEffect(()=>{ 
    if(loggedIn)
    {   
    localStorage.removeItem("token")
    getloggedin()
    }
    history("/",{replace:true})},[])
}

export default Logout;