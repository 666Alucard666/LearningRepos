using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace BLL.Commands
{
    public class CGCommand : BaseCommand
    {
        public override string Name => "cg";

        public override string Execute(string command)
        {
            var determinator = new ArgumentsDeterminator(command, 2);
            var filesPath = Directory.GetFiles(Directory.GetCurrentDirectory());
            var result = new FileInfo[filesPath.Length];
            var flagsArr = determinator.Flags;
            for (int i = 0; i < result.Length; i++)
            {
                var r = filesPath[i].Split(Path.DirectorySeparatorChar);
                result[i] = new FileInfo(r[r.Length - 1]);
            }

            foreach (var flag in flagsArr)
            {
                switch (flag)
                {
                    case "-l":
                        result = result.OrderBy(f => f.Length).Reverse().ToArray();
                        foreach (var fileInfo in result)
                        {
                            if (flagsArr.Contains("-unh") && fileInfo.Attributes == FileAttributes.Hidden)
                            {
                                Console.WriteLine($"Name:{fileInfo.Name} Size:{fileInfo.Length}");
                            }
                            else if (fileInfo.Attributes == FileAttributes.Hidden)
                            {
                                continue;
                            }
                            else
                            {
                                Console.WriteLine($"Name:{fileInfo.Name} Size:{fileInfo.Length}");
                            }
                        }

                        break;
                    case "-n":
                        result = result.OrderBy(f => f.Name).ToArray();
                        foreach (var fileInfo in result)
                        {
                            if (flagsArr.Contains("-unh") && fileInfo.Attributes == FileAttributes.Hidden)
                            {
                                Console.WriteLine($"Name:{fileInfo.Name}");
                            }
                            else if (!flagsArr.Contains("-unh") && fileInfo.Attributes == FileAttributes.Hidden)
                            {
                                continue;
                            }
                            else
                            {
                                Console.WriteLine($"Name:{fileInfo.Name}");
                            }
                        }

                        break;
                    case "-t":
                        result = result.OrderBy(f => f.Extension).ToArray();
                        foreach (var fileInfo in result)
                        {
                            if (flagsArr.Contains("-unh") && fileInfo.Attributes == FileAttributes.Hidden)
                            {
                                Console.WriteLine($"Name:{fileInfo.Name} Extension:{fileInfo.Extension}");
                            }
                            else if (!flagsArr.Contains("-unh") && fileInfo.Attributes == FileAttributes.Hidden)
                            {
                                continue;
                            }
                            else
                            {
                                Console.WriteLine($"Name:{fileInfo.Name} Extension:{fileInfo.Extension}");
                            }
                        }

                        break;
                    case "-dt":
                        result = result.OrderBy(f => f.CreationTime).Reverse().ToArray();
                        foreach (var fileInfo in result)
                        {
                            if (flagsArr.Contains("-unh") && fileInfo.Attributes == FileAttributes.Hidden)
                            {
                                Console.WriteLine($"Name:{fileInfo.Name} Created:{fileInfo.CreationTime}");
                            }
                            else if (!flagsArr.Contains("-unh") && fileInfo.Attributes == FileAttributes.Hidden)
                            {
                                continue;
                            }
                            else
                            {
                                Console.WriteLine($"Name:{fileInfo.Name} Created:{fileInfo.CreationTime}");
                            }
                        }

                        break;
                    case "-tree":
                        foreach (var fileInfo in result)
                        {
                            if (flagsArr.Contains("-unh") && fileInfo.Attributes == FileAttributes.Hidden)
                            {
                                Console.WriteLine($" - {fileInfo.FullName}");
                                Console.WriteLine($"      - {fileInfo.Name}");
                                Console.WriteLine($"          - file_size: {fileInfo.Length} byte");
                                Console.WriteLine($"          - creation_time: {fileInfo.CreationTime}");
                                Console.WriteLine($"          - last_write_time: {fileInfo.LastWriteTime}");
                            }
                            else if (!flagsArr.Contains("-unh") && fileInfo.Attributes == FileAttributes.Hidden)
                            {
                                continue;
                            }
                            else
                            {
                                Console.WriteLine($" - {fileInfo.FullName}");
                                Console.WriteLine($"      - {fileInfo.Name}");
                                Console.WriteLine($"          - file_size: {fileInfo.Length} byte");
                                Console.WriteLine($"          - creation_time: {fileInfo.CreationTime}");
                                Console.WriteLine($"          - last_write_time: {fileInfo.LastWriteTime}");
                            }
                        }

                        break;
                    default:
                        throw new ArgumentException($"Can't find such flag {flag}");
                }
            }

            return "Success!";
        }
    }
}
