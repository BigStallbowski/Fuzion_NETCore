using System.Collections.Generic;
using System.Threading.Tasks;
using Fuzion.UI.Core.Models;

namespace Fuzion.UI.Persistence.Interfaces
{
    public interface IPurposeRepository
    {
        Task<IEnumerable<Purpose>> GetAllPurposesAsync();
        Task<Purpose> GetPurposeByIdAsync(int id);
        Task CreatePurposeAsync(Purpose os);
        Task UpdatePurposeAsync(Purpose os);
        Task DeletePurposeAsync(Purpose os);
    }
}