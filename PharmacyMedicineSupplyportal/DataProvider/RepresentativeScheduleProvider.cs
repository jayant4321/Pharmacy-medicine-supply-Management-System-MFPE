using Newtonsoft.Json;
using PharmacyMedicineSupplyportal.Model;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;

namespace PharmacyMedicineSupplyportal.DataProvider
{
    public class RepresentativeScheduleProvider : IRepresentativeScheduleProvider
    {
        public List<RepSchedule> GetRepSchedule(DateTime startDate)
        {
            List<RepSchedule> list = new List<RepSchedule>();
            string BaseUrl = "https://localhost:44385/";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = new HttpResponseMessage();

                try
                {
                    response = client.GetAsync("RepSchedule/" + startDate.ToString("yyyy-MM-dd")).Result;
                }
                catch (Exception)
                {
                    response = null;
                }

                if (response != null)
                {
                    var objResponse = response.Content.ReadAsStringAsync().Result;
                    list = JsonConvert.DeserializeObject<List<RepSchedule>>(objResponse);
                    return list;
                }
                return list;
            }
        }
    }
}
