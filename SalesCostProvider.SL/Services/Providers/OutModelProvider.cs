using SalesCostProvider.Models.DB;
using System;
using System.Collections.Generic;
using System.Text;

namespace SalesCostProvider.SL.Services.Providers
{
    public class OutModelProvider: IOutModelProvider
    {
        public OutModel CreateOutModel()
        {
            return new OutModel();
        }
    }
}
