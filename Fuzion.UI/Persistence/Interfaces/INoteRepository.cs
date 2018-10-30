using System.Collections.Generic;
using System.Threading.Tasks;
using Fuzion.UI.Core.Models;

namespace Fuzion.UI.Persistence.Interfaces
{
    public interface INoteRepository
    {
        Task<IEnumerable<Note>> GetNotesForHardware(int hardwareId);
    }
}