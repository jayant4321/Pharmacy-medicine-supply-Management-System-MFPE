using System;
using MedicalRepresentativeScheduler.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace MedicalRepresentativeScheduler.DataProvider
{
    public class MedicineStockProvider : IMedicineStockProvider
    {
        
        public List<Medicine> GetMedicineList()
        {
            List<Medicine> list = new List<Medicine>();
            //string BaseUrl = "https://localhost:44382/";
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
                catch(Exception)
                {
                    response = null;
                }

                if(response != null)
                {
                    var objResponse = response.Content.ReadAsStringAsync().Result;
                    list = JsonConvert.DeserializeObject<List<Medicine>>(objResponse);
                    return list;
                }
                return list;
            }
        }
    }
}
