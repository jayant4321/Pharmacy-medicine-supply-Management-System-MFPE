using AuthorizationApi.Model;
using System.Collections.Generic;
using System.Linq;

namespace AuthorizationApi.DataProvider
{
    public class PharmacyDataProvider:IPharmacyDataProvider
    {
        private static List<PharmacyMembers> List = new List<PharmacyMembers>()
        {
            new PharmacyMembers{Username="Jayant",Password="Jayant@123"},
            new PharmacyMembers{Username="Nafisa",Password="Nafisa@123"},
            new PharmacyMembers{Username="Sanket",Password="Sanket@123"},
            new PharmacyMembers{Username="Subham",Password="Subham@123"}
        };

        public List<PharmacyMembers> GetList()
        {
            return List;
        }

        public PharmacyMembers GetPharmacyMembers(PharmacyMembers Mem)
        {
            List<PharmacyMembers> rList = GetList();
            PharmacyMembers pharMem = rList.FirstOrDefault(dat => dat.Username == Mem.Username && dat.Password == Mem.Password);
            return pharMem;
        }
    }
}
