using PharmacyMedicineSupply.Model;
using System.Collections.Generic;

namespace PharmacyMedicineSupply.DataProvider
{
    public interface IPharmacyData
    {
        public List<string> GetPharmacyName();
        public List<Medicine> GetList();
    }
}
