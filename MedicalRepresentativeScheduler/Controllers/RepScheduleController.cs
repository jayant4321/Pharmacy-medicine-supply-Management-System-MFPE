using MedicalRepresentativeScheduler.DataProvider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MedicalRepresentativeScheduler.Controllers
{
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
        [Authorize]
        [HttpGet("RepSchedule/{startDate}")]
        public IActionResult Get(string startDate)
        {
            try
            {
                var date = Convert.ToDateTime(startDate);
                DateTime now = DateTime.Now;
                if (now > date)
                    return NotFound();
                var token = HttpContext.Request.Headers["Authorization"];
                return Ok(medicalRepresentativeSchedule.GetSchedule(date,token));
            }
            catch(Exception)
            {
                return Ok(null);
            }
        }
    }
}
