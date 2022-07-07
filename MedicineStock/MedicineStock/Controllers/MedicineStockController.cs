using MedicineStock.DataProvider;
using MedicineStock.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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
        [HttpGet("MedicineStockInformation")]
        public IActionResult MedicineStockInformation()
        {
            return Ok(MedicineDataProvider.GetList());
        }
    }
}
