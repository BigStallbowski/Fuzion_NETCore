using System;
using System.Threading.Tasks;
using Fuzion.UI.Core.Models;
using Fuzion.UI.Persistence.Interfaces;
using Fuzion.UI.Persistence.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Fuzion.UI.Apis
{
    [Route("api/hardwaretypes")]
    public class HardwareTypesController : Controller
    {
        private IUnitOfWork _uow;
        private ILogger _logger;

        public HardwareTypesController(IUnitOfWork uow, ILoggerFactory loggerFactory)
        {
            _uow = uow;
            _logger = loggerFactory.CreateLogger(nameof(HardwareTypesController));
        }

        [HttpGet]
        public async Task<ActionResult> HardwareTypes()
        {
            try
            {
                var hardwareTypes = await _uow.HardwareTypes.GetAllHardwareTypesAsync();
                return Ok(hardwareTypes);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return BadRequest();
            }
        }

        [HttpGet("{id}", Name = "GetHardwareTypeById")]
        public async Task<ActionResult> HardwareTypes(int id)
        {
            try
            {
                var hardwareType = await _uow.HardwareTypes.GetHardwareTypeByIdAsync(id);
                return Ok(hardwareType);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public async Task<ActionResult> CreateHardwareType([FromBody] HardwareType hardwareType)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model");
                }

                await _uow.HardwareTypes.CreateHardwareTypeAsync(hardwareType);
                return CreatedAtRoute("GetHardwareTypeById", new { id = hardwareType.Id }, hardwareType);
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in CreateHardwareType action: {e.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateHardwareType([FromBody] HardwareType hardwareType)
        {
            try
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
                return CreatedAtRoute("GetHardwareTypeById", new {id = hardwareType.Id}, hardwareType);
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in UpdateHardwareType action: {e.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}