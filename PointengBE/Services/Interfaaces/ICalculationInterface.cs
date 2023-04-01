using PointengBE.Models;
using PointengBE.Models.DataBinding;
using System.Security.Claims;

namespace PointengBE.Services.Interfaaces
{
    public interface ICalculationInterface
    {
        Task<DataWithErros> AddCalculationMain(calc entity);

        Task<DataWithErros> AddCalculation(calc entity, ClaimsPrincipal user);
        Task<DataWithErros> AddCalculationExcel(ExcelCalculation excelFileData, ClaimsPrincipal user);
        Task<DataWithErros> AddCalculationExcelProm(ExcelCalculation excelFileData, ClaimsPrincipal user);

        DataWithErros getDataCalculation();
        DataWithErros GetSalesData();
        DataWithErros Getallmonth();
      
        DataWithErros SalesDataForm(salesBinding sales);
        DataWithErros GetCalculationById(Guid Id, string userName);
    }
}
