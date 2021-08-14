using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommandsApi.DTOs;
using CommandsApi.Models;

namespace CommandsApi
{
    public static class Extensions
    {
        public static CommandDto AsDto(this Command command)
        {
            return new CommandDto
            {
                Id = command.Id,
                CommandName = command.CommandName,
                Description = command.Description,
                Platform = command.Platform
            };
        }
    }
}
