using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SalesCostProvider.Models.DB
{
    public class ResultModel
    {
        [NotMapped]
        public long Id { get; set; }
        public IProductOut Products { get; set; }
        public double FinalCost { get; set; }
        public IEnumerable<IProductOut> ProductsOut  {get;set;}
    }
}
