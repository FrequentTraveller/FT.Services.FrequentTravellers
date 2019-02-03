using FT.Common.Types;
using FT.Services.FrequentFlyers.Dto;
using System;

namespace FT.Services.FrequentFlyers.Queries
{
    public class GetFrequentFlyer : IQuery<FrequentFlyerDto>
    {
        public Guid Id { get; set; }
    }
}
