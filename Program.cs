using System.Dynamic;
using W4_assignment_template;
using W4_assignment_template.Interfaces;
using W4_assignment_template.Models;
using W4_assignment_template.Services;

IFileHandler fileHandler = null;
List<Character> characters = null;


var fileSwitch = new FileSwtich();
string filePath = fileSwitch.prompt();
fileHandler = fileSwitch.getHandler(filePath); 
characters = fileHandler.ReadCharacters(filePath);

while (true)
{
    Console.WriteLine("Menu:");
    Console.WriteLine("1. Display Characters");
    Console.WriteLine("2. Add Character");
    Console.WriteLine("3. Level Up Character");
    Console.WriteLine("4. Switch File Type");
    Console.WriteLine("5. Exit (Save Changes)");
    Console.Write("Enter your choice: ");
    string choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            DisplayAllCharacters();
            break;
        case "2":
            AddCharacter();
            break;
        case "3":
            LevelUpCharacter();
            break;
        case "4":
            filePath = fileSwitch.prompt();
            fileHandler = fileSwitch.getHandler(filePath);
            break;
        case "5":
            fileHandler.WriteCharacters(filePath, characters);
            return;
        default:
            Console.WriteLine("Invalid choice. Please try again.");
            break;
    }
}

void DisplayAllCharacters()
{
    foreach (var character in characters)
    {
        Console.WriteLine($"Name: {character.Name}");
        Console.WriteLine($"Class: {character.Class}");
        Console.WriteLine($"Level: {character.Level}");
        Console.WriteLine($"HP: {character.HP}");
        Console.WriteLine($"Equipment: {string.Join(", ", character.Equipment)}");
        Console.WriteLine("+---------------------+");
    }
    Console.WriteLine();
}

void AddCharacter()
{
    Console.Write("Enter character name: ");
    var name = Console.ReadLine()?.Trim();

    Console.Write("Enter character profession: ");
    var profession = Console.ReadLine()?.Trim();

    Console.Write("Enter character level: ");
    var levelInput = Console.ReadLine();
    int level;
    while (!int.TryParse(levelInput, out level) || level < 1)
    {
        Console.Write("Invalid input. Please enter a positive integer for level: ");
        levelInput = Console.ReadLine();
    }

    Console.Write("Enter character HP: ");
    var hpInput = Console.ReadLine();
    int hp;
    while (!int.TryParse(hpInput, out hp) || hp < 1)
    {
        Console.Write("Invalid input. Please enter a positive integer for HP: ");
        hpInput = Console.ReadLine();
    }

    var equipment = new List<string>();
    var item = "";
    while (equipment.Count == 0 || item != "done")
    {
        Console.Write("Enter one equipment item (or type 'done' to finish): ");
        item = Console.ReadLine()?.Trim();
        if (item?.ToLower() == "done")
        {
            break;
        }

        equipment.Add(item);

    }

    var newCharacter = new Character(name, profession, level, hp, equipment);
    characters.Add(newCharacter);

    Console.WriteLine($"Character {name} added successfully!");
    Console.WriteLine("");
}

void LevelUpCharacter()
{
    Console.Write("Enter the name of the character to level up: ");
    string nameToLevelUp = Console.ReadLine();

    var character = characters.Find(c => c.Name.Equals(nameToLevelUp, StringComparison.OrdinalIgnoreCase));
    if (character != null)
    {
        character.Level++;
        Console.WriteLine($"Character {nameToLevelUp} has been leveled up! Current level: {character.Level}");
        Console.WriteLine("");
    }
    else
    {
        Console.WriteLine("Character not found.");
    }
}
