using MedicalRepresentativeScheduler.Models;
using System.Collections.Generic;

namespace MedicalRepresentativeScheduler.DataProvider
{
    public  interface IMedicineStockProvider
    {
        public  List<Medicine> GetMedicineList();
    }
}
