using Microsoft.Extensions.Configuration;
using NLog;
using SalesCostProvider.DB;
using SalesCostProvider.Models.DB;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace SalesCostProvider.DAL
{
    public class Repository : IRepository
    {
        private IConfiguration _configuration;
        private static readonly ILogger _logger = LogManager.GetCurrentClassLogger();
        public Repository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<ResultModel> ResultModelSaving(ResultModel resultModel)
        {

            try
            {
                ResultModel data = new ResultModel();

                using (var _context = new CostProviderDbContext(_configuration))
                {

                    await _context.ResultModels.AddAsync(resultModel);

                    await _context.SaveChangesAsync();
                }

                return data;
            }

            catch (Exception ex)
            {
                _logger.Error($"Unexpected error ex={ex.Demystify()}");
                throw;
            }
        }
        public async Task<ResultModel> IncomeModelSaving(InComeModel incomeModel)
        {

            try
            {
                ResultModel data = new ResultModel();

                using (var _context = new CostProviderDbContext(_configuration))
                {

                    await _context.IncomeModels.AddAsync(incomeModel);

                    await _context.SaveChangesAsync();
                }

                return data;
            }

            catch (Exception ex)
            {
                _logger.Error($"Unexpected error ex={ex.Demystify()}");
                throw;
            }
        }

        public async Task<IEnumerable<IInComeModel>> GetIncomeModels()
        {

            try
            {
                ResultModel data = new ResultModel();

                using (var _context = new CostProviderDbContext(_configuration))
                {

                    return await _context.IncomeModels.ToListAsync();
                }
            }

            catch (Exception ex)
            {
                _logger.Error($"Unexpected error ex={ex.Demystify()}");
                throw;
            }
        }

    }

}
