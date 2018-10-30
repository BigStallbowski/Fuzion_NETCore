﻿using System.Threading.Tasks;
using Fuzion.UI.Core.Context;
using Fuzion.UI.Persistence.Interfaces;
using Fuzion.UI.Persistence.Repositories;

namespace Fuzion.UI.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly FuzionDbContext _ctx;

        public IHardwareRepository Hardware { get; set; }
        public IHardwareTypeRepository HardwareTypes { get; set; }
        public INoteRepository Notes { get; set; }
        public IAssignmentHistoryRepository AssignmentHistory { get; set; }

        public UnitOfWork(FuzionDbContext ctx)
        {
            _ctx = ctx;
            Hardware = new HardwareRepository(_ctx);
            HardwareTypes = new HardwareTypeRepository(_ctx);
            Notes = new NoteRepository(_ctx);
            AssignmentHistory = new AssignmentRepository(_ctx);
        }

        public async Task<int> Complete()
        {
            return await _ctx.SaveChangesAsync();
        }

        public void Dispose()
        {
            _ctx.Dispose();
        }
    }
}