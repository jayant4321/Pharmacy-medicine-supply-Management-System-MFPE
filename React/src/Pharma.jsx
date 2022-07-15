import React, { useState,useEffect } from "react";
import axios from "axios";
import Button from "@mui/material/Button";
import TextField from "@mui/material/TextField";
import Paper from "@mui/material/Paper";
import Table from "@mui/material/Table";
import TableBody from "@mui/material/TableBody";
import TableCell from "@mui/material/TableCell";
import TableContainer from "@mui/material/TableContainer";
import TableHead from "@mui/material/TableHead";
import TableRow from "@mui/material/TableRow";
import "./Pharma.css";
import Main from "./Main";
function Pharma() {
  const [Medicine1, setMedicine1] = useState("");
  const [Medicine2, setMedicine2] = useState("");
  const [Number1, setNumber1] = useState(0);
  const [Number2, setNumber2] = useState(0);
  const [correct, setcorrect] = useState([]);
  const [visible, inVisible] = useState(false);
  const logindata=[
    
  ]
  async function login(e) {
    e.preventDefault();
    try {
        const data=localStorage.getItem("token")
        console.log("login data",logindata)
        let config = {
          headers: {
            'Authorization': 'Bearer ' + data
          }}
        const loggedinres=await axios.post("https://localhost:5016/PharmacyMedicineSupplyPortal/MedicineSupply",logindata,config,{ withCredentials: true })
        setcorrect(loggedinres["data"])
        {inVisible(true)}
        console.log(loggedinres)
        console.log({correct})
    } catch (error) {
        console.log(error)
    }
  }
  function tab(resp) {
    if (resp == true) {
      return (
        <>
        <div className="table">
          <TableContainer component={Paper}>
            <Table sx={{ minWidth: 650 }} aria-label="simple table">
              <TableHead className="header">
                <TableRow>
                  <TableCell>Pharmacy Name</TableCell>
                  <TableCell align="left">Medicine Name</TableCell>
                  <TableCell align="left">Supply Count</TableCell>
                </TableRow>
              </TableHead>
              <TableBody>
                {correct.map((val) => (
                  <TableRow>
                    <TableCell align="left">{val.pharmacyName}</TableCell>
                    <TableCell align="left">{val.medicineName}</TableCell>
                    <TableCell align="left">{val.supplyCount}</TableCell>
                  </TableRow>
                ))}
              </TableBody>
            </Table>
          </TableContainer>
        </div>
        </>
      );
    }
  }
  function EnterValue()
  {
    {logindata.push({"Medicine":Medicine1,"DemandCount": Number1})}
    {logindata.push({"Medicine":Medicine2,"DemandCount": Number2})}
    return(
      <></>
    )
  }
  useEffect(()=>{},[login])
  return (
    <>
    <Main/>
    <div className="card">
      <form onSubmit={login}>
       
        <TextField
          id="textbox1"
          label="Medicine"
          variant="outlined"
          onChange={(e) => {
            setMedicine1(e.target.value);
          }}
        />
        
        <TextField
          id="textbox2"
          label="DemandCount"
          variant="outlined"
          onChange={(e) => {
            setNumber1(e.target.value);
          }}
        />

        <TextField
          id="textbox3"
          label="Medicine"
          variant="outlined"
          onChange={(e) => {
            setMedicine2(e.target.value);
          }}
        />
        <TextField
          id="textbox4"
          label="DemandCount"
          variant="outlined"
          onChange={(e) => {
            setNumber2(e.target.value);
          }}
        />
        <br />
        {EnterValue()}
        <Button id="button" type="submit" variant="contained">
          Submit
        </Button>
          
        {tab(visible)}
      </form>
    </div>
    </>
  );
}

export default Pharma;