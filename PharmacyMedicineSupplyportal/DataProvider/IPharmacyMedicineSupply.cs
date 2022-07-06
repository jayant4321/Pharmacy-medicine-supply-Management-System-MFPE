using PharmacyMedicineSupplyportal.Model;
using System.Collections.Generic;

namespace PharmacyMedicineSupplyportal.DataProvider
{
    public interface IPharmacyMedicineSupply
    {
        public IEnumerable<PharmacyMedicine> GetPharmacyMedicinesSupply(List<MedicineDemand> med);
    }
}
