using Electricity_Tariff_Comparer.Provider;
using Electricity_Tariff_Comparer.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;

namespace Electricity_Tariff_Comparer.Test
{
    public class CustomWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                services.AddScoped<IElectricityTariffProvider, ElectricityTariffProvider>();
                services.AddScoped<ITariffService, TariffService>();
            });
        }
    }
}