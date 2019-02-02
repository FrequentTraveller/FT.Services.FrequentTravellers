using DFF.Common.Types;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static DFF.Services.FrequentFlyers.Enums.FrequentFlyerEnums;

namespace DFF.Services.FrequentFlyers.Dto
{
    public class FrequentFlyerDto : IDto
    {
        public Guid Id { get; set; }
        public string FullName => FirstName + " " + LastName;
        [JsonIgnore]
        public string FirstName { get; set; }
        [JsonIgnore]
        public string LastName { get; set; }
        public int MilesInAir { get; set; }
        public FrequentFlyerStatus Status { get; set; }
        public ICollection<TicketDto> Tickets { get; set; }
    }
}
