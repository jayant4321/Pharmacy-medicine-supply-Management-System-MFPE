using AuthorizationApi.Model;
using System.Collections.Generic;

namespace AuthorizationApi.DataProvider
{
    public interface IPharmacyDataProvider
    {
        public List<PharmacyMembers> GetList();
        public PharmacyMembers GetPharmacyMembers(PharmacyMembers Mem);

    }
}
