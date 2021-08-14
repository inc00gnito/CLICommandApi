using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommandsApi.DTOs
{
    public record CommandDto
    {
        public int Id { get; set; }
        public string CommandName { get; set; }
        public string Description { get; set; }
        public string Platform { get; set; }
    }
}
