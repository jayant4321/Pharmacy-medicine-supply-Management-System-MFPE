import React, { useState,useEffect } from "react";
import axios from "axios";
import { MedicineData } from "./MedicineData";
import Button from "@mui/material/Button";
import TextField from "@mui/material/TextField";
import Paper from "@mui/material/Paper";
import Table from "@mui/material/Table";
import TableBody from "@mui/material/TableBody";
import TableCell from "@mui/material/TableCell";
import TableContainer from "@mui/material/TableContainer";
import TableHead from "@mui/material/TableHead";
import TableRow from "@mui/material/TableRow";
import "./MedicalRepresentative.css";
import Main from "./Main";
function MedicalRepresentative() {
  const [startDate,SetStartDate]=useState("");
  const [correct, setcorrect] = useState([]);
  const [visible, inVisible] = useState(false);
  async function login(e) {
    e.preventDefault();
    try {
      const logindata = {
        "startDate":startDate 
      }
      const str={startDate}
      const send="https://localhost:5008/RepSchedule"+"/"+str["startDate"]
      console.log(send)
      console.log("login data", logindata);

      const loggedinres = await axios.get(
        send,
        { withCredentials: true }
      );
      setcorrect(loggedinres["data"]);
      console.log({correct})
      {
        inVisible(true);
      }
      console.log(loggedinres);
      console.log({ correct });
    } catch (error) {
      console.log(error);
    }
    // {
    //   setcorrect(MedicineData);
    // }
    // {
    //   inVisible(true);
    // }
  }
  function tab(resp) {
    if (resp == true) {
      function formatDate(string){
        var options = { year: 'numeric', month: 'long', day: 'numeric' };
        return new Date(string).toLocaleDateString([],options);
    }
      {correct.map((val)=>{
          val.dateOfMeeting=formatDate(val.dateOfMeeting)
      })}
      return (
        <>
        <div className="table">
          <TableContainer component={Paper}>
            <Table sx={{ minWidth: 650 }} aria-label="simple table">
              <TableHead className="header">
                <TableRow>
                  <TableCell>Representative Name</TableCell>
                  <TableCell align="left">Doctor Name</TableCell>
                  <TableCell align="left">Meeting Slot</TableCell>
                  <TableCell>Date</TableCell>
                  <TableCell align="left">Doctor Contact</TableCell>
                  <TableCell align="left">Target Ailment</TableCell>
                  <TableCell align="left">Medicines</TableCell>
                </TableRow>
              </TableHead>

              <TableBody>
                {correct.map((val) => (
                  <TableRow>
                    <TableCell align="left">{val.representativeName}</TableCell>
                    <TableCell align="left">{val.doctorName}</TableCell>
                    <TableCell align="left">{val.meetingSlot}</TableCell>
                    <TableCell align="left">{val.dateOfMeeting}</TableCell>
                    <TableCell align="left">{val.contactNumber}</TableCell>
                    <TableCell align="left">
                      {val.medicines.map((va, i) => {
                        if (i === 1) return <>{va.targetAilment}</>;
                      })}
                    </TableCell>
                    <TableCell align="left">
                      {val.medicines.map((va, i) => (
                        <>{va.name}</>
                      ))}
                    </TableCell>
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
  useEffect(()=>{},[login])
  return (
    <>
    <Main/>
    <div className="card">
      <form onSubmit={login}>
        <TextField
          fullWidth
          label="Enter the date E.g.-30 July 2020"
          id="textfield"
          onChange={(e) => {
            SetStartDate(e.target.value);
          }}
        />
        <br />
        <Button id="button" type="submit" variant="contained">
          Submit
        </Button>
      </form>
      {tab(visible)}
    </div>
    </>
  );
}

export default MedicalRepresentative;