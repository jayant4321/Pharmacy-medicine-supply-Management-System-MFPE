using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PharmacyMedicineSupply.Model;
using PharmacyMedicineSupply.Repository;
using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Authorization;

namespace PharmacyMedicineSupply.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PharmacySupplyController : ControllerBase
    {
        public PharamacyMedicineRepo Pharm;
        public PharmacySupplyController()
        {
            Pharm = new PharamacyMedicineRepo();
        }
        [Authorize]
        [HttpGet]
        public IEnumerable<PharmacyMedicine> PharmacySupply([FromBody]List<MedicineDemand> med)
        {
            try
            {
                var token = HttpContext.Request.Headers["Authorization"];
                IEnumerable<PharmacyMedicine> AllMed = Pharm.GetPharmacyMedicinesSupply(med,token);
                if (AllMed == null)
                    return null;
                return AllMed;
            }
            catch(Exception)
            {
                return null;
            }
        }
    }
}
