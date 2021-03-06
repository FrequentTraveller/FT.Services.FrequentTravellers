﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FT.Common.Mongo;
using FT.Services.FrequentFlyers.Domain;

namespace FT.Services.FrequentFlyers.Repositories
{
    public class FrequentFlyersRepository : IFrequentFlyersRepository
    {
        private readonly IMongoRepository<FrequentFlyer> _repository;

        public FrequentFlyersRepository(IMongoRepository<FrequentFlyer> repository)
        {
            _repository = repository;
        }

        public async Task CreateAsync(FrequentFlyer customer)
            => await _repository.CreateAsync(customer);

        public async Task<FrequentFlyer> GetAsync(Guid id)
            => await _repository.GetAsync(id);

        public async Task UpdateAsync(FrequentFlyer customer)
            => await _repository.UpdateAsync(customer);
    }
}
