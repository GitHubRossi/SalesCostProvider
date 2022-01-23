using Microsoft.Extensions.Configuration;
using SalesCostProvider.DB;
using SalesCostProvider.Models.DB;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SalesCostProvider.DAL
{
    public interface IRepository
    {
        public Task<ResultModel> ResultModelSaving(ResultModel resultModel);
        public Task<ResultModel> IncomeModelSaving(InComeModel incomeModel);

        public Task<IEnumerable<IInComeModel>> GetIncomeModels();
    }
}
