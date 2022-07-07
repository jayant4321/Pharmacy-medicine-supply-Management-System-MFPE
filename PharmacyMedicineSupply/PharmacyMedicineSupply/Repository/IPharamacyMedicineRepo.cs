using PharmacyMedicineSupply.Model;
using System.Collections.Generic;

namespace PharmacyMedicineSupply.Repository
{
    public interface IPharamacyMedicineRepo
    {
        public IEnumerable<PharmacyMedicine> GetPharmacyMedicinesSupply(List<MedicineDemand> med);
    }
}
