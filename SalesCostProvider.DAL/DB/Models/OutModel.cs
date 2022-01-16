using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SalesCostProvider.Models.DB
{
    public class OutModel
    {
        public double FinalCost { get; set; }
        [NotMapped]
        public virtual IEnumerable<OutProduct> ProductsOut  {get;set;}
    }
}
