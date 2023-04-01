using PointengBE.Models;
using PointengBE.Models.DataBinding;
using System.Security.Claims;
namespace PointengBE.Services.Interfaaces
{
    public interface ISubDirectPromInterface
    {
        DataWithErros GetRegionProm();
        DataWithErros GetCityProm(string REGION);
        DataWithErros GetZoneProm(string CITY);
        DataWithErros GetAreaProm(string ZONE);
        DataWithErros GetSubAreaProm(string AREA);
        DataWithErros GetSubDealerProm(string SUBAREA);

        DataWithErros GetallmonthProm();
        DataWithErros GetallDirectConfigProm(DateTime month);
        Task<DataWithErros> AddsubDirectCfgProm(subDirConfigBinding entity, ClaimsPrincipal user);

        DataWithErros GetallDirectConfigbyidProm(Guid Id);
        DataWithErros GetallsubDirectConfigProm();
        DataWithErros deleteRangeIdProm(int subConfigId, ClaimsPrincipal user);
        DataWithErros GetallsubConfigSubIdProm(int subConfigId);
    }
}
