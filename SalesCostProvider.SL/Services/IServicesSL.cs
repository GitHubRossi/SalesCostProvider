using SalesCostProvider.Models.DB;
using System.Threading.Tasks;

namespace SalesCostProvider.SL.Services
{
    public interface IServicesSL
    {
        public Task<ResultModel> CostProcessing(InComeModel model);
    }    
}
