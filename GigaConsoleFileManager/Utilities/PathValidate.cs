using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    internal static class PathValidate
    {
        public static bool Validate(string path)
        {
            return Path.IsPathFullyQualified(path);
        }
    }
}
