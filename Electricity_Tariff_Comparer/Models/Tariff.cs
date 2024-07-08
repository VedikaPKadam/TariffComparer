namespace Electricity_Tariff_Comparer.Models
{
    public abstract class Tariff
    {
        /// <summary>
        /// The package name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Calculate total annual cost.
        /// </summary>
        /// <param name="annualConsumption"> The annual electricty consuption. </param>
        /// <returns> The annual cost incurred.</returns>
        public abstract decimal CalculateAnnualCost(int annualConsumption);
    }
}
