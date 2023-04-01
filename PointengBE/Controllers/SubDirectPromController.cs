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
    public class SubDirectPromController : ControllerBase
    {
        readonly DataWithErros action = new();
        private readonly ISubDirectPromInterface? _ISubdirect;
        public SubDirectPromController(ISubDirectPromInterface iSubdirect)
        {
            _ISubdirect = iSubdirect;
        }
        [HttpGet("GetregionProm")]

        public IActionResult GetReionList()
        {
            var data = _ISubdirect.GetRegionProm();
            return Ok(data.Result);
        }

        [HttpGet("GetcityProm")]

        public IActionResult GetcityList(string REGION)
        {
            var data = _ISubdirect.GetCityProm(REGION);
            return Ok(data.Result);
        }
        [HttpGet("GetzoneProm")]
        public IActionResult GetzoneList(string CITY)
        {
            var data = _ISubdirect.GetZoneProm(CITY);
            return Ok(data.Result);
        }
        [HttpGet("GetareaProm")]
        public IActionResult GetareaList(string ZONE)
        {
            var data = _ISubdirect.GetAreaProm(ZONE);
            return Ok(data.Result);

        }
        [HttpGet("GetsubareaProm")]
        public IActionResult Getsubarealist(string AREA)
        {
            var data = _ISubdirect.GetSubAreaProm(AREA);
            return Ok(data.Result);
        }
        [HttpGet("Getsdcode")]
        public IActionResult Getsubdealerlist(string SUBAREA)
        {
            var data = _ISubdirect.GetSubDealerProm(SUBAREA);
            return Ok(data.Result);
        }
        [HttpGet("GetallmonthsProm")]
        public IActionResult Getallmonthlist()
        {
            var data = _ISubdirect.GetallmonthProm();
            return Ok(data.Result);
        }
        [HttpGet("GetalldirectProm")]

        public IActionResult GetalldirectConfigbyid(DateTime month)
        {
            var data = _ISubdirect.GetallDirectConfigProm(month);
            return Ok(data.Result);
        }
        [HttpGet("GetalldirectbyidProm")]
        public IActionResult GetalldirectConfigbyid(Guid Id)
        {
            var data = _ISubdirect.GetallDirectConfigbyidProm(Id);
            return Ok(data.Result);
        }

        [HttpPost("AddSubDirectProm")]

        public async Task<IActionResult> AddDirectAsync(subDirConfigBinding _subDirectConfig)
        {
            var AddedsubDirectcfg = await _ISubdirect.AddsubDirectCfgProm(_subDirectConfig, User);
            if (string.IsNullOrEmpty(action.ErrorMessage))
            {
                return Ok(AddedsubDirectcfg);
            }
            else
            {
                return BadRequest(new { AddedsubDirectcfg.ErrorMessage });
            }
        }
        [HttpGet("GetallSubDirectProm")]

        public IActionResult GetAllsubDirect()
        {
            var AddedsubDirectcfg = _ISubdirect.GetallsubDirectConfigProm();
            if (string.IsNullOrEmpty(AddedsubDirectcfg.ErrorMessage))
            {
                return Ok(AddedsubDirectcfg.Result);
            }

            else
            {
                return BadRequest(new { AddedsubDirectcfg.ErrorMessage });
            }
        }
        [HttpDelete("deleteRangeidProm")]

        public IActionResult DeleteRangeId(int subConfigId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var deleterangID = _ISubdirect.deleteRangeIdProm(subConfigId, User);
            if (string.IsNullOrEmpty(action.ErrorMessage))
            {
                return Ok(deleterangID);
            }
            else
            {
                return BadRequest(new { action.ErrorMessage });
            }
        }

        [HttpGet("GetallSubdirectSubidProm")]

        public IActionResult GetsubConfigSubId(int SubConfigId)
        {
            var data = _ISubdirect.GetallsubConfigSubIdProm(SubConfigId);
            return Ok(data.Result);
        }


    }
}
