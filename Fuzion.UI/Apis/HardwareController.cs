using System.Threading.Tasks;
using Fuzion.UI.Core.Models;
using Fuzion.UI.Persistence.Extensions;
using Fuzion.UI.Persistence.Filters;
using Fuzion.UI.Persistence.Interfaces;
using Microsoft.AspNetCore.Mvc;

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
        [ModelValidation]
        public async Task<ActionResult> CreateHardware([FromBody] Hardware hardware)
        {
            await _uow.Hardware.CreateHardware(hardware);
            return CreatedAtRoute("GetHardwareById", new {id = hardware.Id}, hardware);
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
            return CreatedAtRoute("GetHardwareById", new {id = hardware.Id}, hardware);
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