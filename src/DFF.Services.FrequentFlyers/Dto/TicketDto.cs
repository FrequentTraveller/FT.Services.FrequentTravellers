using DFF.Common.Types;
using System;
using static DFF.Services.FrequentFlyers.Enums.TicketEnums;

namespace DFF.Services.FrequentFlyers.Dto
{
    public class TicketDto : IDto
    {
        public Guid Id { get; protected set; }
        public Guid FlightId { get; protected set; }
        public Class Class { get; protected set; }
        public TypeOfTicket TypeOfTicket { get; protected set; }
    }
}
