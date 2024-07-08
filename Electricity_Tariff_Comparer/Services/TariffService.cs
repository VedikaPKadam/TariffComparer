using Electricity_Tariff_Comparer.Provider;
using Electricity_Tariff_Comparer.Services.Dtos;

namespace Electricity_Tariff_Comparer.Services
{
    public class TariffService : ITariffService
    {
        private readonly IElectricityTariffProvider _electricityTariffProvider;

        public TariffService(IElectricityTariffProvider electricityTariffProvider)
        {
            _electricityTariffProvider = electricityTariffProvider;
        }

        ///<inheritdoc/>
        public List<TariffComparisonResult> CompareTariffs(int consumption)
        {
            var tariffs = _electricityTariffProvider.GetTariffs();

            var results = tariffs.Select(tariff => new TariffComparisonResult
            {
                TariffName = tariff.Name,
                AnnualCost = tariff.CalculateAnnualCost(consumption)
            })
            .OrderBy(result => result.AnnualCost)
            .ToList();

            return results;
        }
    }
}


