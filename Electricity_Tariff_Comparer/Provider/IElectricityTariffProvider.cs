using Electricity_Tariff_Comparer.Models;

namespace Electricity_Tariff_Comparer.Provider
{
    public interface IElectricityTariffProvider
    {

        /// <summary>
        /// Get tariffs from the electricty provider.
        /// </summary>
        /// <returns>The list of tariffs.</returns>
        List<Tariff> GetTariffs();
    }
}
