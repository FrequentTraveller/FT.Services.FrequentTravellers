using FT.Common.Dispatchers;
using FT.Services.FrequentFlyers.Dto;
using FT.Services.FrequentFlyers.Queries;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FT.Services.FrequentFlyers.Controllers
{
    public class FrequentFlyersController : BaseController
    {
        public FrequentFlyersController(IDispatcher dispatcher) : base(dispatcher)
        {
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FrequentFlyerDto>> Get([FromRoute] GetFrequentFlyer query)
            => Single(await QueryAsync(query));
    }
}
