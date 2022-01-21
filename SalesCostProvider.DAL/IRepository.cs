using Microsoft.Extensions.Configuration;
using SalesCostProvider.DB;
using SalesCostProvider.Models.DB;
using System.Threading.Tasks;

namespace SalesCostProvider.DAL
{
    public interface IRepository
    {
        public CostProviderDbContext getContext();
        public Task<ResultModel> ResultModelSaving(ResultModel resultModel);
    }
}
