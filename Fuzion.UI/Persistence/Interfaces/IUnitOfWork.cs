using System;
using System.Threading.Tasks;

namespace Fuzion.UI.Persistence.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IHardwareRepository Hardware { get; set; }
        IHardwareTypeRepository HardwareTypes { get; set; }
        IManufacturerRepository Manufacturers { get; set; }
        INoteRepository Notes { get; set; }
        IAssignmentHistoryRepository AssignmentHistory { get; set; }
    }
}