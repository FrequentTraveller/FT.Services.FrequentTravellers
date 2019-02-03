using FT.Common.Types;
using System;
using static FT.Services.FrequentFlyers.Enums.TicketEnums;

namespace FT.Services.FrequentFlyers.Dto
{
    public class TicketDto : IDto
    {
        public Guid Id { get; protected set; }
        public Guid FlightId { get; protected set; }
        public Class Class { get; protected set; }
        public TypeOfTicket TypeOfTicket { get; protected set; }
    }
}
