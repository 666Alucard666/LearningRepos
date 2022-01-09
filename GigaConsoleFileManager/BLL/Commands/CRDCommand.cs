using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace BLL.Commands
{
    public class CRDCommand : BaseCommand
    {
        public override string Name => "crd";

        public override string Execute(string command)
        {
            var determinator = new ArgumentsDeterminator(command, 2);

            if (Path.GetInvalidFileNameChars().Any(i => determinator.Flags[0].Contains(i)))
            {
                throw new ArgumentException($"Incorrect folder's name.");
            }

            Directory.CreateDirectory(Directory.GetCurrentDirectory() + @"\" + determinator.Flags[0]);
            return "Success!";
        }
    }
}
