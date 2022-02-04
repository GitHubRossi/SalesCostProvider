
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalesCostProvider.Models.DB
{
    public class OutProduct: Product
    {
        [NotMapped]
        public virtual OutModel OutModelId  {get; set;}
    }
}
