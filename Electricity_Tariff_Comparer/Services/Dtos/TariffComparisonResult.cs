namespace Electricity_Tariff_Comparer.Services.Dtos
{
    public class TariffComparisonResult
    {
        /// <summary>
        /// The name of the tariff package.
        /// </summary>
        public string TariffName { get; set; }

        /// <summary>
        /// The annual fixed cost.
        /// </summary>
        public decimal AnnualCost { get; set; }
    }
}
