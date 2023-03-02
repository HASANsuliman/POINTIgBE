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
    public class PlanController : ControllerBase
    {
        private readonly DataWithErros _action = new();
        private readonly IPlanInterface? _Iplan;
        public PlanController( IPlanInterface? iplan)
        {
            
            _Iplan = iplan;
        }
        [HttpGet("GetPlans")]
        public  IActionResult GetAllAsync()
        {
            var plans = _Iplan.GetAllPlans();
            return Ok(plans.Result);
        }
        [HttpPost("AddPlan")]
        public async Task<IActionResult> AddPlanAsync(Plan _plan)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var Addedplans = await _Iplan.AddPlan(_plan, User);
            if (string.IsNullOrEmpty(_action.ErrorMessage))
            {
                return Ok(Addedplans);
            }
            else
            {
                return BadRequest(new { Addedplans.ErrorMessage });
            }
        }
        [HttpPut("UpdatePlan")]
        public async Task<IActionResult> UpdaePlanAsync(Plan _plan)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var updateedplans = await _Iplan.UpdatePlan(_plan, User);

            if (string.IsNullOrEmpty(updateedplans.ErrorMessage))
            {
                return Ok(updateedplans);
            }
            else
            {
                return BadRequest(new { updateedplans.ErrorMessage });
            }
        }
   
        [HttpDelete("DeletePlan")]
        public async Task<IActionResult> DeletPlanAsync(Guid Id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var Deletedplans = await _Iplan.DeletePlan(Id, User);
            if (string.IsNullOrEmpty(Deletedplans.ErrorMessage))
            {
                return Ok(Deletedplans);
            }
            else
            {
                return BadRequest(new { Deletedplans.ErrorMessage });
            }

        }
        [HttpGet("getPlanByid")]
        public IActionResult UpdaePlanAsync(Guid Id)
        {
            var planbyid =  _Iplan.GetPlanById(Id);
            return Ok(planbyid);
        }
        [HttpGet("getPlanByMonth")]
        public IActionResult GetPlanBtMonth(string entity)
        {
            var planbymonth = _Iplan.GetPlanBymonth(entity);
            return Ok(planbymonth);
        }
    }
}
