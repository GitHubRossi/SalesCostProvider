using SalesCostProvider.Models.DB;
using System.Threading.Tasks;

namespace SalesCostProvider.SL.Services
{
    public interface ICostProvider
    {        
        public OutModel GetOutputCostModel(IInComeModel inputModel);
    }
}
