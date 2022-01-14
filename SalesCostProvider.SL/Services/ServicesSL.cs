using Microsoft.Extensions.Logging;
using SalesCostProvider.DAL;
using SalesCostProvider.Models.DB;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace SalesCostProvider.SL.Services
{
    public class ServicesSL : IServicesSL
    {
        Repository _rep;
        ILogger<ServicesSL> _logger;
        ICostProvider _costProvider;

        public ServicesSL(Repository rep, ICostProvider costProvider)
        {
            _rep = rep;
            _costProvider = costProvider;
        }

        #region Public Methods
        public async Task<ResultModel> CostProcessing(InComeModel model)
        {
            ResultModel result = new ResultModel();
            try
            {
                result = await _costProvider.CostProcessing(model);
            }            
            catch (Exception ex)
            {
                _logger.LogError($"Unexpected error ex={ex.Demystify()}");
                throw;
            }
            await StoreModels(model, result);
            return result;
        }
        #endregion

        #region Private methods
        private async Task<bool> StoreModels(InComeModel modelIn, ResultModel modelOut)
        {
            ResultModel result = new ResultModel();
            try
            {
                _rep._context.IncomeModels.Add(modelIn);
                _rep._context.ResultModels.Add(modelOut);
                await _rep._context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Unexpected error ex={ex.Demystify()}");
                throw;
            }                        
        }
        #endregion
    }
}
