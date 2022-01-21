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
        public long Id { get; set; }
        public double FinalCost { get; set; }
        [ForeignKey("ProductOutFK")]
        [NotMapped]
        public virtual IEnumerable<ProductOut> ProductsOut  {get;set;}
    }
}
