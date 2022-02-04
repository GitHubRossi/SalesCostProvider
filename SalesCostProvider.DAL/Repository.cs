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
        CostProviderDbContext _context;

        public Repository(IConfiguration configuration, CostProviderDbContext context)
        {
            _configuration = configuration;
            _context = context;
        }

        public async Task<bool> ResultModelSaving(OutModel outModel)
        {
            try
            {
                    await _context.OUT_Models.AddAsync(outModel);

                    var success = await _context.SaveChangesAsync();

                    return (success > 0);                
            }
            catch (Exception ex)
            {
                _logger.Error($"Unexpected error ex={ex.Demystify()}");
                throw;
            }
        }
        public async Task<bool> IncomeModelSaving(InComeModel incomeModel)
        {
            try
            {
                    await _context.IN_Models.AddAsync(incomeModel);

                    var success = await _context.SaveChangesAsync();

                    return (success > 0);                
            }
            catch (Exception ex)
            {
                _logger.Error($"Unexpected error ex={ex.Demystify()}");
                throw;
            }
        }
        public async Task<IEnumerable<InComeModel>> GetIncomeModels()
        {
            try
            {
                 return await _context.IN_Models.ToListAsync();                
            }

            catch (Exception ex)
            {
                _logger.Error($"Unexpected error ex={ex.Demystify()}");
                throw;
            }
        }
    }

}
