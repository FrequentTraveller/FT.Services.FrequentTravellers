﻿using DFF.Services.FrequentFlyers.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DFF.Services.FrequentFlyers.Repositories
{
    public interface IFrequentFlyersRepository
    {
        Task<FrequentFlyer> GetAsync(Guid id);
        Task CreateAsync(FrequentFlyer customer);
        Task UpdateAsync(FrequentFlyer customer);
    }
}
