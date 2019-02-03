using FT.Common.Handlers;
using FT.Common.RabbitMq;
using FT.Services.FrequentFlyers.Domain;
using FT.Services.FrequentFlyers.Messages.Events;
using FT.Services.FrequentFlyers.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FT.Services.FrequentFlyers.Handlers.Identity
{
    public class SignedUpHandler : IEventHandler<SignedUp>
    {
        private readonly IHandler _handler;
        private readonly IFrequentFlyersRepository _frequentFlyersRepository;

        public SignedUpHandler(IHandler handler,
            IFrequentFlyersRepository frequentFlyersRepository)
        {
            _handler = handler;
            _frequentFlyersRepository = frequentFlyersRepository;
        }

        public async Task HandleAsync(SignedUp @event, ICorrelationContext context)
            => await _handler.Handle(async () =>
            {
                var frequentFlyer = new FrequentFlyer(@event.UserId, @event.Email);
                await _frequentFlyersRepository.CreateAsync(frequentFlyer);
            }).ExecuteAsync();
    }
}
