using MedicalRepresentativeScheduler.DataProvider;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MedicalRepresentativeScheduler.Controllers
{
    [EnableCors("MyCorsPolicy")]
    [Route("")]
    [ApiController]
    public class RepScheduleController : ControllerBase
    {
        public IMedicalRepresentativeSchedule medicalRepresentativeSchedule;

        public RepScheduleController()
        {
            medicalRepresentativeSchedule = new MedicalRepresentativeSchedule();
        }
        // GET: api/<RepScheduleController>
        [HttpGet("RepSchedule/{startDate}")]
        public IActionResult Get(string startDate)
        {
            var date = Convert.ToDateTime(startDate);
            return Ok(medicalRepresentativeSchedule.GetScedule(date));
            
        }

       
    }
}
