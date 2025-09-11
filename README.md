### Week 4 Assignment: Open/Closed Principle (OCP) and Interfaces - Converting CSV to JSON

---

#### Overview:
In this week’s assignment, you will build upon your existing RPG character management program and modify it to adhere to the **Open/Closed Principle** (OCP). The OCP states that **software entities should be open for extension, but closed for modification**. To implement this, you will introduce an interface to handle different types of input/output formats. You will refactor your program so that it can now handle **JSON files** instead of **CSV files**, while minimizing changes to the original logic.

#### Learning Objectives:
- Apply the **Open/Closed Principle** by creating an extendable solution for handling file input/output.
- Use **interfaces** to allow the program to handle multiple file formats (CSV, JSON) without modifying core logic.
- Refactor your existing code to support **JSON file input/output** in addition to the existing CSV handling.
  
---

### Assignment Tasks:

#### 1. Refactor for OCP:
- Refactor the existing program to follow the **Open/Closed Principle**.
- Create an **interface** called `IFileHandler` with methods for reading and writing character data.
  
  ```csharp
  public interface IFileHandler
  {
      List<Character> ReadCharacters(string filePath);
      void WriteCharacters(string filePath, List<Character> characters);
  }
  ```

#### 2. Implement CSV and JSON File Handlers:
- Implement two classes:
  - `CsvFileHandler`: For reading and writing character data using CSV format (this should use your existing CSV handling code).
  - `JsonFileHandler`: For reading and writing character data using JSON format (this will require new JSON handling logic).

  ```csharp
  public class CsvFileHandler : IFileHandler
  {
      public List<Character> ReadCharacters(string filePath) { /* CSV logic */ }
      public void WriteCharacters(string filePath, List<Character> characters) { /* CSV logic */ }
  }

  public class JsonFileHandler : IFileHandler
  {
      public List<Character> ReadCharacters(string filePath) { /* JSON logic */ }
      public void WriteCharacters(string filePath, List<Character> characters) { /* JSON logic */ }
  }
  ```

#### 3. JSON File Structure:
- The **JSON file** should represent character data in the following format.  See [Newtonsoft JSON](https://www.newtonsoft.com/json) for more information on serializing and deserializing.

  ```json
  [
    {
      "name": "John",
      "class": "Fighter",
      "level": 1,
      "hp": 10,
      "equipment": ["sword", "shield", "potion"]
    },
    {
      "name": "Jane",
      "class": "Wizard",
      "level": 2,
      "hp": 6,
      "equipment": ["staff", "robe", "book"]
    }
  ]
  ```

#### 5. Stretch Goal (+10%):
- Implement a **strategy pattern** to dynamically switch between file formats (CSV and JSON) without changing the program flow logic. This allows the program to switch formats by using the `IFileHandler` interface without needing to rewrite the logic for displaying, adding, or leveling up characters.
- Modify the program to choose between using the `CsvFileHandler` or `JsonFileHandler` based on the user's input. You should only need to modify minimal parts of your program to allow this new functionality.
- Example menu update:

  ```
  1. Display Characters
  2. Find Character
  3. Add Character
  4. Level Up Character
  5. Change File Format (CSV/JSON)
  ```

---

### Rubric

| Category                          | Full Marks (100)              | Partial Marks (50-90)                   | Minimal Marks (10-40)                     | No Marks (0)                           |
|-----------------------------------|------------------------------|---------------------------------------|-----------------------------------------|----------------------------------------|
| **OCP Implementation**            | Correctly refactors the program to follow OCP by implementing the `IFileHandler` interface. | Refactors but with some design issues or unnecessary modifications to core logic. | Attempts refactoring, but the program is not extensible or violates OCP. | No attempt to refactor or the refactor does not demonstrate OCP. |
| **CSV and JSON Handlers**          | Successfully implements both `CsvFileHandler` and `JsonFileHandler` classes to read/write data in both formats. | Implements both handlers, but with some logic issues or bugs in file handling. | Implements only one handler or with significant errors in file handling. | No implementation of file handlers or non-functional handlers. |
| **Program Flow**                  | The program runs smoothly, allowing the user to switch between CSV and JSON formats without issues. | Program runs but with minor issues in switching file formats. | Program flow is confusing or error-prone, making it difficult to switch file formats correctly. | Program does not run or switching file formats frequently crashes the program. |
| **Stretch Goal: Strategy Pattern (+10%)**       | Successfully implements a strategy pattern to dynamically switch between CSV and JSON formats without modifying core logic. | Implements the pattern but with some integration or logic issues. | Attempts the pattern but the implementation is flawed or incomplete. | No attempt to implement the strategy pattern. |

---

### Additional Resources:
- [C# Interfaces Documentation](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/interfaces/)
- [Working with JSON in C#](https://learn.microsoft.com/en-us/dotnet/standard/serialization/system-text-json-overview)
- [Open/Closed Principle (OCP) Explanation](https://stackify.com/solid-design-open-closed-principle/)
- [Newtonsoft JSON](https://www.newtonsoft.com/json)