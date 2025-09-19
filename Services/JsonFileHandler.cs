using Newtonsoft.Json;
using W4_assignment_template.Interfaces;
using W4_assignment_template.Models;

// NOTE: The Character class uses [JsonProperty] attributes to map C# property names
// to the lowercase JSON keys required by the assignment. This ensures correct
// serialization and deserialization when reading from or writing to JSON files.

namespace W4_assignment_template.Services;

public class JsonFileHandler : IFileHandler
{
    public List<Character> ReadCharacters(string filePath)
    {
        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException($"File not found: {filePath}");
        }

        var json = File.ReadAllText(filePath);
        var characters = JsonConvert.DeserializeObject<List<Character>>(json);

        return characters ?? new List<Character>();
    }

    public void WriteCharacters(string filePath, List<Character> characters)
    {
        var json = JsonConvert.SerializeObject(characters, Formatting.Indented);
        File.WriteAllText(filePath, json);
    }
}
