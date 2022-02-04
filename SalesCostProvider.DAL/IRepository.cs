using Microsoft.Extensions.Configuration;
using SalesCostProvider.DB;
using SalesCostProvider.Models.DB;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SalesCostProvider.DAL
{
    public interface IRepository
    {
        public Task<bool> ResultModelSaving(OutModel resultModel);
        public Task<bool> IncomeModelSaving(InComeModel incomeModel);
        public Task<IEnumerable<InComeModel>> GetIncomeModels();
    }
}
