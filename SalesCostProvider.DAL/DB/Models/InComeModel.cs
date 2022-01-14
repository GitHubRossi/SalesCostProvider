using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalesCostProvider.Models.DB
{
    public class InComeModel
    {
        [NotMapped]
        public long Id { get; set; }
        public bool EMargin { get; set; }
        public IEnumerable<IProductIn> Products { get; set; }         
    }
}
