using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Utilities
{
    public class ArgumentsDeterminator
    {
        public string CommandName => commandName;
        public string Path => path;
        public string[] Flags => flags;
        private string[] flags;
        private string path;
        private string commandName;
        public ArgumentsDeterminator(string command, int maxFlags)
        {
            this.Determinate(command, maxFlags);
        }
        private void Determinate(string command, int maxFlags)
        {
            if (command == null || command.Split(' ').Length < maxFlags)
            {
                throw new ArgumentException("Params can't be defined");
            }
            else
            {
                var param = command.Split(' ');
                
                commandName = param[0];
                if (PathValidate.Validate(param[1]))
                {
                    path = param[1];
                    flags = param[2..];
                }
                else
                {
                    flags = param[1..];
                }
            }
        }
    }
}
