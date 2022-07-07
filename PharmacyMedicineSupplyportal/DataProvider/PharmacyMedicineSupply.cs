using Newtonsoft.Json;
using PharmacyMedicineSupplyportal.Model;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace PharmacyMedicineSupplyportal.DataProvider
{
    public class PharmacyMedicineSupply : IPharmacyMedicineSupply
    {
        public IEnumerable<PharmacyMedicine> GetPharmacyMedicinesSupply(List<MedicineDemand> med)
        {
            IEnumerable<PharmacyMedicine> list = new List<PharmacyMedicine>();
            //string BaseUrl = "https://localhost:44316/api/PharmacySupply";
            string BaseUrl = "https://localhost:5004/api/PharmacySupply";
            var temp = JsonConvert.SerializeObject(med);
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(BaseUrl),
                Content = new StringContent(temp, Encoding.UTF8, "application/json")
            };
            using (var client = new HttpClient())
            {
                //client.BaseAddress = new Uri(BaseUrl);
                //client.DefaultRequestHeaders.Clear();
                //client.Body
                //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = new HttpResponseMessage();

                try
                {
                    response = client.SendAsync(request).Result;
                }
                catch (Exception)
                {
                    response = null;
                }

                if (response != null)
                {
                    var objResponse = response.Content.ReadAsStringAsync().Result;
                    list = JsonConvert.DeserializeObject<List<PharmacyMedicine>>(objResponse);
                    return list;
                }
                return list;
            }
        }
    }
}
