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
   // [Authorize(Policy = "Admin")]

    public class SubDirectController : ControllerBase
    {
        readonly DataWithErros action = new();

       
        private readonly ISubDirectInterface? _ISubdirect;
        public SubDirectController(ISubDirectInterface iSubdirect)
        {

            _ISubdirect = iSubdirect;
        }
        [HttpGet("Getregion")]

        public IActionResult GetReionList()
        {
            var data = _ISubdirect.GetRegion();
            return Ok(data.Result);
        }

        [HttpGet("Getcity")]

        public IActionResult GetcityList(string REGION)
        {
            var data = _ISubdirect.GetCity(REGION);
            return Ok(data.Result);
        }
        [HttpGet("Getzone")]
        public IActionResult GetzoneList(string CITY)
        {
            var data = _ISubdirect.GetZone(CITY);
            return Ok(data.Result);
        }
        [HttpGet("Getarea")]
        public IActionResult GetareaList(string ZONE)
        {
            var data = _ISubdirect.GetArea(ZONE);
            return Ok(data.Result);

        }
        [HttpGet("Getsubarea")]
        public IActionResult Getsubarealist(string AREA)
        {
            var data = _ISubdirect.GetSubArea(AREA);
            return Ok(data.Result);
        }
        [HttpGet("Getsdcode")]
        public IActionResult Getsubdealerlist(string SUBAREA)
        {
            var data = _ISubdirect.GetSubDealer(SUBAREA);
            return Ok(data.Result);
        }
        [HttpGet("Getallmonths")]
        public IActionResult Getallmonthlist()
        {
            var data = _ISubdirect.Getallmonth();
            return Ok(data.Result);
        }
        [HttpGet("Getalldirect")]

        public IActionResult GetalldirectConfigbyid(DateTime month)
        {
            var data = _ISubdirect.GetallDirectConfig(month);
            return Ok(data.Result);
        }
        [HttpGet("Getalldirectbyid")]
        public IActionResult GetalldirectConfigbyid(Guid Id)
        {
            var data = _ISubdirect.GetallDirectConfigbyid(Id);
            return Ok(data.Result);
        }

        [HttpPost("AddSubDirect")]

        public async Task<IActionResult> AddDirectAsync(subDirConfigBinding _subDirectConfig)
        {
            var AddedsubDirectcfg = await _ISubdirect.AddsubDirectCfg(_subDirectConfig, User);
            if (string.IsNullOrEmpty(action.ErrorMessage))
            {
                return Ok(AddedsubDirectcfg);
            }
            else
            {
                return BadRequest(new { AddedsubDirectcfg.ErrorMessage });
            }
        }
        [HttpGet("GetallSubDirect")]

        public IActionResult GetAllsubDirect()
        {
            var AddedsubDirectcfg = _ISubdirect.GetallsubDirectConfig();
            if (string.IsNullOrEmpty(AddedsubDirectcfg.ErrorMessage))
            {
                return Ok(AddedsubDirectcfg.Result);
            }

            else
            {
                return BadRequest(new { AddedsubDirectcfg.ErrorMessage });
            }
        }
        [HttpDelete("deleteRangeid")]

        public IActionResult DeleteRangeId(int subConfigId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var deleterangID = _ISubdirect.deleteRangeId(subConfigId, User);
            if (string.IsNullOrEmpty(action.ErrorMessage))
            {
                return Ok(deleterangID);
            }
            else
            {
                return BadRequest(new { action.ErrorMessage });
            }
        }

        [HttpGet("GetallSubdirectSubid")]

        public IActionResult GetsubConfigSubId(int SubConfigId)
        {
            var data = _ISubdirect.GetallsubConfigSubId(SubConfigId);
            return Ok(data.Result);
        }
    }
}
