using Microsoft.EntityFrameworkCore;
using PointengBE.Models;
using PointengBE.Models.Context;
using PointengBE.Models.DataBinding;
using PointengBE.Services.Interfaaces;
using System.Security.Claims;

namespace PointengBE.Services
{
    public class PlanService : IPlanInterface
    {
        protected PointingContext? _context;
        public PlanService(PointingContext? context)
        {
            _context = context;
        }
        public DataWithErros GetAllPlans()
        {
            DataWithErros Data = new();
            var PlanList = _context.Plan.OrderBy(x => x.Month).ToList();
            Data.Result = PlanList;
            Data.ErrorMessage = null;
            return Data;
        }
        public async Task<DataWithErros> AddPlan(Plan entity, ClaimsPrincipal user)
        {
            DataWithErros Data = new();
            var name = user.Identity.Name;
            var existPlan = await _context.Plan.Where(x => x.Month.Month == entity.Month.Month && x.Month.Year == entity.Month.Year).FirstOrDefaultAsync();
            entity.DateFrom = new DateTime(entity.Month.Year, entity.Month.Month, 01);
            entity.DateTo = new DateTime(entity.Month.Year, entity.Month.Month, DateTime.DaysInMonth(entity.Month.Year, entity.Month.Month));
            entity.UserName = name;
            entity.DateEntry = DateTime.Now.ToString();
            entity.UserUpdate = "--";
            entity.DateUpdated = "--";

            if (existPlan == null)
            {
                await _context.Plan.AddAsync(entity);
                await _context.SaveChangesAsync();
                Data.Result = entity;
                Data.ErrorMessage = null;
                return Data;
            }
            Data.Result = null;
            Data.ErrorMessage = "Plan Not Added Successfully Already exist";
            return Data;
        }
        public async Task<DataWithErros> UpdatePlan(Plan entity, ClaimsPrincipal user)
        {
            DataWithErros Data = new();
            var existPlan = await _context.Plan.Where(x => x.Id == entity.Id).FirstOrDefaultAsync();
            if (existPlan == null)
            {
                Data.Result = null;
                Data.ErrorMessage = "Plan That You want To update is not Exist";
                return Data;
            }
            if (existPlan.Month.Year < DateTime.Now.Year && existPlan.Month.Month < DateTime.Now.Month)
            {
                Data.Result = null;
                Data.ErrorMessage = "You Are Not Allowed To Modify  This Plan";
                return Data;
            }
            var name = user.Identity.Name;
            existPlan.PointPrice = entity.PointPrice;
            existPlan.MinValue = entity.MinValue;
            existPlan.UserUpdate = name;
            existPlan.DateUpdated = DateTime.Now.ToString();
            await _context.SaveChangesAsync();
            Data.Result = existPlan;
            Data.ErrorMessage = null;
            return Data;
        }
        public async Task<DataWithErros> DeletePlan(Guid Id, ClaimsPrincipal user)
        {
            DataWithErros Data = new();
            var name = user.Identity.Name;
            var existPlan = await _context.Plan.Where(x => x.Id == Id).FirstOrDefaultAsync();
            var existconfig = _context.DirectConfigs.Where(x => x.PlanId == Id);
            var existsubconfig = _context.SubDirectConfigs.Where(x => x.PlanId == Id);
            if (existPlan != null)
            {
                if (existPlan.Month.Year < DateTime.Now.Year && existPlan.Month.Month < DateTime.Now.Month)
                {
                    Data.Result = null;
                    Data.ErrorMessage = "You Are Not Allowed To Delete This Plan";
                    return Data;
                }

                foreach (var item in existconfig)
                {
                    if (existconfig != null)
                    {
                        _context.DirectConfigs.Remove(item);

                    }
                }
                foreach (var items in existsubconfig)
                {
                    if (existsubconfig != null)
                    {
                        _context.SubDirectConfigs.Remove(items);

                    }
                }
                _context.Plan.Remove(existPlan);
                LogHistory logHistory = new( "Plan", existPlan.Month, name, DateTime.Now);
                await _context.LogHistories.AddAsync(logHistory);
                await _context.SaveChangesAsync();
                Data.Result = existPlan;
                Data.ErrorMessage = null;
                return Data;
            }
            Data.Result = null;
            Data.ErrorMessage = "Plan Not Deleted";
            return Data;
        }
        public DataWithErros GetPlanById(Guid Id)
        {
            DataWithErros Data = new();
            var existPlans = _context.Plan.Where(x => x.Id == Id).FirstOrDefault();
            //   var existPlanss =  _context.Plan.Find(Id);
            Data.Result = existPlans;
            Data.ErrorMessage = null;
            return Data;
        }
        public DataWithErros GetPlanBymonth(string entity)
        {
            DataWithErros Data = new();
            var Price = _context.Plan.Where(cc => cc.Month.ToString().Substring(0,7)==entity).Select(x=>x.PointPrice)
                .FirstOrDefault();
            //   var existPlanss =  _context.Plan.Find(Id);
            Data.Result = Price;
            Data.ErrorMessage = null;
            return Data;
        }

    }
}
