using System.Collections.Generic;
using System.Threading.Tasks;
using Fuzion.UI.Core.Models;

namespace Fuzion.UI.Persistence.Interfaces
{
    public interface IHardwareRepository
    {
        Task<IEnumerable<Hardware>> GetAllHardwareWithDetails();
        Task<Hardware> GetHardwareById(int id);
        Task<int> TotalHardwareCount();
        Task<int> TotalDeployedCount();
        Task<int> TotalAvailableWorkstationCount();
        Task<int> TotalAvailableLaptopCount();
        Task<int> TotalAvailableMobileCount();
        Task CreateHardware(Hardware hardware);
        Task UpdateHardware(Hardware hardware);
        Task DeleteHardware(Hardware hardware);
        Task AssignHardware(Hardware hardware);
        Task UnassignHardware(Hardware hardware);
        Task RetireHardware(Hardware hardware);
    }
}