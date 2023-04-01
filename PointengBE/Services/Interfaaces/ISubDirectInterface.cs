using PointengBE.Models;
using PointengBE.Models.DataBinding;
using System.Security.Claims;
namespace PointengBE.Services.Interfaaces
{
    public interface ISubDirectInterface
    {
        DataWithErros GetRegion();
        DataWithErros GetCity(string REGION);
        DataWithErros GetZone(string CITY);
        DataWithErros GetArea(string ZONE);
        DataWithErros GetSubArea(string AREA);
        DataWithErros GetSubDealer(string SUBAREA);
        DataWithErros Getallmonth();
        DataWithErros GetallDirectConfig(DateTime month);
        Task<DataWithErros> AddsubDirectCfg(subDirConfigBinding entity, ClaimsPrincipal user);

        DataWithErros GetallDirectConfigbyid(Guid Id);
        DataWithErros GetallsubDirectConfig();
        DataWithErros deleteRangeId(int subConfigId, ClaimsPrincipal user);
        DataWithErros GetallsubConfigSubId(int subConfigId);
    }
}
