using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PharmacyMedicineSupplyportal.DatabaseContext;
using PharmacyMedicineSupplyportal.DataProvider;
using PharmacyMedicineSupplyportal.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PharmacyMedicineSupplyportal.Controllers
{
    [EnableCors("MyCorsPolicy")]
    [Route("PharmacyMedicineSupplyPortal")]
    [ApiController]
    public class PharmacyMedicineSupplyPortalController : ControllerBase
    {
        // GET: api/<PharmacyMedicineSupplyPortalController>
        private readonly IMedicineStockProvider medicineStock;
        private readonly IRepresentativeScheduleProvider representativeSchedule;
        private readonly IPharmacyMedicineSupply supply;

        private readonly ApplicationDbContext _context;



        public PharmacyMedicineSupplyPortalController(ApplicationDbContext context)
        {
            this.medicineStock = new MedicineStockProvider();
            this.representativeSchedule = new RepresentativeScheduleProvider();
            this.supply = new PharmacyMedicineSupply();
            _context = context;
        }


        [AllowAnonymous]
        [HttpPost("PharmacyAuth")]
        public async Task<IActionResult> Login([FromBody] PharmacyMembers userLogin)
        {
            string BaseUrl = "https://localhost:5012/api/PharmacyAuth";
            using(var client=new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                var content = new StringContent(JsonConvert.SerializeObject(userLogin), Encoding.UTF8, "application/json");
                using(HttpResponseMessage response=await client.PostAsync("",content))
                {
                    var responsecontent = response.Content.ReadAsStringAsync().Result;
                    response.EnsureSuccessStatusCode();
                    return Ok(responsecontent);
                }
            }
        }
        [Authorize]
        [HttpGet("MedicineStock")]
        public IActionResult GetMedicineList()
        {
            var list = medicineStock.GetMedicineList();
            return Ok(list);
        }
        
        [Authorize]
        [HttpGet("RepShcedule/{startDate}")]
        public IActionResult GetRepSchedule(DateTime startDate)
        {
            var repSchedule = representativeSchedule.GetRepSchedule(startDate);
            return Ok(repSchedule);
        }
        
        [Authorize]
        [HttpPost("MedicineSupply")]
        public IActionResult GetMedicineSupply([FromBody] List<MedicineDemand> med)
        {
            var medSupply = supply.GetPharmacyMedicinesSupply(med);
            var medSupplyList = medSupply.ToList();
            foreach(var medicineDemand in med)
            {
                var medicineList = medSupplyList.FindAll(m => m.MedicineName == medicineDemand.Medicine);
                foreach(var medicine in medicineList)
                {
                    var medicineInDb = _context.PharmacyMedicineDemandSupplies.SingleOrDefault(m => (m.MedicineName == medicine.MedicineName && m.PharmacyName == medicine.PharmacyName));
                    if(medicineInDb != null)
                    {
                        medicineInDb.MedicineName = medicine.MedicineName;
                        medicineInDb.PharmacyName = medicine.PharmacyName;
                        medicineInDb.SupplyCount = medicine.SupplyCount;
                        medicineInDb.DemandCount = medicineDemand.DemandCount;
                    }
                    else
                    {
                        var pharmacyMedicineDemandSupply = new PharmacyMedicineDemandSupply()
                        {
                            MedicineName = medicine.MedicineName,
                            PharmacyName = medicine.PharmacyName,
                            SupplyCount = medicine.SupplyCount,
                            DemandCount = medicineDemand.DemandCount
                        };
                        _context.PharmacyMedicineDemandSupplies.Add(pharmacyMedicineDemandSupply);

                    }
                    _context.SaveChanges();
                }
            }
            return Ok(medSupply);
        }

        
    }
}
