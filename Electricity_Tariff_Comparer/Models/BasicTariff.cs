namespace Electricity_Tariff_Comparer.Models
{
    public class BasicTariff : Tariff
    {
        /// <summary>
        /// The base tarrif per month.
        /// </summary>
        public decimal BaseCostPerMonth { get; set; }

        /// <summary>
        /// The additional cost per kWh.
        /// </summary>
        public decimal AdditionalKwhCost { get; set; }

        ///<inheritdoc/>
        public override decimal CalculateAnnualCost(int annualConsumption)
        {
            return (BaseCostPerMonth * 12) + (annualConsumption * AdditionalKwhCost / 100);
        }
    }
}
