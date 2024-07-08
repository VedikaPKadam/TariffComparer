using Electricity_Tariff_Comparer.Models;
using Electricity_Tariff_Comparer.Provider;
using Electricity_Tariff_Comparer.Services;
using Moq;

namespace Electricity_Tariff_Comparer.Test.Unit.Services
{
    public class TariffServiceTests
    {
        [Fact]
        public void CompareTariffs_Consumption3500_ReturnsCorrectResults()
        {
            // Arrange
            var mockTariffProvider = new Mock<IElectricityTariffProvider>();
            mockTariffProvider.Setup(provider => provider.GetTariffs()).Returns(new List<Tariff>
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
            });

            var service = new TariffService(mockTariffProvider.Object);
            int consumption = 3500;

            // Act
            var results = service.CompareTariffs(consumption);

            // Assert
            Assert.NotNull(results);
            Assert.Equal(2, results.Count);
            Assert.Equal("Product B", results[0].TariffName);
            Assert.Equal(800, results[0].AnnualCost);
            Assert.Equal("Product A", results[1].TariffName);
            Assert.Equal(830, results[1].AnnualCost);
        }
    }
}

