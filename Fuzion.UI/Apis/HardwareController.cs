using Fuzion.UI.Core.Models;
using Fuzion.UI.Persistence.Extensions;
using Fuzion.UI.Persistence.Filters;
using Fuzion.UI.Persistence.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Fuzion.UI.Apis
{
    [Route("api/hardware")]
    public class HardwareController : Controller
    {
        private IUnitOfWork _uow;

        public HardwareController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        [HttpGet]
        public async Task<ActionResult> Hardware()
        {
            var hardware = await _uow.Hardware.GetAllHardwareWithDetails();
            return Ok(hardware);
        }

        [HttpGet("{id}", Name = "GetHardwareById")]
        public async Task<ActionResult> Hardware(int id)
        {
            var hardware = await _uow.Hardware.GetHardwareById(id);

            if (hardware.IsEmptyObject())
            {
                return NotFound();
            }

            return Ok(hardware);
        }

        [HttpGet("hardwarecounts")]
        public async Task<ActionResult> HardwareCounts()
        {
            var hardwareCounts = await _uow.Hardware.GetHardwareCounts();
            return Ok(hardwareCounts);
        }

        [HttpPost]
        public async Task<ActionResult> CreateHardware([FromBody] Hardware hardware)
        {
            var newHardware = await _uow.Hardware.CreateHardware(hardware);
            return Ok(new ApiResponse<Hardware> { Status = true, Model = newHardware });
        }

        [HttpPut("{id}")]
        [ModelValidation]
        public async Task<ActionResult> UpdateHardware([FromBody] Hardware hardwareToUpdate)
        {
            if (hardwareToUpdate.IsObjectNull())
            {
                return BadRequest("Object is null");
            }

            var hardware = await _uow.Hardware.GetHardwareById(hardwareToUpdate.Id);
            if (hardware.IsEmptyObject())
            {
                return NotFound();
            }

            await _uow.Hardware.UpdateHardware(hardwareToUpdate);
            return CreatedAtRoute("GetHardwareById", new { id = hardware.Id }, hardware);
        }

        [HttpPut("{id}/assign")]
        public async Task<ActionResult> AssignHardware([FromBody] Hardware hardwareToAssign)
        {
            if (hardwareToAssign.IsObjectNull())
            {
                return BadRequest("Object is null");
            }
            if (string.IsNullOrEmpty(hardwareToAssign.AssignedTo))
            {
                return BadRequest("Assigned To Field Required");
            }

            var hardware = await _uow.Hardware.GetHardwareById(hardwareToAssign.Id);
            if (hardware.IsEmptyObject())
            {
                return NotFound();
            }

            await _uow.Hardware.AssignHardware(hardwareToAssign);

            var assignmentHistory = new AssignmentHistory
            {
                HardwareId = hardwareToAssign.Id,
                Body = $"Assigned To: {hardwareToAssign.AssignedTo}"
            };
            await _uow.AssignmentHistory.CreateAssignmentHistory(assignmentHistory);

            return CreatedAtRoute("GetHardwareById", new { id = hardwareToAssign.Id, hardwareToAssign });
        }

        [HttpPut("{id}/unassign")]
        public async Task<ActionResult> UnassignHardware([FromBody] Hardware hardwareToUnassign)
        {
            if (hardwareToUnassign.IsObjectNull())
            {
                return BadRequest("Object is null");
            }
            if (string.IsNullOrEmpty(hardwareToUnassign.AssignedTo))
            {
                return BadRequest("Assigned To Field Required");
            }

            var hardware = await _uow.Hardware.GetHardwareById(hardwareToUnassign.Id);
            if (hardware.IsEmptyObject())
            {
                return NotFound();
            }

            await _uow.Hardware.UnassignHardware(hardwareToUnassign);

            var assignmentHistory = new AssignmentHistory
            {
                HardwareId = hardwareToUnassign.Id,
                Body = "Unassigned"
            };
            await _uow.AssignmentHistory.CreateAssignmentHistory(assignmentHistory);

            return CreatedAtRoute("GetHardwareById", new { id = hardwareToUnassign.Id, hardwareToUnassign });
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteHardware(int id)
        {
            var hardware = await _uow.Hardware.GetHardwareById(id);
            if (hardware.IsEmptyObject())
            {
                return NotFound();
            }

            await _uow.Hardware.DeleteHardware(hardware);
            return NoContent();
        }
    }
}