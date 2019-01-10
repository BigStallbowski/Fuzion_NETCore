using Fuzion.UI.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fuzion.UI.Persistence.Interfaces
{
    public interface IAssignmentHistoryRepository
    {
        Task<IEnumerable<AssignmentHistory>> GetAssignmentHistoryForHardware(int hardwareId);

        Task CreateAssignmentHistory(AssignmentHistory assignmentHistory);
    }
}