using Fuzion.UI.Core.Models;
using Fuzion.UI.Persistence.Extensions;
using Fuzion.UI.Persistence.Filters;
using Fuzion.UI.Persistence.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

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

            if (hardwareType.IsEmptyObject())
            {
                return NotFound();
            }

            return Ok(hardwareType);
        }

        [HttpPost]
        [ModelValidation]
        public async Task<ActionResult> CreateHardwareType([FromBody] HardwareType hardwareType)
        {
            await _uow.HardwareTypes.CreateHardwareTypeAsync(hardwareType);
            return CreatedAtRoute("GetHardwareTypeById", new { id = hardwareType.Id }, hardwareType);
        }

        [HttpPut("{id}")]
        [ModelValidation]
        public async Task<ActionResult> UpdateHardwareType([FromBody] HardwareType hardwareTypeUpdate)
        {
            if (hardwareTypeUpdate.IsObjectNull())
            {
                return BadRequest("Object is null");
            }

            var hardwareType = await _uow.HardwareTypes.GetHardwareTypeByIdAsync(hardwareTypeUpdate.Id);
            if (hardwareType.IsEmptyObject())
            {
                return NotFound();
            }

            await _uow.HardwareTypes.UpdateHardwareTypeAsync(hardwareTypeUpdate);
            return CreatedAtRoute("GetHardwareTypeById", new { id = hardwareTypeUpdate.Id }, hardwareTypeUpdate);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteHardwareType(int id)
        {
            var hardwareType = await _uow.HardwareTypes.GetHardwareTypeByIdAsync(id);
            if (hardwareType.IsEmptyObject())
            {
                return NotFound();
            }

            await _uow.HardwareTypes.DeleteHardwareTypeAsync(hardwareType);
            return NoContent();
        }
    }
}