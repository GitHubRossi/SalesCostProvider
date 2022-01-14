using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SalesCostProvider.DAL;
using SalesCostProvider.Models.DB;
using SalesCostProvider.SL.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SalesCostProvider.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CostProviderAPI : ControllerBase
    {

        private readonly ILogger<CostProviderAPI> _logger;

        private Repository _rep { get; set; }

        private IServicesSL _servicesSL { get; set; }

        public CostProviderAPI(ILogger<CostProviderAPI> logger, Repository rep, IServicesSL servicesSL)
        {
            _logger = logger;
            _rep = rep;
            _servicesSL = servicesSL;

        }

        [HttpPost]
        public async Task<ResultModel
            > CostProductsProvider(IEnumerable<IProductIn> productIn)
        {            
            InComeModel model = new InComeModel();
            model.Products = productIn;
            return await _servicesSL.CostProcessing(model);

        }
    }
}
