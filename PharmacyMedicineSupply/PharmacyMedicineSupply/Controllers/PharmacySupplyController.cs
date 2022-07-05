using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PharmacyMedicineSupply.Model;
using PharmacyMedicineSupply.Repository;
using System.Collections.Generic;

namespace PharmacyMedicineSupply.Controllers
{
    [EnableCors("MyCorsPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class PharmacySupplyController : ControllerBase
    {
        public PharamacyMedicineRepo Pharm;
        public PharmacySupplyController()
        {
            Pharm = new PharamacyMedicineRepo();
        }
        [HttpGet]
        public IEnumerable<PharmacyMedicine> PharmacySupply([FromBody]List<MedicineDemand> med)
        {
            IEnumerable<PharmacyMedicine> AllMed = Pharm.GetPharmacyMedicinesSupply(med);
            return AllMed;
        }
    }
}
