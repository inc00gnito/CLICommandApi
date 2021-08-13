using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommandsApi.Data;
using CommandsApi.Models;

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

        [HttpGet]
        public ActionResult<IEnumerable<Command>> GetAll()
        {
            var model = _contextData.GetAllCommands();
            return Ok();
        }
    }
}
