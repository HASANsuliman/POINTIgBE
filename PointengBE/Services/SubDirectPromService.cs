using PointengBE.Models;
using PointengBE.Models.Context;
using PointengBE.Models.DataBinding;
using PointengBE.Services.Interfaaces;
using System.Security.Claims;


namespace PointengBE.Services
{
    public class SubDirectPromService:ISubDirectPromInterface
    {
        protected PointingContext? _context;
        public SubDirectPromService(PointingContext context)
        {
            _context = context;
        }
        public DataWithErros GetRegionProm()
        {
            DataWithErros data = new();
            var RegionList = _context.Location.Select(x => x.REGION).Distinct();
            data.Result = RegionList;
            data.ErrorMessage = null;
            return data;
        }
        public DataWithErros GetCityProm(string REGION)
        {
            DataWithErros data = new();
            var CityList = _context.Location.Where(x => x.REGION == REGION).Select(x => x.CITY).Distinct();
            data.Result = CityList;
            data.ErrorMessage = null;
            return data;
        }
        public DataWithErros GetZoneProm(string CITY)
        {
            DataWithErros data = new();
            var ZoneList = _context.Location.Where(x => x.CITY == CITY).Select(x => x.ZONE).Distinct();
            data.Result = ZoneList;
            data.ErrorMessage = null;
            return data;
        }
        public DataWithErros GetAreaProm(string ZONE)
        {
            DataWithErros data = new();
            var AreaList = _context.Location.Where(x => x.ZONE == ZONE).Select(x => x.AREA).Distinct();
            data.Result = AreaList;
            data.ErrorMessage = null;
            return data;
        }
        public DataWithErros GetSubAreaProm(string AREA)
        {
            DataWithErros data = new();
            var SubAreaList = _context.Location.Where(x => x.AREA == AREA).Select(x => x.SUBAREA).Distinct();
            data.Result = SubAreaList;
            data.ErrorMessage = null;
            return data;
        }
        public DataWithErros GetSubDealerProm(string SUBAREA)
        {
            DataWithErros data = new();
            var SubAreaList = _context.Location.Where(x => x.SUBAREA == SUBAREA).Select(x => x.SD_CODE).Distinct();
            data.Result = SubAreaList;
            data.ErrorMessage = null;
            return data;
        }
        public DataWithErros GetallmonthProm()
        {
            DataWithErros data = new();

            var planlist = _context.DirectConfigsProm.Select(x => x.Month).Distinct();
            data.Result = planlist;
            data.ErrorMessage = null;
            return data;
        }
        public async Task<DataWithErros> AddsubDirectCfgProm(subDirConfigBinding entity, ClaimsPrincipal user)
        {
            var name = user.Identity.Name;
            int i = 0;
            DataWithErros data = new();
            foreach (var element in entity.SubConfigs)
            {
                var exisId = _context.SubDirectConfigsProm.Where(x => x.SubConfigId == entity.SubConfigId).FirstOrDefault();
                if (entity.REGION == null)
                {
                    entity.REGION = "All";
                    entity.CITY = "All";
                    entity.ZONE = "All";
                    entity.AREA = "All";
                    entity.SUBAREA = "All";
                    entity.SUBDEALER = "All";
                }
                if (entity.CITY == null)
                {
                    entity.CITY = "All";
                    entity.ZONE = "All";
                    entity.AREA = "All";
                    entity.SUBAREA = "All";
                    entity.SUBDEALER = "All";

                }
                if (entity.ZONE == null)
                {
                    entity.ZONE = "All";
                    entity.AREA = "All";

                    entity.SUBAREA = "All";
                    entity.SUBDEALER = "All";

                }
                if (entity.AREA == null)
                {
                    entity.AREA = "All";
                    entity.SUBAREA = "All";
                    entity.SUBDEALER = "All";

                }
                if (entity.SUBAREA == null)
                {
                    entity.SUBAREA = "All";
                    entity.SUBDEALER = "All";

                }
                if (entity.SUBDEALER == null)
                {
                    entity.SUBDEALER = "All";

                }
                SubDirectConfigProm subdirect = new(entity.PlanId, element.RangeId, entity.Month, entity.DateFrom.AddDays(1), entity.DateTo.AddDays(1), entity.SubConfigId, element.RangeFrom,
                   element.RangeTo, element.Points, element.ExtraPoints, entity.REGION, entity.CITY, entity.ZONE, entity.AREA,
                   entity.SUBAREA, entity.SUBDEALER, name);
                if (exisId == null)
                {
                    subdirect.DateEntry =DateTime.Now.ToString("dd/MM/yyyy __ hh:mm");
                    await _context.AddAsync(subdirect);
                }
                else
                {
                    data.Result = null;
                    data.ErrorMessage = " Configeration Not Added because SubConfigId Is Already Exist";
                    return data;
                }
            }
            await _context.SaveChangesAsync();
            entity.UserName = name;
            entity.DateEntry = DateTime.Now.ToString("dd/MM/yyyy __ hh:mm");
            data.Result = entity;
            data.ErrorMessage = null;
            return data;
        }
        public DataWithErros deleteRangeIdProm(int subConfigId, ClaimsPrincipal user)
        {
            var name = user.Identity.Name;

            DataWithErros data = new();
            var existRId = _context.SubDirectConfigsProm.Where(x => x.SubConfigId == subConfigId).FirstOrDefault();
            var deleteRId = _context.SubDirectConfigsProm.Where(x => x.SubConfigId == subConfigId).ToList();

            if (existRId != null)
            {
                if (existRId.Month.Year < DateTime.Now.Year && existRId.Month.Month < DateTime.Now.Month)
                {
                    data.Result = null;
                    data.ErrorMessage = "You Are Not Allowed To Delete This Config";
                    return data;
                }

                foreach (var item in deleteRId)
                {
                    _context.SubDirectConfigsProm.Remove(item);
                    _context.SaveChanges();
                }
                LogHistory subconfHistory = new("SubConfig", existRId.Month, name, DateTime.Now);
                _context.LogHistories.Add(subconfHistory);
                _context.SaveChanges();
                data.Result = deleteRId;
                data.ErrorMessage = null;
                return data;
            }
            else
            {
                data.ErrorMessage = " Error Config not deleted";
                data.Result = null;
                return data;
            }
        }

        public DataWithErros GetallDirectConfigProm(DateTime month)
        {
            DataWithErros data = new();
            var planlist = _context.DirectConfigsProm.Where(x => x.Month == month).Select(x => new { x.Month, x.PlanId }).Distinct();
            data.Result = planlist;
            data.ErrorMessage = null;
            return data;
        }

        public DataWithErros GetallDirectConfigbyidProm(Guid Id)
        {
            DataWithErros data = new();
            var cfgn = _context.DirectConfigsProm.Where(x => x.PlanId == Id).ToList();
            data.Result = cfgn;
            data.ErrorMessage = null;
            return data;
        }



        public DataWithErros GetallsubConfigSubIdProm(int subConfigId)
        {
            DataWithErros data = new();

            var cfgn = _context.SubDirectConfigsProm.Where(x => x.SubConfigId == subConfigId);
            data.Result = cfgn;
            data.ErrorMessage = null;
            return data;
        }

        public DataWithErros GetallsubDirectConfigProm()
        {
            DataWithErros data = new();
            var subdirect = _context.SubDirectConfigsProm.Select(x => new {
                x.Month,
                x.PlanId,
                x.SubConfigId,
                x.DateFrom,
                x.DateTo,
                x.UserName,
                x.DateEntry
            }).OrderBy(o => o.Month).Distinct();
            if (subdirect == null)
            {
                data.Result = null;
                data.ErrorMessage = "Error No Data to view";
                return data;
            }
            data.Result = subdirect;
            data.ErrorMessage = null;
            return data;
        }
    }
}
