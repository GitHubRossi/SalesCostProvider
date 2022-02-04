using SalesCostProvider.Models.DB;
using System;
using System.Collections.Generic;
using System.Text;

namespace SalesCostProvider.SL.Services.Providers
{
    public interface IOutModelProvider
    {
        OutModel CreateOutModel();
    }
}
