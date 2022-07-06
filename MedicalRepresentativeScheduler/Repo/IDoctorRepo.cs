using MedicalRepresentativeScheduler.Models;
using System.Collections.Generic;

namespace MedicalRepresentativeScheduler.Repo
{
    public interface IDoctorRepo
    {
        public List<Doctor> GetDoctorDetails();
    }
}
