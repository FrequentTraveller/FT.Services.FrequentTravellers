using FT.Common.Messages;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FT.Services.FrequentFlyers.Messages.Events
{
    public class CreateFrequentFlyerRejected : RejectedEvent
    {
        public Guid Id { get; }

        [JsonConstructor]
        public CreateFrequentFlyerRejected(Guid id, string reason, string code) : base(reason, code)
        {
            Id = id;
        }
    }
}
