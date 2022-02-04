using SalesCostProvider.Models.DB;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalesCostProvider.Models.DB
{
    public class InProduct: ExemptProduct
    {
        [NotMapped]        
        public virtual InComeModel InComeModelId { get; set; }        
    }
}
