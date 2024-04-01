using System;
using System.IO;

namespace ConsoleApplication1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Usage: dotnet run -p YourProjectName.csproj <path_to_cshtml>");
                return;
            }

            string cshtmlFilePath = args[0];
            ConvertCshtmlToHtml(cshtmlFilePath);
        }

        public static void ConvertCshtmlToHtml(string cshtmlFilePath)
        {
            if (File.Exists(cshtmlFilePath))
            {
                string cshtmlContent = File.ReadAllText(cshtmlFilePath);
                string htmlFilePath = Path.ChangeExtension(cshtmlFilePath, ".html");
                File.WriteAllText(htmlFilePath, cshtmlContent);

                Console.WriteLine("Conversion successful!");
            }
            else
            {
                Console.WriteLine($"File {cshtmlFilePath} not found.");
            }
        }
    }

}