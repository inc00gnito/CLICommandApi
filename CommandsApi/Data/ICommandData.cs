using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommandsApi.Models;

namespace CommandsApi.Data
{
    public interface ICommandData
    {
        public IEnumerable<Command> GetAllCommands();
        Command GetCommand(int id);
        void CreateCommand(Command command);
        void UpdateCommand(Command command);

        void DeleteCommand(int id);

    }
}
