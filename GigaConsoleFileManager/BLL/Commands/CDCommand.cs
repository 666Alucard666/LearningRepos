using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace BLL.Commands
{
    public class CDCommand : BaseCommand
    {
        public override string Name => "cd";

        public override string? Execute(string command)
        {
            var determinator = new ArgumentsDeterminator(command, 2);
            if (!string.IsNullOrEmpty(determinator.Path) && Directory.Exists(determinator.Path))
            {
                Directory.SetCurrentDirectory(determinator.Path);
                return "Success!";
            }
            else
            {
                throw new DirectoryNotFoundException($"Can't find such directory {determinator.Path}");
            }
        }
    }
}
