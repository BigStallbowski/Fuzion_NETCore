using Fuzion.UI.Core.Models;
using Fuzion.UI.Persistence.DTOS;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fuzion.UI.Persistence.Interfaces
{
    public interface IHardwareRepository
    {
        Task<IEnumerable<Hardware>> GetAllHardwareWithDetails();

        Task<Hardware> GetHardwareById(int id);

        Task<HardwareCounts> GetHardwareCounts();

        Task<Hardware> CreateHardware(Hardware hardware);

        Task UpdateHardware(Hardware hardware);

        Task DeleteHardware(Hardware hardware);

        Task AssignHardware(Hardware hardware);

        Task UnassignHardware(Hardware hardware);

        Task RetireHardware(Hardware hardware);
    }
}