using DFF.Common.Types;
using DFF.Services.FrequentFlyers.Dto;
using System;

namespace DFF.Services.FrequentFlyers.Queries
{
    public class GetFrequentFlyer : IQuery<FrequentFlyerDto>
    {
        public Guid Id { get; set; }
    }
}
