using System.Text.RegularExpressions;

namespace Kindle
{
    internal class Process
    {
        static void Main(string[] args)
        {
            var fileDirectory = Environment.CurrentDirectory;
            var fileName = Path.Combine(fileDirectory, "Kindle.txt");

            var fileProcessor = new FileProcessor();
            var libraryManager = new LibraryManager();

            List<string> lines = fileProcessor.ProcessTextFile(fileName);

            var books = libraryManager.ProcessBooks(lines);
            var folders = libraryManager.ProcessFolders(lines);

            var deleteFolders = libraryManager.GetDeleteFolders(books, folders);

            foreach (string folder in deleteFolders)
            {
                Console.WriteLine($"{folder}.sdr");
            }
        }
    }
}
