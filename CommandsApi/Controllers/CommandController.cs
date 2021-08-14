using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommandsApi.Data;
using CommandsApi.DTOs;
using CommandsApi.Models;
using Microsoft.AspNetCore.Components.Forms;

namespace CommandsApi.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class CommandController : ControllerBase
    {
        private readonly ICommandData _contextData;

        public CommandController(ICommandData contextData)
        {
            _contextData = contextData;
        }


        /// <summary>
        /// Retrieves all commands in the database
        /// </summary>
        [HttpGet]
        public IEnumerable<CommandDto> GetAll()
        {
            var model = _contextData.GetAllCommands().Select(command => command.AsDto());
            return model;
        }
        /// <summary>
        /// Retrieves a specific command by unique id
        /// </summary>
        [HttpGet("{id}")]
        public CommandDto GetCommandById(int id)
        {
            var model = _contextData.GetCommandById(id);
            return model.AsDto();
        }

        /// <summary>
        /// Creating a command, requires filling three attributes: command name, description and platform
        /// </summary>
        [HttpPost]
        public ActionResult<CommandDto> CreateCommand(CommandCreateDto commandCreateDto)
        {
            Command command = new()
            {
                CommandName = commandCreateDto.CommandName,
                Description = commandCreateDto.Description,
                Platform = commandCreateDto.Platform
            };
            _contextData.CreateCommand(command);
            return CreatedAtAction(nameof(GetCommandById), new { id = command.Id }, command.AsDto());
        }

        /// <summary>
        /// Allows to update or change information of a command, retrieved by id
        /// </summary>
        [HttpPut("{id}")]
        public ActionResult UpdateCommand(int id,CommandUpdateDto commandUpdateDto)
        {
            var existing = _contextData.GetCommandById(id);
            if (existing == null)
                return NotFound();

            existing.CommandName = commandUpdateDto.CommandName;
            existing.Description = commandUpdateDto.Description;
            existing.Platform = commandUpdateDto.Platform;
            _contextData.UpdateCommand(existing);
            return NoContent();
        }

        /// <summary>
        /// Deletes a specific command by unique id
        /// </summary>
        [HttpDelete("{id}")]
        public ActionResult DeleteCommand(int id)
        {
            var command = _contextData.GetCommandById(id);
            if (command == null)
                return NotFound();
            _contextData.DeleteCommand(command.Id);
            return NoContent();
        }
    }
}
