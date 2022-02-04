using NLog;
using SalesCostProvider.DAL;
using SalesCostProvider.Models.DB;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SalesCostProvider.SL.Services
{
    public class ServicesSL : IServicesSL
    {
        IRepository _rep;
        private static readonly ILogger _logger = LogManager.GetCurrentClassLogger();
        ICostProvider _costProvider;

        public ServicesSL(IRepository rep, ICostProvider costProvider)
        {
            _rep = rep;
            _costProvider = costProvider;
        }

        #region Public Methods
        public OutModel CostProcessing(InComeModel inComeModel)
        {
            try
            {
                var outModel =  _costProvider.GetOutputCostModel(inComeModel);                          
                return outModel;
            }            
            catch (Exception ex)
            {
                _logger.Error($"Unexpected error ex={ex.Demystify()}");
                throw;
            }
        }
        public async Task<bool> StoreModels(InComeModel inModel, OutModel modelOut)
        {
            try
            {
                await _rep.IncomeModelSaving(inModel);
                await _rep.ResultModelSaving(modelOut);
                return true;
            }
            catch (Exception ex)
            {
                _logger.Error($"Unexpected error ex={ex.Demystify()}");
                throw;
            }
        }
        #endregion

        #region Private methods

        #endregion
    }
}
