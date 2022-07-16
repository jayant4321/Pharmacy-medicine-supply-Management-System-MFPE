using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuthorizationApi.DataProvider;
using AuthorizationApi.Model;
using Moq;
using NUnit.Framework;

namespace AuthorizationApi_tests
{
    internal class AuthorizationApiTest
    {
        List<PharmacyMembers> user = new List<PharmacyMembers>();

        [SetUp]
        public void Setup()
        {
            user = new List<PharmacyMembers>()
            {
                new PharmacyMembers{Username = "Jayant",Password = "Jayant@123"}
            };
        }

        [TestCase("Jayant", "Jayant@123")]
        public void GetPharmacyMembers_Returns_Object(string uname, string pass)
        {
            Mock<IPharmacyDataProvider> mock = new Mock<IPharmacyDataProvider>();
            mock.Setup(p => p.GetList()).Returns(user);
            PharmacyDataProvider pro = new PharmacyDataProvider();
            PharmacyMembers cred = new PharmacyMembers { Username = uname, Password = pass };

            var penCred = pro.GetPharmacyMembers(cred);

            Assert.IsNotNull(penCred);
        }

        [TestCase("user3", "user3")]
        public void GetPharmacyMembers_Returns_Null(string uname, string pass)
        {

            Mock<IPharmacyDataProvider> mock = new Mock<IPharmacyDataProvider>();
            mock.Setup(p => p.GetList()).Returns(user);
            PharmacyDataProvider pro = new PharmacyDataProvider();
            PharmacyMembers cred = new PharmacyMembers { Username = uname, Password = pass };

            var penCred = pro.GetPharmacyMembers(cred);

            Assert.IsNull(penCred);

        }
    }
}
