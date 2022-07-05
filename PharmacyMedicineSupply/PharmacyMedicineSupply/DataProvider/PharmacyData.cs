using PharmacyMedicineSupply.Model;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Net.Http;
using Newtonsoft.Json;

namespace PharmacyMedicineSupply.DataProvider
{
    public class PharmacyData:IPharmacyData
    {
        public List<string> Data = new List<string>() {"Pharmacy1","Pharmacy2","Pharmacy3","Pharmacy4","Pharmacy5"};
       
        public List<Medicine> GetList()
        {
            List<Medicine> list = new List<Medicine>();
            string BaseUrl = "https://localhost:5001/";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = new HttpResponseMessage();

                try
                {
                    response = client.GetAsync("MedicineStockInformation").Result;
                }
                catch (Exception)
                {
                    response = null;
                }

                if (response != null)
                {
                    var objResponse = response.Content.ReadAsStringAsync().Result;
                    list = JsonConvert.DeserializeObject<List<Medicine>>(objResponse);
                    return list;
                }
                return list;
            }
        }

        public List<string> GetPharmacyName()
        {
            return Data;
        }
    }
}
