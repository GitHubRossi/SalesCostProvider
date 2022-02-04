using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SalesCostProvider.Models.DB
{
    public interface IOutModel
    {
        public double FinalCost { get; set; }
        public IEnumerable<OutProduct> ProductsOut  {get;set;}
    }
}
