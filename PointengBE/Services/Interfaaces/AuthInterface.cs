using PointengBE.Models;
using PointengBE.Models.DataBinding;
using System.Security.Claims;

namespace PointengBE.Services.Interfaaces
{
    public interface AuthInterface
    {
        Task<DataWithErros> GetName(ClaimsPrincipal user);
        //Task<DataWithErros> GetNameFromAd();
        //Task<DataWithErros> AsignUserToRole(RoleAssignment model , ClaimsPrincipal user);


    }
}
