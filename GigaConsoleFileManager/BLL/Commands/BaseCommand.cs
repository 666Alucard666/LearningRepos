using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Utilities;

namespace BLL.Commands
{
    public abstract class BaseCommand
    {
        public abstract string Name { get; }

        public abstract string Execute(string command);
    }
}
