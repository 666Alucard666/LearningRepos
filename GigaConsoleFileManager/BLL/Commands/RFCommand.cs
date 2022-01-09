using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace BLL.Commands
{
    public class RFCommand : BaseCommand
    {
        public override string Name => "rf";

        public string? PathCurrent { get; set; }

        public override string Execute(string command)
        {
            var determinator = new ArgumentsDeterminator(command, 2);
            this.PathCurrent = Directory.GetCurrentDirectory() + @"\" + determinator.Flags[0];
            if (string.IsNullOrEmpty(determinator.Flags[0]) || !File.Exists(this.PathCurrent))
            {
                throw new ArgumentNullException($"Incorrect file's name.");
            }

            return File.ReadAllText(determinator.Flags[0]).Substring(0, 200);
        }
    }
}
