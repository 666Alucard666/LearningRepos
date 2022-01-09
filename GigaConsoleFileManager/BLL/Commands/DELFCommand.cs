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

        public string? PathCurrent { get; set; }

        public override string Execute(string command)
        {
            var determinator = new ArgumentsDeterminator(command, 2);
            this.PathCurrent = Directory.GetCurrentDirectory() + @"\" + determinator.Flags[0];
            if (!string.IsNullOrEmpty(determinator.Flags[0]) && File.Exists(this.PathCurrent))
            {
                File.Delete(Directory.GetCurrentDirectory() + determinator.Flags[0]);
                return "Success!";
            }
            else
            {
                throw new FileNotFoundException($"Can't find such file {this.PathCurrent}");
            }
        }
    }
}
