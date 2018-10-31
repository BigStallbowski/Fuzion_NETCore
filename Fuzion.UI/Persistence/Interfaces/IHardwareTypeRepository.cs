using System.Collections.Generic;
using System.Threading.Tasks;
using Fuzion.UI.Core.Models;

namespace Fuzion.UI.Persistence.Interfaces
{
    public interface IHardwareTypeRepository
    {
        Task<IEnumerable<HardwareType>> GetAllHardwareTypesAsync();
        Task<HardwareType> GetHardwareTypeByIdAsync(int id);
        Task CreateHardwareTypeAsync(HardwareType hardwareType);
        Task UpdateHardwareTypeAsync(HardwareType hardwareType);
        Task DeleteHardwareAsync(HardwareType hardwareType);
    }
}