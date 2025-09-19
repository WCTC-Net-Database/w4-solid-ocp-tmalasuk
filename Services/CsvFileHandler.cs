using CsvHelper.Configuration;
using CsvHelper;
using System.Globalization;
using W4_assignment_template.Interfaces;
using W4_assignment_template.Models;

namespace W4_assignment_template.Services;

public class CsvFileHandler : IFileHandler
{
    public List<Character> ReadCharacters(string filePath)
    {
        using (var reader = new StreamReader(filePath))
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = true
            };

            using (var csv = new CsvReader(reader, config))
            {
                csv.Context.RegisterClassMap<CharacterMap>();
                return csv.GetRecords<Character>().ToList();
            }
        }
    }

    public void WriteCharacters(string filePath, List<Character> characters)
    {
        using (var writer = new StreamWriter(filePath))
        using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
        {
            csv.Context.RegisterClassMap<CharacterMap>();
            csv.WriteHeader<Character>();
            csv.NextRecord();
            csv.WriteRecords(characters);
        }
    }
}