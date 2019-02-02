using DFF.Common.Dispatchers;
using DFF.Services.FrequentFlyers.Dto;
using DFF.Services.FrequentFlyers.Queries;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DFF.Services.FrequentFlyers.Controllers
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
