﻿using Microsoft.Extensions.Configuration;
using SalesCostProvider.DB;
using SalesCostProvider.Models.DB;
using System.Threading.Tasks;

namespace SalesCostProvider.DAL
{
    public class Repository
    {
        public CostProviderDbContext _context;        
        public Repository(IConfiguration configuration)
        {
            _context =  new CostProviderDbContext(configuration);
        }

        public async Task<ResultModel> ResultModelSaving(ResultModel resultModel)
        {
            ResultModel data = new ResultModel();

            await _context.ResultModels.AddAsync(resultModel);

            await _context.SaveChangesAsync();

            return data;            
        }
      
    }
}