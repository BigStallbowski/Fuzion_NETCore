using Fuzion.UI.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fuzion.UI.Persistence.Interfaces
{
    public interface IOSRepository
    {
        Task<IEnumerable<OS>> GetAllOSAsync();

        Task<OS> GetOSByIdAsync(int id);

        Task CreateOSAsync(OS os);

        Task UpdateOSAsync(OS os);

        Task DeleteOSAsync(OS os);
    }
}