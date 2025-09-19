using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using CsvHelper;
using Newtonsoft.Json;

namespace W4_assignment_template.Models;

public class Character
{
    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("class")]
    public string Class { get; set; }

    [JsonProperty("level")]
    public int Level { get; set; }

    [JsonProperty("hp")]
    public int HP { get; set; }

    [JsonProperty("equipment")]
    public List<string> Equipment { get; set; }

    

    public Character() { }

    public Character(string name, string profession, int level, int hp, List<string> equipment)
    {
        Name = name;
        Class = profession;
        Level = level;
        HP = hp;
        Equipment = equipment;
    }

}
public class CharacterMap : ClassMap<Character>
{
    public CharacterMap()
    {
        Map(m => m.Name).Index(0);
        Map(m => m.Class).Index(1);
        Map(m => m.Level).Index(2);
        Map(m => m.HP).Index(3);
        Map(m => m.Equipment).Index(4).TypeConverter<EquipmentConverter>();
    }
}

class EquipmentConverter : DefaultTypeConverter
{
    public override string ConvertToString(object value, IWriterRow row, MemberMapData memberMapData)
    {
        var list = value as List<string>;
        return list != null ? string.Join("|", list) : string.Empty;
    }

    public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
    {
        return text.Split('|', StringSplitOptions.RemoveEmptyEntries)
            .Select(s => s.Trim())
            .ToList();
    }
}

