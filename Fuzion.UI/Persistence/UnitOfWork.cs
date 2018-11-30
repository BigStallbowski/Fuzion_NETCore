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
        public IManufacturerRepository Manufacturers { get; set; }
        public IModelRepository Models { get; set; }
        public INoteRepository Notes { get; set; }
        public IOSRepository OS { get; set; }
        public IPurposeRepository Purposes { get; set; }
        public IAssignmentHistoryRepository AssignmentHistory { get; set; }

        public UnitOfWork(FuzionDbContext ctx)
        {
            _ctx = ctx;
            Hardware = new HardwareRepository(_ctx);
            HardwareTypes = new HardwareTypeRepository(_ctx);
            Manufacturers = new ManufacturerRepository(_ctx);
            Models = new ModelRepository(_ctx);
            Notes = new NoteRepository(_ctx);
            OS = new OSRepository(_ctx);
            Purposes = new PurposeRepository(_ctx);
            AssignmentHistory = new AssignmentRepository(_ctx);
        }

        public void Dispose()
        {
            _ctx.Dispose();
        }
    }
}