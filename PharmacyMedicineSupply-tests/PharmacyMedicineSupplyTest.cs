using Moq;
using NUnit.Framework;
using PharmacyMedicineSupply.DataProvider;
using PharmacyMedicineSupply.Model;
using System.Collections.Generic;

namespace PharmacyMedicineSupply_tests
{
    internal class PharmacyMedicineSupplyTest
    {
        string token = "alphabeta";
        List<string> pharmacyName = new List<string>();
        List<Medicine> medicines = new List<Medicine>();

        [TestCase]
        public void GetPharmacyNames_Returns_Object()
        {
            Mock<IPharmacyData> mock = new Mock<IPharmacyData>();
            mock.Setup(p => p.GetPharmacyName()).Returns(pharmacyName);
            PharmacyData pro = new PharmacyData();

            var penCred = pro.GetPharmacyName();

            Assert.IsNotNull(penCred);
        }

        [TestCase]
        public void GetList_Returns_Object()
        {
            Mock<IPharmacyData> mock = new Mock<IPharmacyData>();
            mock.Setup(p => p.GetList(token)).Returns(medicines);
            PharmacyData pro = new PharmacyData();

            var penCred = pro.GetList(token);

            Assert.IsNotNull(penCred);
        }


    }
}
