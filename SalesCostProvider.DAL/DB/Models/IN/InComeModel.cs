using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalesCostProvider.Models.DB
{
    public class InComeModel:IInComeModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public bool EMargin { get; set; }
        [NotMapped]
        public virtual IEnumerable<ProductIn> Products { get; set; }         
    }
}
