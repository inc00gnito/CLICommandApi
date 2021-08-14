using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommandsApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CommandsApi.Data
{
    public class CommandApiContext :DbContext
    {
        public CommandApiContext(DbContextOptions<CommandApiContext> options ): base(options)
        { }

        public DbSet<Command> Commands { get; set; }
    }
}
