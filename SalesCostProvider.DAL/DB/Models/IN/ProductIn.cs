using SalesCostProvider.Models.DB;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalesCostProvider.Models.DB
{
    public class ProductIn: IProductIn
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [NotMapped]
        public long Id { get; set; }
        public string Name { get; set; }
        public double Cost { get; set; }        
        public bool STax { get; set; }
    }
}
