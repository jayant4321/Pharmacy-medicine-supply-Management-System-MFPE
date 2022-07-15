using PharmacyMedicineSupply.DataProvider;
using PharmacyMedicineSupply.Model;
using System.Collections.Generic;
using System.Linq;
using System;
namespace PharmacyMedicineSupply.Repository
{
    public class PharamacyMedicineRepo:IPharamacyMedicineRepo
    {
        private IPharmacyData Data;
        public PharamacyMedicineRepo()
        {
            Data = new PharmacyData();
        }
        public IEnumerable<PharmacyMedicine> GetPharmacyMedicinesSupply(List<MedicineDemand> med,string token)
        {
            List<Medicine> AllMed = Data.GetList(token);
            List<string> PharmName = Data.GetPharmacyName();
            var Pharm = AllMed.Where(b => med.Any(a => a.Medicine.ToLower().Trim().Replace(" ","") == b.Name.ToLower().Trim().Replace(" ","") && a.DemandCount>b.NumberOfTabletsInStock));
            var PharmMed=Pharm.SelectMany(me => PharmName, (n, k) => new PharmacyMedicine
                {
                    PharmacyName=k,
                    MedicineName=n.Name,
                    SupplyCount=n.NumberOfTabletsInStock/5
                });
            var Phar = med.Where(b => AllMed.Any(a => b.Medicine.ToLower().Trim().Replace(" ", "") == a.Name.ToLower().Trim().Replace(" ", "") && b.DemandCount < a.NumberOfTabletsInStock));
            var PharmMe = Phar.SelectMany(me => PharmName, (n, k) => new PharmacyMedicine
            {
                PharmacyName = k,
                MedicineName = n.Medicine,
                SupplyCount = n.DemandCount / 5
            });
            var FinalPhar = PharmMed.Concat(PharmMe);
            return FinalPhar;
        }
    }
}
