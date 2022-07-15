import React, { PureComponent } from 'react'
import { useContext } from "react";
import AuthContext from './AuthContext'
import MainLogin from './MainLogin';
import Main from './Main';
function PageNotFound()
{
    const {loggedIn,getloggedin}=useContext(AuthContext)
    return(
        <>
        {loggedIn===false &&<MainLogin/>}
        {loggedIn===true && <Main/>}
        <h1>PageNotFound</h1>
        </>
    )
}

export default PageNotFound;