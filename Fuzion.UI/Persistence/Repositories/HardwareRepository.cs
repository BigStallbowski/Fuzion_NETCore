using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fuzion.UI.Core.Context;
using Fuzion.UI.Core.Models;
using Fuzion.UI.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Fuzion.UI.Persistence.Repositories
{
    public class HardwareRepository : Repository<Hardware>, IHardwareRepository
    {
        public HardwareRepository(FuzionDbContext ctx) : base(ctx)
        {
        }

        public FuzionDbContext FuzionContext => _ctx as FuzionDbContext;

        public async Task<IEnumerable<Hardware>> GetAllWithDetails()
        {
            return await FuzionContext.Hardware
                .Include(h => h.HardwareType)
                .Include(h => h.Manufacturer)
                .Include(h => h.Model)
                .Include(h => h.OS)
                .Include(h => h.Purpose)
                .OrderBy(h => h.AssetNumber)
                .ToListAsync();
        }
    }
}