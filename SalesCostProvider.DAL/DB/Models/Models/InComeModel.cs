using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalesCostProvider.Models.DB
{
    public class InComeModel:IInComeModel
    {        
        public bool EMargin { get; set; }
        
        public virtual List<InProduct> Products { get; set; }         
    }
}
