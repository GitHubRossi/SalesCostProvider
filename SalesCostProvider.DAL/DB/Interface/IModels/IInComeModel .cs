using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalesCostProvider.Models.DB
{
    public interface IInComeModel
    {
        public bool EMargin { get; set; }
        public List<InProduct> Products { get; set; }         
    }
}
