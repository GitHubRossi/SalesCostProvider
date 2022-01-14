using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SalesCostProvider.Models.DB
{
    public interface IProductIn:IExtendedProduct
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [NotMapped]
        public string Name { get; set; }
        public double Cost { get; set; }

    }
}
