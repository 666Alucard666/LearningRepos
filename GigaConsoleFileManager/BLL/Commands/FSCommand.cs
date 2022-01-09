using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace BLL.Commands
{
    public class FSCommand : BaseCommand
    {
        public override string Name => "fs";

        public string? PathCurrent { get; set; }

        public static string ArrayJoin(string[] array, char symb)
        {
            var result = string.Empty;
            foreach (var str in array)
            {
                result += str + symb;
            }

            return result;
        }

        public override string Execute(string command)
        {
            var determinator = new ArgumentsDeterminator(command, 2);
            this.PathCurrent = Directory.GetCurrentDirectory() + @"\" + determinator.Flags[0];
            if (string.IsNullOrEmpty(determinator.Flags[0]) || !File.Exists(this.PathCurrent))
            {
                throw new ArgumentNullException($"Incorrect file's name.");
            }

            if (File.ReadAllText(determinator.Flags[0])[..200].Contains(ArrayJoin(determinator.Flags[1..], ' ')))
            {
                return $"This text contains {ArrayJoin(determinator.Flags[1..], ' ')}";
            }

            return $"This text doesn't contain {ArrayJoin(determinator.Flags[1..], ' ')}";
        }
    }
}
