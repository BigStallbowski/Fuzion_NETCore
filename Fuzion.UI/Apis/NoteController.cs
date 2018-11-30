using Fuzion.UI.Core.Models;
using Fuzion.UI.Persistence.Extensions;
using Fuzion.UI.Persistence.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Fuzion.UI.Apis
{
    [Route("api/notes")]
    public class NoteController : Controller
    {
        private IUnitOfWork _uow;

        public NoteController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetNotesForHardware(int id)
        {
            var notes = await _uow.Notes.GetNotesForHardware(id);
            return Ok(notes);
        }

        [HttpPost]
        public async Task<ActionResult> CreateNote([FromBody] Note note)
        {
            await _uow.Notes.CreateNote(note);
            return Ok(note);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteNote(int id)
        {
            var note = await _uow.Notes.GetNoteByIdAsync(id);
            if (note.IsEmptyObject())
            {
                return NotFound();
            }

            await _uow.Notes.DeleteNote(note);
            return NoContent();
        }
    }
}