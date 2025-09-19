using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using W4_assignment_template.Interfaces;

namespace W4_assignment_template.Services
{
    public class FileSwtich
    {
        public string prompt()
        {
            Console.WriteLine($"Please choose which file type you would like to implement:\n1. CSV\n2. Jason");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    return "Files/input.csv";
                case "2":
                    return "Files/input.json";
                default:
                    Console.WriteLine("Invalid choice. Defaulting to CSV.");
                    return "input.csv";
            }

        }

        public IFileHandler getHandler(string filePath)
        {
            if (filePath.EndsWith(".csv"))
            {
                return new CsvFileHandler();
            }
            else if (filePath.EndsWith(".json"))
            {
                return new JsonFileHandler();
            }
            else
            {
                throw new NotSupportedException("Unsupported file format.");
            }
        }
    }
}
