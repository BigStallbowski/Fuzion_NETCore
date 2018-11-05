using System.Threading.Tasks;
using Fuzion.UI.Core.Models;
using Fuzion.UI.Persistence.Interfaces;
using Fuzion.UI.Persistence.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace Fuzion.UI.Apis
{
    [Route("api/hardwaretypes")]
    public class HardwareTypesController : Controller
    {
        private IUnitOfWork _uow;

        public HardwareTypesController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        [HttpGet]
        public async Task<ActionResult> HardwareTypes()
        {
            var hardwareTypes = await _uow.HardwareTypes.GetAllHardwareTypesAsync();
            return Ok(hardwareTypes);
        }

        [HttpGet("{id}", Name = "GetHardwareTypeById")]
        public async Task<ActionResult> HardwareTypes(int id)
        {
            var hardwareType = await _uow.HardwareTypes.GetHardwareTypeByIdAsync(id);
            return Ok(hardwareType);
        }

        [HttpPost]
        public async Task<ActionResult> CreateHardwareType([FromBody] HardwareType hardwareType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid model");
            }

            await _uow.HardwareTypes.CreateHardwareTypeAsync(hardwareType);
            return CreatedAtRoute("GetHardwareTypeById", new { id = hardwareType.Id }, hardwareType);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateHardwareType([FromBody] HardwareType hardwareType)
        {
            if (hardwareType.IsObjectNull())
            {
                return BadRequest("Object is null");
            }

            var hardwareTypeToUpdate = await _uow.HardwareTypes.GetHardwareTypeByIdAsync(hardwareType.Id);
            if (hardwareTypeToUpdate.IsEmptyObject())
            {
                return NotFound();
            }

            await _uow.HardwareTypes.UpdateHardwareTypeAsync(hardwareType);
            return CreatedAtRoute("GetHardwareTypeById", new { id = hardwareType.Id }, hardwareType);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteHardwareTask(int id)
        {
            var hardwareType = await _uow.HardwareTypes.GetHardwareTypeByIdAsync(id);
            if (hardwareType.IsEmptyObject())
            {
                return NotFound();
            }

            await _uow.HardwareTypes.DeleteHardwareAsync(hardwareType);

            return NoContent();
        }
    }
}
