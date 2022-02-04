using SalesCostProvider.Models.DB;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalesCostProvider.Models.DB
{
    public class ExemptProduct : IExemptProduct
    {
        public bool Exempt { get; set; }
        public string Name { get; set; }
        public double Cost { get; set; }
    }
}
