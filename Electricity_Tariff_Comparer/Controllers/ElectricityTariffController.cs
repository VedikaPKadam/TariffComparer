using Electricity_Tariff_Comparer.Services;
using Electricity_Tariff_Comparer.Services.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Electricity_Tariff_Comparer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ElectricityTariffController : ControllerBase
    {
        private readonly ITariffService _tariffService;

        public ElectricityTariffController(ITariffService tariffService)
        {
            _tariffService = tariffService;
        }

        [HttpGet("compare")]
        public ActionResult<List<TariffComparisonResult>> Compare(int consumption)
        {
            var results = _tariffService.CompareTariffs(consumption);
            return Ok(results);
        }
    }
}
