using DFF.Common.Handlers;
using DFF.Common.RabbitMq;
using DFF.Common.Types;
using DFF.Services.FrequentFlyers.Messages.Commands;
using DFF.Services.FrequentFlyers.Messages.Events;
using DFF.Services.FrequentFlyers.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DFF.Services.FrequentFlyers.Handlers.FrequentFlyers
{
    public class CreateFrequentFlyerHandler : ICommandHandler<CreateFrequentFlyer>
    {
        private readonly IBusPublisher _busPublisher;
        private readonly IFrequentFlyersRepository _frequentFlyersRepository;
        private readonly IHandler _handler;

        public CreateFrequentFlyerHandler(IBusPublisher busPublisher,
            IFrequentFlyersRepository frequentFlyersRepository, IHandler handler)
        {
            _busPublisher = busPublisher;
            _frequentFlyersRepository = frequentFlyersRepository;
            _handler = handler;
        }

        public async Task HandleAsync(CreateFrequentFlyer command, ICorrelationContext context)
            => await _handler.Handle(async () =>
            {
                var frequentFlyer = await _frequentFlyersRepository.GetAsync(command.Id);
                if (frequentFlyer.Completed)
                {
                    throw new DFFException(Codes.FrequentFlyerAlreadyCompleted,
                        $"Frequent flyer account was already completed for user: '{command.Id}'.");
                }
                frequentFlyer.Complete(command.FirstName, command.LastName, command.Address, command.Country);
                await _frequentFlyersRepository.UpdateAsync(frequentFlyer);

                await _busPublisher.PublishAsync(new FrequentFlyerCreated(command.Id), context);
            })
                .OnCustomError(async ex => await _busPublisher.PublishAsync(
                        new CreateFrequentFlyerRejected(command.Id, ex.Message, ex.Code), context)
                )
                .OnError(async ex => await _busPublisher.PublishAsync(
                        new CreateFrequentFlyerRejected(command.Id, ex.Message, string.Empty), context)
                )
                .ExecuteAsync();
    }
}
