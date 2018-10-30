using Fuzion.UI.Core.Context;
using Fuzion.UI.Core.Models;
using Fuzion.UI.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Fuzion.UI.Persistence.Repositories
{
    public class HardwareTypeRepository : Repository<HardwareType>, IHardwareTypeRepository
    {
        public HardwareTypeRepository(FuzionDbContext ctx) : base(ctx)
        {
        }

        public FuzionDbContext FuzionContext => _ctx as FuzionDbContext;
    }
}