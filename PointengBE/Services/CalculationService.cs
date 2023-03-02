using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PointengBE.Models;
using PointengBE.Models.Context;
using PointengBE.Models.DataBinding;
using PointengBE.Services.Interfaaces;
using System.Security.Claims;

namespace PointengBE.Services
{
    public class CalculationService : ICalculationInterface
    {
        protected PointingContext? _context;
        public CalculationService(PointingContext? context)
        {
            _context = context;
        }
        public async Task<DataWithErros> AddCalculationMain(calc entity)
        {
            DataWithErros data = new();

            string query = "UPDATE [Sales]  SET [Point] = (SELECT [Points]  from [DirectConfigs] WHERE [sales].ACTIVEANDHAVECALL=1  ";
            query += $@" and [sales].MONTH = '{entity.Month}' and  SUBSTRING(CONVERT(varchar, [DirectConfigs].Month, 120), 1, 7)='{entity.Month}' ";
            query += "and [Sales].FIRST_RECHARGE>=[DirectConfigs].RangeFrom and [Sales].FIRST_RECHARGE<=[DirectConfigs].RangeTo  )";
            _context.Database.ExecuteSqlRaw(query);
            //var y = _context.Sales.ToList();
            //foreach (var item in y)
            //{
            //    item.Point = await _context.DirectConfigs.Where
            //       (x => x.Month.Year == entity.Month.Year && x.Month.Month == entity.Month.Month &&
            //       item.DAY.Year==entity.Month.Year &&  item.DAY.Month == entity.Month.Month &&
            //       item.DAY.Day>=1 && item.DAY.Day<=5 &&
            //       item.FIRST_RECHARGE >= x.RangeFrom && item.FIRST_RECHARGE <= x.RangeTo &&
            //       item.ACTIVEANDHAVECALL==1)
            //        .Select(x => x.Points).FirstOrDefaultAsync();
            //}
            // _context.Entry(y).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            data.Result = entity;
            data.ErrorMessage = null;
            return data;
        }
        public async Task<DataWithErros> AddCalculation(calc entity, ClaimsPrincipal user)
        {
            DataWithErros data = new();
            var saleData = await _context.Sales.Where(x=>x.MONTH==entity.Month && x.ACTIVEANDHAVECALL==1).ToListAsync();
            string query = "UPDATE   [Sales]  SET [Extrapoint] = (SELECT  [Extrapoints]  from [SubDirectConfigs] WHERE [sales].ACTIVEANDHAVECALL=1 and SD_SUBTYPE= 'Subdealer'  ";
            query += $@"and [sales].MONTH = '{entity.Month}' and  SUBSTRING(CONVERT(varchar, [SubDirectConfigs].Month, 120), 1, 7)='{entity.Month}'  ";
            query += "and [Sales].FIRST_RECHARGE>=[SubDirectConfigs].RangeFrom and [Sales].FIRST_RECHARGE<=[SubDirectConfigs].RangeTo and  ";
            query += "DATENAME( DAY,[Sales].DAY)>=DATENAME(day,[SubDirectConfigs].DateFrom) and DATENAME( DAY,[Sales].DAY)<=DATENAME( day,[SubDirectConfigs].DateTo)  )";
            _context.Database.ExecuteSqlRaw(query);
            await _context.SaveChangesAsync();
            // var existClaculation = _context.Calculations.Where(xc => xc.Plan.Month == entity.Month.Month && xc.Plan.Year == entity.Month.Year).FirstOrDefault();
            foreach (var item in saleData)
            {
                var condata = _context.SubDirectConfigs.Where(cc => item.DAY.Date >= cc.DateFrom.Date && item.DAY.Date <= cc.DateTo.Date
                   && item.FIRST_RECHARGE >= cc.RangeFrom && item.FIRST_RECHARGE <= cc.RangeTo && item.REGION != "All"&&  cc.Month.ToString().Substring(0,7)==entity.Month);
                if (condata != null)
                {
                    foreach (var x in condata)
                    {
                        if (x.REGION == item.REGION && x.CITY == "All" && x.ZONE == "All" && x.AREA == "All" && x.SUBAREA == "All" && x.SUBDEALER == "All")
                        {
                            item.Extrapoint = x.ExtraPoints;
                        }

                        if (x.CITY == item.CITY && x.ZONE == "All" && x.AREA == "All" && x.SUBAREA == "All" && x.SUBDEALER == "All")
                        {
                            item.Extrapoint = x.ExtraPoints;

                        }

                        if (x.ZONE == item.ZONE && x.AREA == "All" && x.SUBAREA == "All" && x.SUBDEALER == "All")
                        {
                            item.Extrapoint = x.ExtraPoints;

                        }
                        if (x.AREA == item.AREA && x.SUBAREA == "All" && x.SUBDEALER == "All")
                        {
                            item.Extrapoint = x.ExtraPoints;

                        }
                        if (x.SUBAREA == item.SUBAREA && x.SUBDEALER == "All")
                        {
                            item.Extrapoint = x.ExtraPoints;

                        }

                        if (x.SUBDEALER == item.SD_CODE && x.REGION == item.REGION && x.CITY == item.CITY && x.ZONE == item.ZONE && x.AREA == item.AREA && x.SUBAREA == item.SUBAREA)
                        {
                            item.Extrapoint = x.ExtraPoints;

                        }

                        if (item.Extrapoint == 0 || item.Extrapoint == null)
                        {
                            var suv = _context.SubDirectConfigs.Where(x => item.DAY.Date >= x.DateFrom.Date && item.DAY.Date <= x.DateTo.Date
                                      && item.FIRST_RECHARGE >= x.RangeFrom && item.FIRST_RECHARGE <= x.RangeTo && x.REGION == "All");
                            item.Extrapoint = await suv.Select(f => f.ExtraPoints).FirstOrDefaultAsync();
                        }

                    }


                }



                //if (item.Point == null)
                //{
                //    item.Extrapoint = 0;
                //}
                //if (item.Extrapoint == null)
                //{
                //    item.Extrapoint = 0;
                //}
                //if (item.ToalPoint == null)
                //{
                //    item.ToalPoint = 0;
                //}
                item.ToalPoint = item.Point + item.Extrapoint;

            }
            await _context.SaveChangesAsync();
            var name = user.Identity.Name;
            var conDatas = _context.DirectConfigs.Where(x => x.Month.ToString().Substring(0,7) == entity.Month).FirstOrDefault();
            var DateEntry = DateTime.Now.ToString("dd/MM/yyyy __ hh:mm");
            Calculations calculations = new(conDatas.PlanId, conDatas.Month, name, DateEntry);
            await _context.AddAsync(calculations);
            await _context.SaveChangesAsync();
            data.Result = calculations;
            data.ErrorMessage = null;
            return data;




        }



        //private string getConcatted(int Level, SubDirectConfigs cc)
        //{
        //    return Level > 0 ? cc.REGION + (Level > 1 ? cc.CITY + (Level > 2 ? cc.ZONE + (Level > 3 ? cc.AREA + (Level > 4 ? cc.SUBAREA + (Level > 5 ? cc.SUBDEALER)))))
        //}

        public DataWithErros getDataCalculation()
        {
            var data = new DataWithErros();
            var calcdata = _context.Calculations.OrderBy(x => x.Plan).Select(x => new { x.PlanId, x.Plan, x.UserName, }).Distinct();

            data.Result = calcdata;
            data.ErrorMessage = null;
            return data;
        }


        public DataWithErros GetCalculationById(Guid Id, string userName)
        {
            DataWithErros data = new();
            var CalcById = _context.Calculations.Where(x => x.PlanId == Id && x.UserName == userName).ToList();
            data.Result = CalcById;
            data.ErrorMessage = null;
            return data;
        }
        public DataWithErros GetSalesData()
        {
            var data = new DataWithErros();
            var startDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            var endDate = startDate.AddMonths(1).AddDays(-1);
            var salesData = _context.Sales.OrderBy(x => x.DAY)
                .Where(x => x.DAY >= startDate && x.DAY <= endDate && x.SD_SUBTYPE =="Subdealer")
                .GroupBy(x => new { x.SD_CODE, x.SD_NAME, x.SHOP_NAME, x.MONTH, x.REGION, x.ZONE, x.CITY, x.AREA, x.SUBAREA })
                .Select(g => new
                {
                    g.Key,
                    toalPoint = g.Sum(s => s.ToalPoint)
                })
                .ToList();
            data.Result = salesData;
            data.ErrorMessage = null;
            return data;
        }
        public async Task<DataWithErros> AddCalculationExcel(ExcelCalculation excelFileData, ClaimsPrincipal user)
        {
            var ExcelData = excelFileData.excels;
            var rangesa = excelFileData.ranges;
            var saleData = _context.Sales.Where(x => x.SD_CODE.Contains(ExcelData.ToString())).ToList();
            var data = new DataWithErros();
            foreach (var d in ExcelData)
            {
                foreach (var item in rangesa)
                {
                    string query = $@"UPDATE [dbo].[Sales]  SET [Extrapoint] = {item.extraPoints}  WHERE [sales].ACTIVEANDHAVECALL=1 and ";
                    query += $@"DATENAME( month, [Sales].DAY) = DATENAME( month,'{excelFileData.month}')   and  DATENAME( YEAR, [Sales].DAY)  = DATENAME( YEAR,'{excelFileData.month}') ";
                    query += $@"and [Sales].FIRST_RECHARGE>={item.rangeFrom} and [Sales].FIRST_RECHARGE<={item.rangeTo}  ";
                    query += $@"and [Sales].SD_CODE ='{d.SD_CODE}' ";
                    _context.Database.ExecuteSqlRaw(query);
                }
            }
            string totalPointQry = "UPDATE [dbo].[Sales]  SET ToalPoint =  Extrapoint+ Point";
            _context.Database.ExecuteSqlRaw(totalPointQry);
            await _context.SaveChangesAsync();
            var name = user.Identity.Name;
            var conDatas = _context.DirectConfigs.Where(xx => xx.Month.Date == excelFileData.month.Date).FirstOrDefault();
            var DateEntry = DateTime.Now.ToString("dd/MM/yyyy -- hh:mm");
            Calculations calculations = new(conDatas.PlanId, conDatas.Month, name, DateEntry);
            await _context.AddAsync(calculations);
            await _context.SaveChangesAsync();
            data.Result = calculations;
            data.ErrorMessage = null;
            return data;

        }

        public DataWithErros SalesDataForm(salesBinding sales)
        {
            var data = new DataWithErros();
  

            var salesData = _context.Sales.OrderBy(x => x.DAY)
                           .Where(x => x.MONTH==sales.Month && x.SD_SUBTYPE == "Subdealer" && x.ACTIVEANDHAVECALL==1)
                           .GroupBy(x => new { x.SD_CODE, x.SD_NAME, x.SHOP_NAME, x.MONTH, x.REGION, x.ZONE, x.CITY, x.AREA, x.SUBAREA })
                           .Select(g => new
                           {
                               g.Key,
                               toalPoint = g.Sum(s => s.ToalPoint)
                           })
                           .ToList();
            data.Result = salesData;
            data.ErrorMessage = null;
            return data;
        }
        public DataWithErros Getallmonth()
        {
            DataWithErros data = new();

            var planlist = _context.Plan.Select(x => x.Month.ToString("yyyy-MM")).Distinct();
            data.Result = planlist;
            data.ErrorMessage = null;
            return data;
        }
    }

}
