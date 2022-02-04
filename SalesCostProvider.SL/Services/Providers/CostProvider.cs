using SalesCostProvider.Models.DB;
using SalesCostProvider.SL.Services.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesCostProvider.SL.Services
{
    public class CostProvider : ICostProvider
    {
        private bool E_Margin { get; set; }
        private IOutModelProvider _outModelProvider { set; get; }

        public CostProvider(IOutModelProvider outModelProvider)
        {
            _outModelProvider = outModelProvider;
        }
        #region Public Methods     
        public OutModel GetOutputCostModel(IInComeModel inputModel)
        {
            E_Margin = inputModel.EMargin;

            var outModel = _outModelProvider.CreateOutModel();

            var productsWithTax = GetTaxedProducts(inputModel.Products);

            outModel.ProductsOut = productsWithTax;

            outModel.FinalCost = GetFinalCost(inputModel.Products, productsWithTax);

            return outModel;
        }
        #endregion
        #region Private Methods     
        private IEnumerable<OutProduct> GetTaxedProducts(IEnumerable<InProduct> products)
        {
            var taxedProducts = new List<OutProduct>();

            foreach (var p in products)
            {
                var taxedProduct = new OutProduct();
                taxedProduct.Name = p.Name;
                if (p.GetType() != typeof(IExemptProduct))
                {
                    taxedProduct.Cost = Math.Round((p.Cost / 100) * 107, 2);
                }
                else
                {
                    taxedProduct.Cost = Math.Round(p.Cost, 2);
                }
                taxedProducts.Add(taxedProduct);
            }
            return taxedProducts;
        }
        private double GetFinalCost(IEnumerable<IProduct> products, IEnumerable<IProduct> productsWithTax)
        {
            var ListProductsWithMargin = GetProductsWithMargin(products);

            var costProducts = products.Sum(x => x.Cost);
            var costProductsWithTax = productsWithTax.Sum(x => x.Cost);

            var tax = costProductsWithTax - costProducts;
            var costWithMaring = ListProductsWithMargin.Sum(x => x.Cost);

            var finalCost = costWithMaring + tax;

            return Math.Round(finalCost, 2);
        }
        private List<IProduct> GetProductsWithMargin(IEnumerable<IProduct> products)
        {
            List<IProduct> ListProductsWithMargin = new List<IProduct>();
            foreach (var p in products)
            {
                var product = new OutProduct();
                if (E_Margin)
                {
                    product.Cost = Math.Round((p.Cost / 100) * 116, 2);
                }
                else
                {
                    product.Cost = Math.Round((p.Cost / 100) * 111, 2);
                }
                ListProductsWithMargin.Add(product);
            }
            return ListProductsWithMargin;
        }
        #endregion
    }
}
