using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace BLL.Commands
{
    public class CRFCommand : BaseCommand
    {
        public override string Name => "crf";

        public override string? Execute(string command)
        {
            var determinator = new ArgumentsDeterminator(command, 2);
            if (string.IsNullOrEmpty(determinator.Flags[0]))
            {
                throw new ArgumentNullException($"Incorrect file's name.");
            }

            if (Path.GetInvalidFileNameChars().Any(i => determinator.Flags[0].Contains(i)))
            {
                throw new ArgumentException($"Incorrect file's name.");
            }

            File.Create(Directory.GetCurrentDirectory() + @"\" + determinator.Flags[0]);
            return "Success!";
        }
    }
}
