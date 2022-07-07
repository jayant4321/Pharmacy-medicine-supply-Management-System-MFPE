using MedicalRepresentativeScheduler.Models;
using MedicalRepresentativeScheduler.Repo;
using System;
using System.Collections.Generic;

namespace MedicalRepresentativeScheduler.DataProvider
{
    public class MedicalRepresentativeSchedule : IMedicalRepresentativeSchedule
    {
        private static readonly List<Representative> representatives = new List<Representative>()
        {
            new Representative()
            {
                Id = 1,
                Name = "R1"
            },
            new Representative()
            {
                Id = 2,
                Name = "R2"
            },
            new Representative()
            {
                Id = 3,
                Name = "R3"
            }
        };

        public IDoctorRepo doctorRepo;
        public IMedicineStockProvider stock;
        public MedicalRepresentativeSchedule()
        {
            doctorRepo = new DoctorRepo();
            stock = new MedicineStockProvider();
        }

        public List<RepSchedule> GetSchedule(DateTime startDate) 
        { 
            DateTime currentDate = startDate;
            int counter = 0;
            List<Doctor> doctors = doctorRepo.GetDoctorDetails();
            List<RepSchedule> schedules = new List<RepSchedule>();
            foreach(var doctor in doctors)
            {
                currentDate = (currentDate.DayOfWeek == DayOfWeek.Sunday) ? currentDate.AddDays(1) : currentDate;
                var repScedule = new RepSchedule()
                {
                    RepresentativeName = representatives[(counter % 3)].Name,
                    DoctorName = doctor.Name,
                    MeetingSlot = doctor.Slot,
                    DateOfMeeting = currentDate,
                    ContactNumber = doctor.ContactNumber,
                    Medicines = stock.GetMedicineList().FindAll(m => m.TargetAilment == doctor.TreatingAlignment)

                };
                counter++;
                currentDate = currentDate.AddDays(1);
                schedules.Add(repScedule);
            }

            return schedules;
        }

       
    }
}
