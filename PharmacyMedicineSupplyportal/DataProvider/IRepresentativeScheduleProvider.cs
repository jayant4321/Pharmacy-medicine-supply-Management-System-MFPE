using PharmacyMedicineSupplyportal.Model;
using System;
using System.Collections.Generic;

namespace PharmacyMedicineSupplyportal.DataProvider
{
    public interface IRepresentativeScheduleProvider
    {
        public List<RepSchedule> GetRepSchedule(DateTime startDate,string token);
    }
}
