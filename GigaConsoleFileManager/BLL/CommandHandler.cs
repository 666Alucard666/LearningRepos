using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Commands;
using Utilities;

namespace BLL
{
    public class CommandHandler
    {
        private MyDict<string, BaseCommand> commands = new MyDict<string, BaseCommand>
        {
            { "cd", new CDCommand() },
            { "crd", new CRDCommand() },
            { "crf", new CRFCommand() },
            { "deld", new DELDCommand() },
            { "delf", new DELFCommand() },
            { "rend", new RENDCommand() },
            { "renf", new RENFCommand() },
            { "cg", new CGCommand() },
            { "rf", new RFCommand() },
            { "fs", new FSCommand() },
        };

        public BaseCommand Handle(string nameCommand)
        {
            if (this.commands.Contains(nameCommand))
            {
                return this.commands.Get(nameCommand);
            }

            throw new ArgumentException($"Such command doesn't exist {nameCommand}");
        }
    }
}
