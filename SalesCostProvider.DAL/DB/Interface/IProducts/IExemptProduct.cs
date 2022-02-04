
namespace SalesCostProvider.Models.DB
{
    public interface IExemptProduct: IProduct
    {        
        public bool Exempt { get; set; }
    }
}
