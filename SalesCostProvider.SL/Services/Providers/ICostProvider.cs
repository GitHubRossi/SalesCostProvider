using SalesCostProvider.Models.DB;
using System.Threading.Tasks;

namespace SalesCostProvider.SL.Services
{
    public interface ICostProvider
    {        
        public Task<ResultModel> CostProcessing(IInComeModel inputModel);
    }
}
