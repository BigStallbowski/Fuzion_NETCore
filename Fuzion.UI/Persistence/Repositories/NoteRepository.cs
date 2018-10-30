using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fuzion.UI.Core.Context;
using Fuzion.UI.Core.Models;
using Fuzion.UI.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Fuzion.UI.Persistence.Repositories
{
    public class NoteRepository : Repository<Note>, INoteRepository
    {
        public NoteRepository(FuzionDbContext ctx) : base(ctx)
        {
        }

        public FuzionDbContext FuzionContext => _ctx as FuzionDbContext;

        public async Task<IEnumerable<Note>> GetNotesForHardware(int hardwareId)
        {
            return await FuzionContext.Notes
                .Where(x => x.Hardware.Id == hardwareId)
                .ToListAsync();
        }
    }
}