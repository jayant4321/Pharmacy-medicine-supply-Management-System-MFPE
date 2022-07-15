using MedicineStock.DataProvider;
using MedicineStock.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
namespace MedicineStock.Controllers
{
    [Route("")]
    [ApiController]
    public class MedicineStockController : ControllerBase
    {
        private IMedicineDataProvider MedicineDataProvider;
        public MedicineStockController()
        {
            MedicineDataProvider = new MedicineDataProvider();
        }
        [Authorize]
        [HttpGet("MedicineStockInformation")]
        public IActionResult MedicineStockInformation()
        {
            try
            {
                return Ok(MedicineDataProvider.GetList());
            }
            catch(Exception)
            {
                return null;
            }
        }
    }
}
