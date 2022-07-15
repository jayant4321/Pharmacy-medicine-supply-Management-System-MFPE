using MedicineStock.DataProvider;
using MedicineStock.Model;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace MedicineStock_tests
{
    [TestFixture]
    public class MedicineStockTests
    {

        List<Medicine> medicines = new List<Medicine>();


        [TestCase]
        public void GetPharmacyMembers_Returns_Object()
        {
            Mock<IMedicineDataProvider> mock = new Mock<IMedicineDataProvider>();
            mock.Setup(p => p.GetList()).Returns(medicines);
            MedicineDataProvider pro = new MedicineDataProvider();

            var penCred = pro.GetList();

            Assert.IsNotNull(penCred);
        }

        [TestCase]
        public void GetAllMedicineStockReturnsListOfMedicineStock()
        {
            MedicineDataProvider med = new MedicineDataProvider();
            var result = med.GetList();
            Assert.IsNotNull(result);
        }
    }
}