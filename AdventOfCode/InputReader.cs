using System;
using System.IO;

namespace AdventOfCode
{
    public class InputReader
    {
        public static string Read(string file)
        {
            var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "InputFiles", file);

            return File.ReadAllText(filePath);
        }
    }
}
