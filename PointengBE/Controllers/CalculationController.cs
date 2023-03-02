using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PointengBE.Models;
using PointengBE.Models.DataBinding;
using PointengBE.Services.Interfaaces;

namespace PointengBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Policy = "Admin")]

    public class CalculationController : ControllerBase
    {
        private readonly DataWithErros _action = new();
        private readonly ICalculationInterface? _Icalc;
        public CalculationController(ICalculationInterface? icalc)
        {
            _Icalc = icalc;
        }
        [HttpPost("AddCalc")]
        public async Task<IActionResult> AddCalculation(calc entity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var Addedcalc = await _Icalc.AddCalculationMain(entity);
            if (string.IsNullOrEmpty(_action.ErrorMessage))
            {
                return Ok(Addedcalc);
            }
            else
            {
                return BadRequest(new { Addedcalc.ErrorMessage });
            }
        }
        [HttpPost("AddCalcCond")]
        public async Task<IActionResult> AddCalculationCond(calc entity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var Addedcalccond = await _Icalc.AddCalculation(entity,User);
            if (string.IsNullOrEmpty(_action.ErrorMessage))
            {
                return Ok(Addedcalccond);
            }
            else
            {
                return BadRequest(new { Addedcalccond.ErrorMessage });
            }
        }

        [HttpGet("GetCalc")]
        public IActionResult GetDataCalc()
        {
            var Data = _Icalc.getDataCalculation();
            return Ok(Data.Result);
        }

        [HttpGet("GetCalcById")]
        public IActionResult GetdirectById(Guid id,string userName)
        {
            var directDetailds = _Icalc.GetCalculationById(id, userName);

            return Ok(directDetailds);

        }
        [HttpGet("GetSales")]
        public IActionResult GetSalesData()
        {
            var Data = _Icalc.GetSalesData();
            return Ok(Data.Result);
        }
        [HttpPost("GetSalesform")]
        public IActionResult SalesDataform(salesBinding sales)
        {
            var Data = _Icalc.SalesDataForm(sales);
            return Ok(Data.Result);
        }
        [HttpPost("AddCalcExcel")]
        public async Task<IActionResult> AddCalculationExcel(ExcelCalculation excelFileData)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var AddedcalcExcel = await _Icalc.AddCalculationExcel(excelFileData,User);
            if (string.IsNullOrEmpty(_action.ErrorMessage))
            {
                return Ok(AddedcalcExcel);
            }
            else
            {
                return BadRequest(new { AddedcalcExcel.ErrorMessage });
            }
        }

        [HttpGet("Getplan")]
        public IActionResult Getallmonthlist()
        {
            var data = _Icalc.Getallmonth();
            return Ok(data.Result);
        }
    }
}
