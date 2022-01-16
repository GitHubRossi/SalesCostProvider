using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalesCostProvider.Models.DB
{
    public interface IInComeModel
    {
        [NotMapped]
        public long Id { get; set; }
        public bool EMargin { get; set; }
        [NotMapped]
        public IEnumerable<ProductIn> Products { get; set; }         
    }
}
