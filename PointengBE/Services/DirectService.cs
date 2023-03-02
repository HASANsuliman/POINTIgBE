using Microsoft.EntityFrameworkCore;
using PointengBE.Models;
using PointengBE.Models.Context;
using PointengBE.Models.DataBinding;
using PointengBE.Services.Interfaaces;
using System.Security.Claims;

namespace PointengBE.Services
{
    public class DirectService : IdirctInterface
    {
        protected PointingContext? _context;
        public DirectService(PointingContext context)
        {
            _context = context;


        }
        public async Task<DataWithErros> AddDirectCfg(DirConfigBinding dentity, ClaimsPrincipal user)
        {

            DataWithErros data = new();
            var name = user.Identity.Name;
            var existconfig = _context.DirectConfigs.Where(x => x.PlanId == dentity.PlanId).FirstOrDefault();
            if (existconfig == null)
            {
                int Index = 0;
                foreach (var elem in dentity.configs)
                {
                    DirectConfig dirct = new(dentity.PlanId, dentity.Month, elem.RangeFrom, elem.RangeTo, elem.Points, name);
                    if (Index == 0)
                    {
                        if (elem.RangeFrom != 0)
                        {
                            data.Result = null;
                            data.ErrorMessage = "Error: First RangeFrom must start With 0";
                            return data;
                        }
                    }
                    else
                    {
                        if (elem.RangeFrom > elem.RangeTo)
                        {
                            data.Result = null;
                            data.ErrorMessage = "Error: RangeTo must be greater than RangeFrom in Confige " + (Index + 1);
                            return data;
                        }
                        else
                        {
                            if (elem.RangeFrom != dentity.configs[Index - 1].RangeTo + 1)
                            {
                                data.Result = null;
                                data.ErrorMessage = "Error: RangeFrom in Confige " + (Index + 1) + "     Must start with " + (dentity.configs[Index - 1].RangeTo + 1);
                                return data;
                            }
                        }
                    }
                    Index++;
                    dirct.DateEntry = DateTime.Now.ToString();
                    dirct.DateDeleted = null;
                    await _context.AddAsync(dirct);
                }
                dentity.UserName= user.Identity.Name;
                dentity.DateEntry = DateTime.Now.ToString();
                await _context.SaveChangesAsync();
                data.Result = dentity;
                data.ErrorMessage = null;
                return data;
            }
            else
            {
                data.Result = null;
                data.ErrorMessage = "Error: You Can Not Add Config For " + dentity.Month.ToString("MM-yyyy") + " Because It's Already Exist";
                return data;
            }
        }
        public async Task<DataWithErros> DeleteDirectCfg(Guid Id, ClaimsPrincipal user)
        {
            var name = user.Identity.Name;
            DataWithErros data = new();
            var existconfig = await _context.DirectConfigs.Where(x => x.PlanId == Id).FirstOrDefaultAsync();
            var existsubconfig = await _context.SubDirectConfigs.Where(x => x.PlanId == Id).ToListAsync(); ;
            var existcfg = await _context.DirectConfigs.Where(x => x.PlanId == Id).ToListAsync();
            if (existconfig != null)
            {
                if (existconfig.Month.Year < DateTime.Now.Year && existconfig.Month.Month < DateTime.Now.Month)
                {
                    data.Result = null;
                    data.ErrorMessage = "You Are Not Allowed To Delete This Configs";
                    return data;
                }
                foreach (var id in existcfg)
                {
                    if (id != null)
                    {
                        _context.DirectConfigs.Remove(id);
                        await _context.SaveChangesAsync();
                    }
                }
                foreach (var item in existsubconfig)
                {
                    if (item != null)
                    {
                        _context.SubDirectConfigs.Remove(item);
                        await _context.SaveChangesAsync();
                    }
                }
                LogHistory logHistory = new( "Plan", existconfig.Month, name, DateTime.Now);
                await _context.LogHistories.AddAsync(logHistory);
                await _context.SaveChangesAsync();
                data.Result = existcfg;
                data.ErrorMessage = null;
                return data;
            }
            data.Result = null;
            data.ErrorMessage = " Configration Not Deleted because It's not exist";
            return data;
        }

        public DataWithErros Getall()
        {
            DataWithErros data = new();
            var existcfgall = _context.DirectConfigs.Select(o => new { o.PlanId, o.Month, o.UserName, o.DateEntry }).Distinct().OrderBy(x => x.Month);
            //var xz = _context.DirectConfigs.OrderBy(o => o.PlanId);
            //foreach( var item in xz)
            //{
            //    var y = _context.DirectConfigs.Where(x => x.PlanId == item.PlanId);
            //    var z2 = y.Count();
            //}
            if (existcfgall == null)
            {
                data.Result = null;
                data.ErrorMessage = "NoData";
                return data;
            }

            data.Result = existcfgall;
            data.ErrorMessage = null;
            return data;
        }
        public DataWithErros Getallmonth()
        {
            DataWithErros data = new();
            var planlist =  _context.Plan.Select(x => x.Month).OrderBy(x=>x.Month).ToList();
            data.Result = planlist;
            data.ErrorMessage = null;
            return data;
        }

        public DataWithErros GetallPlansId(DateTime month)
        {
            DataWithErros data = new();

            var planlist = _context.Plan.Where(x => x.Month == month).Select(x => x.Id).ToList();
            data.Result = planlist;
            data.ErrorMessage = null;
            return data;
        }

        public DataWithErros GetById(Guid Id)
        {
            DataWithErros data = new();
            var dirctDetail =  _context.DirectConfigs.Where(x => x.PlanId == Id).ToList();
            data.Result = dirctDetail;
            data.ErrorMessage = null;
            return data;
        }

       
    }
}
