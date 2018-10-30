using System.Collections.Generic;
using System.Threading.Tasks;
using Fuzion.UI.Core.Models;

namespace Fuzion.UI.Persistence.Interfaces
{
    public interface IHardwareRepository
    {
        Task<IEnumerable<Hardware>> GetAllWithDetails();
    }
}