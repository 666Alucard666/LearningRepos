using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace BLL.Commands
{
    public class RENDCommand : BaseCommand
    {
        public override string Name => "rend";

        public override string? Execute(string command)
        {
            var determinator = new ArgumentsDeterminator(command, 3);
            if (Directory.Exists(Directory.GetCurrentDirectory() + @"\" + determinator.Flags[0]))
            {
                Directory.Move(Directory.GetCurrentDirectory() + @"\" + determinator.Flags[0], Directory.GetCurrentDirectory() + @"\" + determinator.Flags[1]);
                return "Success!";
            }
            else if (Path.GetInvalidFileNameChars().Any(i => determinator.Flags[0].Contains(i)) || Path.GetInvalidFileNameChars().Any(i => determinator.Flags[1].Contains(i)))
            {
                throw new ArgumentException($"Incorrect folder's name.");
            }
            else
            {
                throw new DirectoryNotFoundException($"Can't find such directory {Directory.GetCurrentDirectory() + @"\" + determinator.Flags[0]}");
            }
        }
    }
}
