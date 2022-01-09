using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace BLL.Commands
{
    public class DELDCommand : BaseCommand
    {
        public override string Name => "deld";

        public string? PathCurrent { get; set; }

        public override string Execute(string command)
        {
            var determinator = new ArgumentsDeterminator(command, 2);
            this.PathCurrent = Directory.GetCurrentDirectory() + @"\" + determinator.Flags[0];
            if (!string.IsNullOrEmpty(determinator.Flags[0]) && Directory.Exists(this.PathCurrent))
            {
                Directory.Delete(Directory.GetCurrentDirectory() + @"\" + determinator.Flags[0]);
                return "Success!";
            }
            else
            {
                throw new DirectoryNotFoundException($"Can't find such directory {this.PathCurrent}");
            }
        }
    }
}
