using PointengBE.Models;
using PointengBE.Models.DataBinding;
using System.Security.Claims;

namespace PointengBE.Services.Interfaaces
{
    public interface IdirctInterface
    {
        DataWithErros Getall();


        DataWithErros Getallmonth();
        DataWithErros GetallPlansId(DateTime month);

        DataWithErros GetById(Guid Id);
        Task<DataWithErros> AddDirectCfg(DirConfigBinding entity, ClaimsPrincipal user);
        Task<DataWithErros> DeleteDirectCfg(Guid Id, ClaimsPrincipal user);
    }
}
