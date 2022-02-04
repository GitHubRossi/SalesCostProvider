using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SalesCostProvider.DAL;
using SalesCostProvider.SL.Services;
using SalesCostProvider.SL.Services.Providers;

namespace SalesCostProvider.Test
{
    [TestClass]
    public class TestBase
    {
        protected ServiceProvider serviceProvider { get; set; }
        public TestBase()
        {
            var services = new ServiceCollection();

            services.AddScoped<IRepository, Repository>();

            services.AddScoped<IOutModelProvider, OutModelProvider>();

            services.AddScoped<ICostProvider, CostProvider>();

            services.AddScoped<IServicesSL, ServicesSL>();

            services.AddLogging();

            serviceProvider = services.BuildServiceProvider();

        }
    }
}
