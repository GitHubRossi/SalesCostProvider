using Microsoft.VisualStudio.TestTools.UnitTesting;
using SalesCostProvider.DAL;
using SalesCostProvider.Models.DB;
using SalesCostProvider.SL.Services;
using System.Linq;
using System.Threading.Tasks;

namespace SalesCostProvider.Test
{
    [TestClass]
    class StatisticTest
    {        
        private Repository _rep { get; set; }
        
        public  StatisticTest(Repository rep)
        {
            _rep = rep;
        }
        [TestInitialize]
        
        public async void TestInit()
        {
            //await UnitTest1();
        }

        //[TestMethod]
        //async Task<ResultModel> UnitTest1()
        //{            
        //    var dataSet = _rep._context.IncomeModels.First();

        //    CostProvider provider = new CostProvider();

        //    return await provider.CostProcessing(dataSet);            
        //}
    }
}
