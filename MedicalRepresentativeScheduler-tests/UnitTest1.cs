using MedicalRepresentativeScheduler;
using MedicalRepresentativeScheduler.DataProvider;
using MedicalRepresentativeScheduler.Models;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace MedicalRepresentativeScheduler_tests
{
     

    public class Tests
    {
        List<Medicine> medicines = new List<Medicine>();
        List<RepSchedule> representatives = new List<RepSchedule>();
       

        [TestCase("30 July 2020")]
        public void GetPharmacyNames_Returns_Object(DateTime schedule)
        {
            Mock<IMedicalRepresentativeSchedule> mock = new Mock<IMedicalRepresentativeSchedule>();

            mock.Setup(p => p.GetSchedule(schedule)).Returns(representatives);

            MedicalRepresentativeSchedule det = new MedicalRepresentativeSchedule();
            var sch = det.GetSchedule(schedule);

            Assert.That(sch, Is.Not.Null);
        }

        [TestCase]
        public void GetMedicineStock()
        {
            Mock<IMedicineStockProvider> mock = new Mock<IMedicineStockProvider>();
            mock.Setup(p => p.GetMedicineList()).Returns(medicines);
            MedicineStockProvider pro = new MedicineStockProvider();

            var penCred = pro.GetMedicineList();

            Assert.IsNotNull(penCred);
        }

        

    }
}


