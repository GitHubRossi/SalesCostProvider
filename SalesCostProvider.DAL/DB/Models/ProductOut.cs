
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalesCostProvider.Models.DB
{
    public class ProductOut: IProductOut
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string Name { get; set; }
        public double Cost { get; set; }
        [NotMapped]
        [ForeignKey("ResultModelId")]
        public ResultModel ResultModelId  {get; set;}
    }
}
