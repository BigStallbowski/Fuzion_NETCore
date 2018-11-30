using Fuzion.UI.Core.Context;
using Fuzion.UI.Core.Models;
using Fuzion.UI.Persistence.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fuzion.UI.Persistence.Repositories
{
    public class HardwareTypeRepository : Repository<HardwareType>, IHardwareTypeRepository
    {
        public HardwareTypeRepository(FuzionDbContext ctx) : base(ctx)
        {
        }

        public async Task<IEnumerable<HardwareType>> GetAllHardwareTypesAsync()
        {
            var hardwareTypes = await FindAllAsync();
            return hardwareTypes.OrderBy(x => x.Name);
        }

        public async Task<HardwareType> GetHardwareTypeByIdAsync(int id)
        {
            var hardwareType = await FindByConditionAsync(x => x.Id.Equals(id));
            return hardwareType.FirstOrDefault();
        }

        public async Task CreateHardwareTypeAsync(HardwareType hardwareType)
        {
            Create(hardwareType);
            await SaveAsync();
        }

        public async Task UpdateHardwareTypeAsync(HardwareType hardwareType)
        {
            Update(hardwareType);
            await SaveAsync();
        }

        public async Task DeleteHardwareTypeAsync(HardwareType hardwareType)
        {
            Delete(hardwareType);
            await SaveAsync();
        }
    }
}