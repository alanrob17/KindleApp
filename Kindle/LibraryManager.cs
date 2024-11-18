using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Kindle
{
    internal class LibraryManager
    {
        public List<string> ProcessBooks(List<string> lines)
        {
            return lines.Where(line => line.EndsWith(".mobi", StringComparison.OrdinalIgnoreCase) ||
                                       line.EndsWith(".azw3", StringComparison.OrdinalIgnoreCase))
                        .Select(book => book.Replace(".mobi", string.Empty, StringComparison.OrdinalIgnoreCase)
                                            .Replace(".azw3", string.Empty, StringComparison.OrdinalIgnoreCase))
                        .OrderBy(name => name)
                        .ToList();
        }

        public List<string> ProcessFolders(List<string> lines)
        {
            return lines.Where(line => line.EndsWith(".sdr", StringComparison.OrdinalIgnoreCase) &&
                                       !line.Equals("My Clippings.sdr", StringComparison.OrdinalIgnoreCase))
                        .Select(folder => folder.Replace(".sdr", string.Empty, StringComparison.OrdinalIgnoreCase))
                        .OrderBy(name => name)
                        .ToList();
        }

        public List<string> GetDeleteFolders(List<string> books, List<string> folders)
        {
            return folders.Where(folder =>
                !IsBookFolder(books, RemoveGuidAndUnderscore(folder)))
                .ToList();
        }

        private bool IsBookFolder(List<string> books, string folder)
        {
            return books.Any(book => book.Contains(folder, StringComparison.OrdinalIgnoreCase));
        }

        private string RemoveGuidAndUnderscore(string input)
        {
            const string pattern = @"(_[0-9a-fA-F]{8}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{12})";
            return Regex.Replace(input, pattern, string.Empty).Trim();
        }
    }
}
