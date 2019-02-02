using DFF.Common.Types;
using System;
using static DFF.Services.FrequentFlyers.Enums.TicketEnums;

namespace DFF.Services.FrequentFlyers.Domain
{
    public class Ticket : IIdentifiable
    {
        public Guid Id { get; protected set; }
        public Guid FrequentFlyerId { get; protected set; }
        public Guid FlightId { get; protected set; }
        public Guid AirLineId { get; protected set; }
        public ushort Seat { get; protected set; }
        public Class Class { get; protected set; }
        public decimal Price { get; protected set; }
        public bool Deleted { get; protected set; }
    }
}
