using PointengBE.Models;
using PointengBE.Models.DataBinding;
using System.Security.Claims;

namespace PointengBE.Services.Interfaaces
{
    public interface IPlanInterface
    {
        DataWithErros GetAllPlans();
        
        DataWithErros GetPlanById(Guid Id);
        DataWithErros GetPlanBymonth(string entity);
        Task<DataWithErros> AddPlan(Plan entity, ClaimsPrincipal user); 
        Task<DataWithErros> UpdatePlan(Plan entity, ClaimsPrincipal user);
        Task<DataWithErros> DeletePlan(Guid Id, ClaimsPrincipal user);

    }
}
