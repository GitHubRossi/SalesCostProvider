using SalesCostProvider.Models.DB;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalesCostProvider.Models.DB
{
    public class Product: IProduct
    {
        public string Name { get; set; }
        public double Cost { get; set; }        

    }
}
