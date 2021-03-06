﻿using Fuzion.UI.Core.Context;
using Fuzion.UI.Core.Models;
using Fuzion.UI.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fuzion.UI.Persistence.Repositories
{
    public class AssignmentRepository : Repository<AssignmentHistory>, IAssignmentHistoryRepository
    {
        public AssignmentRepository(FuzionDbContext ctx) : base(ctx)
        {
        }

        public FuzionDbContext FuzionContext => _ctx as FuzionDbContext;

        public async Task<IEnumerable<AssignmentHistory>> GetAssignmentHistoryForHardware(int hardwareId)
        {
            return await FuzionContext.AssignmentHistory
                .Where(x => x.Hardware.Id == hardwareId)
                .ToListAsync();
        }

        public async Task CreateAssignmentHistory(AssignmentHistory assignmentHistory)
        {
            Create(assignmentHistory);
            await SaveAsync();
        }
    }
}