using Fuzion.UI.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fuzion.UI.Persistence.Interfaces
{
    public interface INoteRepository
    {
        Task<IEnumerable<Note>> GetNotesForHardware(int hardwareId);

        Task<Note> GetNoteByIdAsync(int id);

        Task CreateNote(Note note);

        Task UpdateNote(Note note);

        Task DeleteNote(Note note);
    }
}