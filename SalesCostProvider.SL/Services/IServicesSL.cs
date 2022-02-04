using SalesCostProvider.Models.DB;
using System.Threading.Tasks;

namespace SalesCostProvider.SL.Services
{
    public interface IServicesSL
    {
        OutModel CostProcessing(InComeModel model);
        Task<bool> StoreModels(InComeModel inModel, OutModel modelOut);
    }    
}
