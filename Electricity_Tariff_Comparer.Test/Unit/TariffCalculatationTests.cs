using Electricity_Tariff_Comparer.Models;

namespace Electricity_Tariff_Comparer.Test.Unit
{
    public class TariffCalculationTests
    {
        [Theory]
        [InlineData(3500, 830)]
        [InlineData(4500, 1050)]
        [InlineData(6000, 1380)]
        [InlineData(0, 60)]
        public void BasicTariff_CalculateAnnualCost_Consumption(int annualConsumption, decimal expectedTariff)
        {
            // Arrange
            var tariff = new BasicTariff
            {
                BaseCostPerMonth = 5,
                AdditionalKwhCost = 22
            };

            // Act
            decimal annualCost = tariff.CalculateAnnualCost(annualConsumption);

            // Assert
            Assert.Equal(expectedTariff, annualCost);
        }

        [Theory]
        [InlineData(3500, 800)]
        [InlineData(4500, 950)]
        [InlineData(6000, 1400)]
        [InlineData(0, 800)]
        public void PackagedTariff_CalculateAnnualCost_Consumption(int annualConsumption, decimal expectedTariff)
        {
            // Arrange
            var tariff = new PackagedTariff
            {
                BaseCost = 800,
                IncludedKwh = 4000,
                AdditionalKwhCost = 30
            };

            // Act
            decimal annualCost = tariff.CalculateAnnualCost(annualConsumption);

            // Assert
            Assert.Equal(expectedTariff, annualCost);
        }
    }
}