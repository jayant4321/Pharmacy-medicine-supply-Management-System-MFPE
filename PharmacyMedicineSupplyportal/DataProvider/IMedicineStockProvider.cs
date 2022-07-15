using PharmacyMedicineSupplyportal.Model;
using System.Collections.Generic;

namespace PharmacyMedicineSupplyportal.DataProvider
{
    public interface IMedicineStockProvider
    {
        public List<Medicine> GetMedicineList(string token);
    }
}
