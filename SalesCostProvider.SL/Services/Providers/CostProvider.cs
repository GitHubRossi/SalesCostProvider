using SalesCostProvider.Models.DB;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SalesCostProvider.SL.Services
{
    public class CostProvider:ICostProvider
    {
        private bool E_Margin { get; set; }
        #region Public Methods     

        public async Task<ResultModel> CostProcessing(IInComeModel inputModel)
        {
            E_Margin = inputModel.EMargin;
                        
            ResultModel result = new ResultModel();

            var productsWithTax = await TaxProcessing(inputModel.Products);

            result.FinalCost = await GetFinalCost(inputModel.Products, productsWithTax);

            result.ProductsOut = productsWithTax;

            return (result);

        }
        #endregion

        #region Private Methods     
        public async Task<IEnumerable<ProductOut>> TaxProcessing(IEnumerable<IProductIn> products)
        {            
            Task<List<ProductOut>> AsyncProcess = Task.Run(() =>
            {
                List<ProductOut> ListTaxedProducts = new List<ProductOut>();
                foreach (var p in products)
                {
                    var product = new ProductOut();
                    product.Name = p.Name;
                    // with ExtraTax??
                    if (p.STax)
                    {
                        product.Cost = Math.Round((p.Cost / 100) * 107,2);
                    }
                    else
                    {
                        product.Cost = Math.Round(p.Cost,2);
                    }
                    ListTaxedProducts.Add(product);
                }
                return ListTaxedProducts;
            });
            return await AsyncProcess;            
        }

        public async Task<double> GetFinalCost(IEnumerable<IProductIn> products, IEnumerable<IProductOut> productsWithTax)
        {
            double finalCost = 0;
            Task<List<IProductOut>> AsyncAddMargin = Task.Run(() =>
            {
                List<IProductOut> ListTaxedProducts = new List<IProductOut>();
                foreach (var p in products)
                {
                    var product = new ProductOut();
                    // with ExtraMargin??
                    if (E_Margin)
                    {
                        product.Cost = Math.Round((p.Cost / 100) * 116,2);
                    }
                    else
                    {
                        product.Cost = Math.Round((p.Cost / 100) * 111,2);
                    }
                    ListTaxedProducts.Add(product);
                }
                return ListTaxedProducts;
            });

            double costProduct = 0;
            foreach(var p in products)
            {
                costProduct += p.Cost;
            }

            double costProductWithTax = 0;
            foreach (var p in productsWithTax)
            {
                costProductWithTax += p.Cost;
            }

            var additionalTax = costProductWithTax - costProduct;


            var taxedProducts = await AsyncAddMargin;

            double costWithMaring = 0;
            foreach (var p in taxedProducts)
            {
                costWithMaring += p.Cost;
            }


            finalCost = costWithMaring + additionalTax;

            return Math.Round(finalCost,2);
        }

        #endregion
    }
}
