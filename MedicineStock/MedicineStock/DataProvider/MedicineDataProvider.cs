using MedicineStock.Model;
using System;
using System.Collections.Generic;

namespace MedicineStock.DataProvider
{
    public class MedicineDataProvider:IMedicineDataProvider
    {
        private static readonly List<Medicine> List = new List<Medicine>()
        {
            new Medicine{Name="Augmentin 625 Duo Tablet",ChemicalComposition="Amoxycillin(500mg)," +
                "Clavulanic Acid(125mg)",TargetAilment="General",DateOfExpiry=new DateTime(2024,1,1),
                NumberOfTabletsInStock=5000},
            new Medicine{Name="Azithral 500 Tablet",ChemicalComposition="Azithromycin (500mg)",
                TargetAilment="General",DateOfExpiry=new DateTime(2025,1,1),
                NumberOfTabletsInStock=6000},
            new Medicine{Name="Ascoril LS Syrup",ChemicalComposition="Ambroxol (30mg),Levosalbutamol (1mg),Guaifenesin (50mg)",
                TargetAilment="General",DateOfExpiry=new DateTime(2026,1,1),
                NumberOfTabletsInStock=4000},
            new Medicine{Name="Avil 25 Tablet",ChemicalComposition="Pheniramine (25mg)",
                TargetAilment="General",DateOfExpiry=new DateTime(2025,1,1),
                NumberOfTabletsInStock=7000},
            new Medicine{Name="Cefixime 100 mg DT",ChemicalComposition="Cefixime proxefil DT",
                TargetAilment="Orthopedic",DateOfExpiry=new DateTime(2024,1,1),
                NumberOfTabletsInStock=4000},
            new Medicine{Name="Cefiza 100DT Tab",ChemicalComposition="Cefixime 100 MG",
                TargetAilment="Orthopedic",DateOfExpiry=new DateTime(2025,1,1),
                NumberOfTabletsInStock=6000},
            new Medicine{Name="Diclorut MR",ChemicalComposition="Chlorzoxazone,Diclofenac,Paracetamol",
                TargetAilment="Orthopedic",DateOfExpiry=new DateTime(2025,1,1),
                NumberOfTabletsInStock=5000},
              new Medicine{Name="ETOREM P TAB",ChemicalComposition="Etodolac(400 MG),Paracetamol(325 MG)",
                TargetAilment="Orthopedic",DateOfExpiry=new DateTime(2026,1,1),
                NumberOfTabletsInStock=6000},
              new Medicine{Name="Floxin",ChemicalComposition="Ofloxacin",
                TargetAilment="Gynaecology",DateOfExpiry=new DateTime(2025,1,1),
                NumberOfTabletsInStock=4000},
              new Medicine{Name="Vibramycin",ChemicalComposition="Doxycycline",
                TargetAilment="Gynaecology",DateOfExpiry=new DateTime(2024,1,1),
                NumberOfTabletsInStock=2000},
              new Medicine{Name="Acticlate",ChemicalComposition="Doxycycline",
                TargetAilment="Gynaecology",DateOfExpiry=new DateTime(2024,1,1),
                NumberOfTabletsInStock=4000},
        };
        public List<Medicine> GetList()
        {
            return List;
        }

    }
}
