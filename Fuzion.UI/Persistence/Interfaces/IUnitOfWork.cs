using System;

namespace Fuzion.UI.Persistence.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IHardwareRepository Hardware { get; set; }
        IHardwareTypeRepository HardwareTypes { get; set; }
        IManufacturerRepository Manufacturers { get; set; }
        IModelRepository Models { get; set; }
        INoteRepository Notes { get; set; }
        IOSRepository OS { get; set; }
        IPurposeRepository Purposes { get; set; }
        IAssignmentHistoryRepository AssignmentHistory { get; set; }
    }
}