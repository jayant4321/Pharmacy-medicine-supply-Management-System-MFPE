using System;
using System.Collections.Generic;

namespace MedicalRepresentativeScheduler.DataProvider
{
    public interface IMedicalRepresentativeSchedule
    {
        public List<RepSchedule> GetSchedule(DateTime startDate);
    }
}
