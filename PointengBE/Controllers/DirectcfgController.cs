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

    public class DirectcfgController : ControllerBase
    {
        readonly DataWithErros action = new();

        //private readonly IdirctInterface _Idirct;
        //public DirectcfgController(IdirctInterface Idirct)
        //{
        //    _Idirct = Idirct;
        //}
        private readonly IdirctInterface? _Idirect;
        public DirectcfgController(IdirctInterface idirect)
        {

            _Idirect = idirect;
        }

        [HttpPost("AddDirect")]
        public async Task<IActionResult> AddDirectAsync(DirConfigBinding _DirectConfig)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var AddedDirectcfg = await _Idirect.AddDirectCfg(_DirectConfig, User);
            if (string.IsNullOrEmpty(action.ErrorMessage))
            {
                return Ok(AddedDirectcfg);
            }
            else
            {
                return BadRequest(new { action.ErrorMessage });
            }
        }
        [HttpDelete("DeleteDirect")]
        public async Task<IActionResult> DeleteDirectAsync(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var DeletedDirectcfg = await _Idirect.DeleteDirectCfg(id, User);
            if (string.IsNullOrEmpty(action.ErrorMessage))
            {
                return Ok(DeletedDirectcfg);
            }
            else
            {
                return BadRequest(new { action.ErrorMessage });
            }
        }
        [HttpGet("GetMonthlist")]
        public IActionResult GetmonthAllAsync()
        {
            var plansmonth =  _Idirect.Getallmonth();
            return Ok(plansmonth);
        }
        [HttpGet("GetPlanlistid")]
        public IActionResult GetidbymonthAsync(DateTime month)
        {
            var plansid =  _Idirect.GetallPlansId(month);
            return Ok(plansid);
        }
        [HttpGet("GetDirectCfg")]
        public IActionResult GetDirectCfg()
        {
            var GetDirect = _Idirect.Getall();
            return Ok(GetDirect.Result);
        }
        [HttpGet("GetDirectDetails")]
        public IActionResult GetdirectById(Guid id)
        {
            var directDetailds =  _Idirect.GetById(id);

            return Ok(directDetailds);

        }
    }
}
