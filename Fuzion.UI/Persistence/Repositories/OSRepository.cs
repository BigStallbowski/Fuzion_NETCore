using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;
using Fuzion.UI.Core.Context;
using Fuzion.UI.Core.Models;
using Fuzion.UI.Persistence.Interfaces;

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
            return operatingSystem.DefaultIfEmpty(new OS())
                .FirstOrDefault();
        }

        public async Task<IEnumerable<OS>> GetOSByHardwareTypeId(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task CreateOSAsync(OS os)
        {
            throw new System.NotImplementedException();
        }

        public async Task UpdateOSAsync(OS os)
        {
            throw new System.NotImplementedException();
        }

        public async Task DeleteOSAsync(OS os)
        {
            throw new System.NotImplementedException();
        }
    }
}