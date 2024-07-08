using Electricity_Tariff_Comparer.Services.Dtos;
using System.Net.Http.Json;

namespace Electricity_Tariff_Comparer.Test.Integration
{
    public class ElectricityTariffControllerTests : IClassFixture<CustomWebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;
        public ElectricityTariffControllerTests(CustomWebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task Compare_Consumption_ReturnsExpectedResults()
        {
            // Arrange
            int consumption = 4500;
            var expectedResults = new List<TariffComparisonResult>
            {
                new() { TariffName = "Product B", AnnualCost = 950 },
                new() { TariffName = "Product A", AnnualCost = 1050 }
            };

            // Act
            var response = await _client.GetAsync($"/api/electricityTariff/compare?consumption={consumption}");

            // Assert
            response.EnsureSuccessStatusCode();
            var results = await response.Content.ReadFromJsonAsync<List<TariffComparisonResult>>();
            Assert.Equal(expectedResults.Count, results.Count);
            for (int i = 0; i < expectedResults.Count; i++)
            {
                Assert.Equal(expectedResults[i].TariffName, results[i].TariffName);
                Assert.Equal(expectedResults[i].AnnualCost, results[i].AnnualCost);
            }
        }
    }
}
