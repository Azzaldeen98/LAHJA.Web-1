namespace Shared.Helpers
{
    public class FileScanner
    {
        public static List<string> GetAllCsFilePaths(string rootDirectory)
        {
            List<string> csFilePaths = new List<string>();

            if (Directory.Exists(rootDirectory))
            {
                string[] files = Directory.GetFiles(rootDirectory, "*.cs", SearchOption.AllDirectories);
                csFilePaths.AddRange(files);
            }
            else
            {
                Console.WriteLine("The specified directory does not exist.");
            }

            return csFilePaths;
        }
    }

}