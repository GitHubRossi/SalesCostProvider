using Microsoft.AspNetCore.Mvc;
using SalesCostProvider.Models.DB;
using SalesCostProvider.SL.Services;
using System.Threading.Tasks;
using NLog;


namespace SalesCostProvider.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CostProviderAPI : ControllerBase
    {

        private static readonly ILogger _logger = LogManager.GetCurrentClassLogger();

        private IServicesSL _servicesSL { get; set; }

        public CostProviderAPI(IServicesSL servicesSL)
        {
            _servicesSL = servicesSL;
        }

        [HttpPost, Route("costproductsprovider")]
        public async Task<OutModel> CostProductsProvider(InComeModel incomeModel)
        {
            var outModel = _servicesSL.CostProcessing(incomeModel);
            await _servicesSL.StoreModels(incomeModel, outModel);
            return outModel;
        }
    }
    
}
