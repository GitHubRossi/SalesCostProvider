using Microsoft.AspNetCore.Mvc;
using SalesCostProvider.DAL;
using SalesCostProvider.Models.DB;
using SalesCostProvider.SL.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using NLog;
using System;
using System.Diagnostics;

namespace SalesCostProvider.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CostProviderAPI : ControllerBase
    {

        private static readonly ILogger _logger = LogManager.GetCurrentClassLogger();

        private Repository _rep { get; set; }

        private IServicesSL _servicesSL { get; set; }

        public CostProviderAPI( Repository rep, IServicesSL servicesSL)
        {
            _rep = rep;
            _servicesSL = servicesSL;

        }

        [HttpPost, Route("costproductsprovider")]
        public async Task<OutModel> CostProductsProvider(InComeModel incomeModeln)
        {
            try
            {
                  return await _servicesSL.CostProcessing(incomeModeln);
            }
          
             catch (Exception ex)
            {
                _logger.Error($"Unexpected error ex={ex.Demystify()}");
                throw;
            }

        }
    }
    
}
