using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace BLL.Commands
{
    public class DELFCommand : BaseCommand
    {
        public override string Name => "delf";

        public override string? Execute(string command)
        {
            var determinator = new ArgumentsDeterminator(command, 2);
            if (!string.IsNullOrEmpty(determinator.Flags[0]) && File.Exists(Directory.GetCurrentDirectory() + @"\" + determinator.Flags[0]))
            {
                File.Delete(Directory.GetCurrentDirectory() + determinator.Flags[0]);
                return "Success!";
            }
            else
            {
                throw new FileNotFoundException($"Can't find such file {Directory.GetCurrentDirectory() + @"\" + determinator.Flags[0]}");
            }
        }
    }
}
