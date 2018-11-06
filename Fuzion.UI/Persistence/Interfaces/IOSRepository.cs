using System.Collections.Generic;
using System.Threading.Tasks;
using Fuzion.UI.Core.Models;

namespace Fuzion.UI.Persistence.Interfaces
{
    public interface IOSRepository
    {
        Task<IEnumerable<OS>> GetAllOSAsync();
        Task<OS> GetOSByIdAsync(int id);
        Task<IEnumerable<OS>> GetOSByHardwareTypeId(int id);
        Task CreateOSAsync(OS os);
        Task UpdateOSAsync(OS os);
        Task DeleteOSAsync(OS os);
    }
}