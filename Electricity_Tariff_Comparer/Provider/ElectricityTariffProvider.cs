using Electricity_Tariff_Comparer.Models;

namespace Electricity_Tariff_Comparer.Provider
{
    public class ElectricityTariffProvider: IElectricityTariffProvider
    {
        ///<inheritdoc/>
        public List<Tariff> GetTariffs()
        {
            return new List<Tariff>
            {
                new BasicTariff
                {
                    Name = "Product A",
                    BaseCostPerMonth = 5,
                    AdditionalKwhCost = 22
                },
                new PackagedTariff
                {
                    Name = "Product B",
                    IncludedKwh = 4000,
                    BaseCost = 800,
                    AdditionalKwhCost = 30
                }
            };
        }
    }
}
