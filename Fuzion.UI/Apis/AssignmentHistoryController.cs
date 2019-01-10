using Fuzion.UI.Persistence.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Fuzion.UI.Apis
{
    [Route("api/assignmenthistory")]
    public class AssignmentHistoryController : Controller
    {
        private IUnitOfWork _uow;

        public AssignmentHistoryController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetAssignmentHistoryForHardware(int id)
        {
            var assignmentHistory = await _uow.AssignmentHistory.GetAssignmentHistoryForHardware(id);
            return Ok(assignmentHistory);
        }
    }
}