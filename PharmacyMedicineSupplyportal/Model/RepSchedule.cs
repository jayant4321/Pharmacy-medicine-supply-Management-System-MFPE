using System;
using System.Collections.Generic;

namespace PharmacyMedicineSupplyportal.Model
{
    public class RepSchedule
    {
        public string RepresentativeName { get; set; }
        public string DoctorName { get; set; }
        public string MeetingSlot { get; set; }
        public DateTime DateOfMeeting { get; set; }
        public long ContactNumber { get; set; }

        public List<Medicine> Medicines { get; set; }
    }
}
