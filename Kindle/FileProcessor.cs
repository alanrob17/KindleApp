using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kindle
{
    internal class FileProcessor
    {
        public List<string> ProcessTextFile(string fileName)
        {
            if (!File.Exists(fileName))
            {
                Console.WriteLine($"{fileName} doesn't exist!");
                return new List<string>();
            }

            return File.ReadLines(fileName)
                       .Where(line => !string.IsNullOrWhiteSpace(line))
                       .ToList();
        }
    }
}
