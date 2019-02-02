using DFF.Common.Handlers;
using DFF.Services.FrequentFlyers.Dto;
using DFF.Services.FrequentFlyers.Queries;
using DFF.Services.FrequentFlyers.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DFF.Services.FrequentFlyers.Handlers.FrequentFlyers
{
    public class GetFrequentFlyerHandler : IQueryHandler<GetFrequentFlyer, FrequentFlyerDto>
    {
        private readonly IFrequentFlyersRepository _frequentFlyersRepository;

        public GetFrequentFlyerHandler(IFrequentFlyersRepository frequentFlyersRepository)
        {
            _frequentFlyersRepository = frequentFlyersRepository;
        }

        public async Task<FrequentFlyerDto> HandleAsync(GetFrequentFlyer query)
        {
            var frequentFlyer = await _frequentFlyersRepository.GetAsync(query.Id);

            //TODO Converter in Common libary
            return frequentFlyer == null ? null : new FrequentFlyerDto
            {
                Id = frequentFlyer.Id,
                FirstName = frequentFlyer.FirstName,
                LastName = frequentFlyer.LastName,
                MilesInAir = frequentFlyer.MilesInAir,
                Status = frequentFlyer.Status
            };
        }
    }
}
