using DFF.Common.Messages;
using Newtonsoft.Json;
using System;

namespace DFF.Services.FrequentFlyers.Messages.Events
{
    [MessageNamespace("identity")]
    public class SignedUp : IEvent
    {
        public Guid UserId { get; }
        public string Email { get; }

        [JsonConstructor]
        public SignedUp(Guid userId, string email)
        {
            UserId = userId;
            Email = email;
        }
    }
}
