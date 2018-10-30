using System.Collections.Generic;
using System.Threading.Tasks;
using Fuzion.UI.Core.Models;

namespace Fuzion.UI.Persistence.Interfaces
{
    public interface IAssignmentHistoryRepository
    {
        Task<IEnumerable<AssignmentHistory>> GetAssignmentHistoryForHardware(int hardwareId);
    }
}