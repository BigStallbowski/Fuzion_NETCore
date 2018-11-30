﻿using Fuzion.UI.Core.Context;
using Fuzion.UI.Core.Models;
using Fuzion.UI.Persistence.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fuzion.UI.Persistence.Repositories
{
    public class OSRepository : Repository<OS>, IOSRepository
    {
        public OSRepository(FuzionDbContext ctx) : base(ctx)
        {
        }

        public async Task<IEnumerable<OS>> GetAllOSAsync()
        {
            var operatingSystems = await FindAllAsync();
            return operatingSystems.OrderBy(x => x.Name);
        }

        public async Task<OS> GetOSByIdAsync(int id)
        {
            var operatingSystem = await FindByConditionAsync(x => x.Id.Equals(id));
            return operatingSystem.FirstOrDefault();
        }

        public async Task CreateOSAsync(OS os)
        {
            Create(os);
            await SaveAsync();
        }

        public async Task UpdateOSAsync(OS os)
        {
            Update(os);
            await SaveAsync();
        }

        public async Task DeleteOSAsync(OS os)
        {
            _ctx.Remove(os);
            await SaveAsync();
        }
    }
}