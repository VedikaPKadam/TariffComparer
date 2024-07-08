namespace Electricity_Tariff_Comparer.Models
{
    public class PackagedTariff : Tariff
    {
        /// <summary>
        /// The included electricity units in base cost.
        /// </summary>
        public int IncludedKwh { get; set; }

        /// <summary>
        /// The base tariff per month.
        /// </summary>
        public decimal BaseCost { get; set; }

        /// <summary>
        /// The additional cost per kWh.
        /// </summary>
        public decimal AdditionalKwhCost { get; set; }

        ///<inheritdoc/>
        public override decimal CalculateAnnualCost(int annualConsumption)
        {
            if (annualConsumption <= IncludedKwh)
            {
                return BaseCost;
            }
            else
            {
                return BaseCost + ((annualConsumption - IncludedKwh) * AdditionalKwhCost / 100);
            }
        }
    }
}
