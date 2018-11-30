using Fuzion.UI.Core.Models;
using Fuzion.UI.Persistence.Extensions;
using Fuzion.UI.Persistence.Filters;
using Fuzion.UI.Persistence.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Fuzion.UI.Apis
{
    [Route("api/purposes")]
    public class PurposeController : Controller
    {
        private readonly IUnitOfWork _uow;

        public PurposeController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        [HttpGet]
        public async Task<ActionResult> Purposes()
        {
            var purposes = await _uow.Purposes.GetAllPurposesAsync();
            return Ok(purposes);
        }

        [HttpGet("{id}", Name = "GetPurposeById")]
        public async Task<ActionResult> Purposes(int id)
        {
            var purpose = await _uow.Purposes.GetPurposeByIdAsync(id);

            if (purpose.IsEmptyObject())
            {
                return NotFound();
            }

            return Ok(purpose);
        }

        [HttpPost]
        [ModelValidation]
        public async Task<ActionResult> CreatePurpose([FromBody] Purpose purpose)
        {
            await _uow.Purposes.CreatePurposeAsync(purpose);
            return CreatedAtRoute("GetPurposeById", new { id = purpose.Id });
        }

        [HttpPut("{id}")]
        [ModelValidation]
        public async Task<ActionResult> UpdatePurpose([FromBody] Purpose purposeToUpdate)
        {
            if (purposeToUpdate.IsObjectNull())
            {
                return BadRequest("Object is null");
            }

            var purpose = await _uow.Purposes.GetPurposeByIdAsync(purposeToUpdate.Id);
            if (purpose.IsEmptyObject())
            {
                return NotFound();
            }

            await _uow.Purposes.UpdatePurposeAsync(purposeToUpdate);
            return CreatedAtRoute("GetPurposeById", new { id = purposeToUpdate.Id }, purposeToUpdate);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePurpose(int id)
        {
            var purpose = await _uow.Purposes.GetPurposeByIdAsync(id);
            if (purpose.IsEmptyObject())
            {
                return NotFound();
            }

            await _uow.Purposes.DeletePurposeAsync(purpose);
            return NoContent();
        }
    }
}