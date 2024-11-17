using System.Text.RegularExpressions;

namespace Kindle
{
    internal class Process
    {
        static void Main(string[] args)
        {
            var fileDirectory = Environment.CurrentDirectory + @"\";

            var fileName = $"{fileDirectory}\\Kindle.txt";

            List<string> lines = ProcessTextFile(fileName);

            List<string> books = [];
            List<string> folders = [];
            List<string> deleteFolders = [];

                
            books = ProcessBooks(lines, books);
            books = SortBooks(books);
            folders = ProcessFolders(lines, folders);
            folders = SortFolders(folders);

            foreach (string folder in folders)
            {
                var originalFolder = folder;
                var folderName = folder;

                // some folder names have GUID's in them. I have to allow for these.
                folderName = RemoveGuidAndUnderscore(folderName);

                var found = IsDeleteFolder(books, folderName);

                if (found == false)
                {
                    deleteFolders.Add(originalFolder);
                }
            }

            foreach (string folder in deleteFolders)
            {
                Console.WriteLine($"{folder}.sdr");
            }
        }

        private static bool IsDeleteFolder(List<string> books, string folder)
        {
            bool found = false;
            
            foreach (string book in books)
            {
                if (book.Contains(folder)) 
                { 
                    found = true; 
                    break; 
                }
            }

            return found;
        }

        private static string RemoveGuidAndUnderscore(string input)
        {
            string pattern = @"(_[0-9a-fA-F]{8}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{12})";

            string cleanedString = Regex.Replace(input, pattern, string.Empty);

            return cleanedString.Trim();
        }

        private static List<string> SortFolders(List<string> folders)
        {
            return folders.OrderBy(name => name).ToList();
        }
        
        private static List<string> SortBooks(List<string> books)
        {
            return books.OrderBy(name => name).ToList();
        }

        private static List<string> ProcessFolders(List<string> lines, List<string> folders)
        {
            foreach (string line in lines)
            {
                var folder = line;
                if (folder.Contains(".sdr"))
                {
                    if (folder != "My Clippings.sdr")
                    {
                        folders.Add(folder.Replace(".sdr", string.Empty));
                    }
                }
            }

            return folders;
        }

        private static List<string> ProcessBooks(List<string> lines, List<string> books)
        {
            foreach (string line in lines)
            {
                var book = line;
                if (book.Contains(".mobi"))
                {
                    books.Add(book.Replace(".mobi", string.Empty));
                }
                else if (book.Contains(".azw3"))
                {
                    books.Add(book.Replace(".azw3", string.Empty));
                }
            }

            return books;
        }

        private static List<string> ProcessTextFile(string fileName)
        {
            var lines = new List<string>();

            if (File.Exists(fileName))
            {
                foreach (var line in File.ReadLines(fileName))
                {
                    if (!string.IsNullOrWhiteSpace(line))
                    {
                        lines.Add(line);
                    }
                }
            }
            else
            {
                Console.WriteLine($"{fileName} doesn't exist!");
            }

            return lines;
        }
    }
}
