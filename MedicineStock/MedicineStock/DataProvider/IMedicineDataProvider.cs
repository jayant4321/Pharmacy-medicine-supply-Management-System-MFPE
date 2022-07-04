using MedicineStock.Model;
using System.Collections.Generic;

namespace MedicineStock.DataProvider
{
    public interface IMedicineDataProvider
    {
        public List<Medicine> GetList();
    }
}
