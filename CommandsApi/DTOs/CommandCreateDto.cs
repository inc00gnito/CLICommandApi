using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommandsApi.Models;

namespace CommandsApi.DTOs
{
    public record CommandCreateDto
    {
        public string CommandName { get; set; }
        public string Description { get; set; }
        public string Platform { get; set; }
    }
}
