using Fuzion.UI.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fuzion.UI.Persistence.Interfaces
{
    public interface IHardwareTypeRepository
    {
        Task<IEnumerable<HardwareType>> GetAllHardwareTypesAsync();

        Task<HardwareType> GetHardwareTypeByIdAsync(int id);

        Task CreateHardwareTypeAsync(HardwareType hardwareType);

        Task UpdateHardwareTypeAsync(HardwareType hardwareType);

        Task DeleteHardwareTypeAsync(HardwareType hardwareType);
    }
}