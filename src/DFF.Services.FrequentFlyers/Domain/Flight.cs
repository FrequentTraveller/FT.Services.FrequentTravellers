using DFF.Common.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DFF.Services.FrequentFlyers.Domain
{
    public class Flight : IIdentifiable
    {
        public Guid Id { get; protected set; }
        public Guid AirLineId { get; protected set; }
        public Guid PlainId { get; protected set; }
        public Airport Start { get; protected set; }
        public Airport End { get; protected set; }
        public double Distance { get; protected set; }
        public bool Deleted { get; protected set; }
    }
}
