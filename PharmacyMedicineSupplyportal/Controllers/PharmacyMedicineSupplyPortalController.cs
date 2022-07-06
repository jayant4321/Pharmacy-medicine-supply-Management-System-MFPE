using Microsoft.AspNetCore.Mvc;
using PharmacyMedicineSupplyportal.DataProvider;
using PharmacyMedicineSupplyportal.DbContext;
using PharmacyMedicineSupplyportal.Model;
using System;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PharmacyMedicineSupplyportal.Controllers
{
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

        [HttpGet("MedicineStock")]
        public IActionResult GetMedicineList()
        {
            var list = medicineStock.GetMedicineList();
            return Ok(list);
        }
        
        [HttpGet("RepShcedule/{startDate}")]
        public IActionResult GetRepSchedule(DateTime startDate)
        {
            var repSchedule = representativeSchedule.GetRepSchedule(startDate);
            return Ok(repSchedule);
        }

        [HttpGet("MedicineSupply")]
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
