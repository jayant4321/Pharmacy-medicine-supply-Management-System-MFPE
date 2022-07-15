using Azure.Storage.Blobs;
using MedicalRepresentativeScheduler.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace MedicalRepresentativeScheduler.Repo
{
    public class DoctorRepo : IDoctorRepo
    {
        private string connectionString = "";
        private string _containerName = "blobcontainer";
        public List<Doctor> GetDoctorDetails()
        {
            //List<Doctor> doctors = GetDetailsCSV();
            List<Doctor> doctors = new List<Doctor>()
            {
               new Doctor{Id=1,Name="D1",ContactNumber=9884122113,Slot="1PM TO 2PM",TreatingAlignment="Orthopaedics" },
               new Doctor{Id=2,Name="D2",ContactNumber=9884122113,Slot="1PM TO 2PM",TreatingAlignment="General" },
               new Doctor{Id=3,Name="D3",ContactNumber=9884122113,Slot="1PM TO 2PM",TreatingAlignment="General" },
               new Doctor{Id=4,Name="D4",ContactNumber=9884122113,Slot="1PM TO 2PM",TreatingAlignment="Orthopaedics" },
               new Doctor{Id=5,Name="D5",ContactNumber=9884122113,Slot="1PM TO 2PM",TreatingAlignment="Gynaecology" }
            };
            return doctors;
        }

        public List<Doctor> GetDetailsCSV()
        {
            BlobServiceClient blobServiceClient = new BlobServiceClient(connectionString);
            BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(_containerName);
            BlobClient blobClient = containerClient.GetBlobClient("details.csv");
            MemoryStream memoryStream = new MemoryStream();
            blobClient.DownloadTo(memoryStream);
            memoryStream.Position = 0;

            List<Doctor> doctorsDetails = new List<Doctor>();
            try
            {
                using (StreamReader sr = new StreamReader(memoryStream))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
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
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return doctorsDetails;
        }
    }
}
