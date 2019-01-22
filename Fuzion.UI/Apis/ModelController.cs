﻿using Fuzion.UI.Core.Models;
using Fuzion.UI.Persistence.Extensions;
using Fuzion.UI.Persistence.Filters;
using Fuzion.UI.Persistence.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Fuzion.UI.Apis
{
    [Route("api/models")]
    public class ModelController : Controller
    {
        private IUnitOfWork _uow;

        public ModelController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        [HttpGet]
        public async Task<ActionResult> Models()
        {
            var models = await _uow.Models.GetAllModelsAsync();
            return Ok(models);
        }

        [HttpGet("{id}", Name = "GetModelById")]
        public async Task<ActionResult> Models(int id)
        {
            var model = await _uow.Models.GetModelByIdAsync(id);

            if (model.IsEmptyObject())
            {
                return NotFound();
            }

            return Ok(model);
        }

        [HttpPost]
        [ModelValidation]
        public async Task<ActionResult> CreateModel([FromBody] Model model)
        {
            await _uow.Models.CreateModelAsync(model);
            return CreatedAtRoute("GetModelById", new { id = model.Id }, model);
        }

        [HttpPut("{id}")]
        [ModelValidation]
        public async Task<ActionResult> UpdateModel([FromBody] Model modelUpdate)
        {
            if (modelUpdate.IsObjectNull())
            {
                return BadRequest("Object is null");
            }

            var model = await _uow.Models.GetModelByIdAsync(modelUpdate.Id);
            if (model.IsEmptyObject())
            {
                return NotFound();
            }

            await _uow.Models.UpdateModelAsync(modelUpdate);
            return CreatedAtRoute("GetModelById", new { id = modelUpdate.Id }, modelUpdate);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteModel(int id)
        {
            var model = await _uow.Models.GetModelByIdAsync(id);
            if (model.IsEmptyObject())
            {
                return NotFound();
            }

            await _uow.Models.DeleteModelAsync(model);
            return NoContent();
        }
    }
}