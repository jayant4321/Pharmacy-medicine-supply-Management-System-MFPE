using MedicalRepresentativeScheduler.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace MedicalRepresentativeScheduler.Repo
{
    public class DoctorRepo : IDoctorRepo
    {
        public List<Doctor> GetDoctorDetails()
        {
            List<Doctor> doctors = GetDetailsCSV();
            return doctors;
        }

        public List<Doctor> GetDetailsCSV()
        {
            List<Doctor> doctorsDetails = new List<Doctor>();
            try
            {
                using (StreamReader sr = new StreamReader("details.csv"))
                {
                    string line;
                    while((line = sr.ReadLine()) != null)
                    {
                        string[] values = line.Split(',');
                        doctorsDetails.Add(new Doctor
                        {
                            Name = values[0],
                            ContactNumber = Convert.ToInt64(values[1]),
                            Slot = values[2],
                            TreatingAlignment = values[3]
                        });
                    }
                }
            }
            catch (NullReferenceException e)
            {

                throw new Exception(e.Message);
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
            return doctorsDetails;
        }
    }
}
