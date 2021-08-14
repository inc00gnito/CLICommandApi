using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommandsApi.Models;
using Microsoft.AspNetCore.Routing.Template;
using Microsoft.EntityFrameworkCore;

namespace CommandsApi.Data
{
    public class CommandData :ICommandData
    {
        private readonly CommandApiContext _db;

        public CommandData(CommandApiContext db)
        {
            _db = db;
        }

        public IEnumerable<Command> GetAllCommands()
        {
            return _db.Commands;
        }

        public Command GetCommandById(int id)
        {
            return _db.Commands.FirstOrDefault(command => command.Id == id);
        }

        public void CreateCommand(Command command)
        {
            _db.Commands.Add(command);
            _db.SaveChanges();
        }

        public void UpdateCommand(Command command)
        {
            var entity = _db.Entry(command);
            entity.State = EntityState.Modified;
            _db.SaveChanges();
        }

        public void DeleteCommand(int id)
        {
            var command = GetCommandById(id);
            if (command != null)
                _db.Commands.Remove(command);
            _db.SaveChanges();
        }
    }
}
