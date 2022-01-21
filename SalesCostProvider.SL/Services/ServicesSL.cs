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
        public async Task<OutModel> CostProcessing(IInComeModel model)
        {
            OutModel resultOut = new OutModel();
            try
            {
                var outModel = await _costProvider.CostProcessing(model);
                resultOut.FinalCost = outModel.FinalCost;
                var dataProducts = outModel.ProductsOut.Select(s => new OutProduct { Cost = s.Cost, Name = s.Name }).ToList();
                resultOut.ProductsOut = dataProducts;
                await StoreModels(model, outModel);
                return resultOut;
            }            
            catch (Exception ex)
            {
                _logger.Error($"Unexpected error ex={ex.Demystify()}");
                throw;
            }
        }
        #endregion

        #region Private methods
        private async Task<bool> StoreModels(IInComeModel modelIn, ResultModel modelOut)
        {
            ResultModel result = new ResultModel();
            try
            {
                InComeModel inModel = new InComeModel();
                _rep.getContext().IncomeModels.Add(inModel);
                _rep.getContext().ResultModels.Add(modelOut);
                await _rep.getContext().SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.Error($"Unexpected error ex={ex.Demystify()}");
                throw;
            }                        
        }
        #endregion
    }
}
