using Electricity_Tariff_Comparer.Services.Dtos;

namespace Electricity_Tariff_Comparer.Services
{
    public interface ITariffService
    {
        /// <summary>
        /// Compare the tariffs cost difference from different packages.
        /// </summary>
        /// <param name="consumption">The electricity consumption in kWh.</param>
        /// <returns>The comparison result.</returns>
        List<TariffComparisonResult> CompareTariffs(int consumption);
    }
}
