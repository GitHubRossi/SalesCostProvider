using SalesCostProvider.Models.DB;
using System.Threading.Tasks;

namespace SalesCostProvider.SL.Services
{
    public interface ICostProvider
    {        
        public ResultModel CostProcessing(IInComeModel inputModel);
    }
}
