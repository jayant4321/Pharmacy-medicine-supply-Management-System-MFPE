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
        
        public List<Medicine> GetMedicineList(string token)
        {
            List<Medicine> list = new List<Medicine>();
            //string BaseUrl = "https://localhost:44382/";
            //string BaseUrl = "https://localhost:5001/";
            //string BaseUrl = "http://20.241.250.46/";
            string BaseUrl = "http://20.241.228.249/";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("Authorization", token);
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
