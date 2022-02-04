using Microsoft.VisualStudio.TestTools.UnitTesting;
using SalesCostProvider.DAL;
using SalesCostProvider.Models.DB;
using SalesCostProvider.SL.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesCostProvider.Test
{
    [TestClass]
    class CostProviderUnitTest
    {        
        private IRepository _rep { get; set; }
        private ICostProvider _costProvider { get; set; }

        public CostProviderUnitTest(IRepository rep, ICostProvider costProvider)
        {
            _rep = rep;
            _costProvider = costProvider;
        }
        [TestInitialize]        
        public async void TestInit()
        {
            await UnitTestGetIncomeModels();
        }

        [TestMethod]
        public async Task<IEnumerable<InComeModel>> UnitTestGetIncomeModels()
        {
            var models = await _rep.GetIncomeModels();

            Assert.IsNotNull(models);

            return models;
        }
        [TestMethod]
        public async Task<OutModel> UnitTestCostProcessing()
        {
            var dataSet = await _rep.GetIncomeModels();

            Assert.IsNotNull(dataSet);

            var firstModel = dataSet.First();

            return _costProvider.GetOutputCostModel(firstModel);
        }
    }
}
