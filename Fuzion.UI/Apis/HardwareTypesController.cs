using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fuzion.UI.Core.Models;
using Fuzion.UI.Persistence.Interfaces;
using Microsoft.AspNetCore.Http;
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
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<ActionResult> CreateHardwareType([FromBody] HardwareType hardwareType)
        {
            await _uow.HardwareTypes.CreateHardwareTypeAsync(hardwareType);
            return CreatedAtRoute("GetHardwareTypeById", new {id = hardwareType.Id}, hardwareType);
        }
    }
}