using FT.Common.Handlers;
using FT.Services.FrequentFlyers.Dto;
using FT.Services.FrequentFlyers.Queries;
using FT.Services.FrequentFlyers.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FT.Services.FrequentFlyers.Handlers.FrequentFlyers
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
