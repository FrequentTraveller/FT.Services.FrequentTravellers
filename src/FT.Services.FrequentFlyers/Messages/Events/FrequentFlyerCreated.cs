using FT.Common.Messages;
using Newtonsoft.Json;
using System;

namespace FT.Services.FrequentFlyers.Messages.Events
{
    public class FrequentFlyerCreated : IEvent
    {
        public Guid Id { get; }

        [JsonConstructor]
        public FrequentFlyerCreated(Guid id)
        {
            Id = id;
        }
    }
}
