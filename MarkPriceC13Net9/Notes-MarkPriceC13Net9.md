# C# 13 and .Net 9

by Mark J. Price (9ed)

# Roadmap
Here is the roadmap for the 10-chapter journey:

* **Chapter 2:** Speaking C# (Syntax, Variables, Console I/O)
* **Chapter 3:** Controlling Flow, Converting Types, and Handling Exceptions
* **Chapter 4:** Writing, Debugging, and Testing Functions
* **Chapter 5:** Building Your Own Types with Object-Oriented Programming
* **Chapter 6:** Implementing Interfaces and Inheriting Classes
* **Chapter 7:** Packaging and Distributing .NET Types
* **Chapter 8:** Working with Common .NET Types
* **Chapter 9:** Working with Files, Streams, and Serialization
* **Chapter 10:** Working with Data Using Entity Framework Core
* **Chapter 11:** Querying and Manipulating Data Using LINQ


# Chapter 1: Hello, C#! Welcome, .NET!

### Table 1.5: Summary of steps to create a solution and projects using VS Code

| Step | Task | Command or Action |
| --- | --- | --- |
| **1** | Create a folder for the solution.                 | `mkdir <solution_folder_name>`                |
| **2** | Change to the folder in VS Code.                  | `cd <solution_folder_name>`                   |
| **3** | Create the solution file in the folder.           | `dotnet new sln`                              |
| **4** | Create a folder and project using a template.     | `dotnet new console -o <project_folder_name>` |
| **5** | Add the folder and its project to the solution.   | `dotnet sln add <project_folder_name>`        |
| **6** | Repeat steps 4 and 5 to create and add any other projects   | |
| **7** | Open the current folder path `(.)` containing the solution using VS Code   | `code .`             |
| **8** | Build and run the project.                        | `dotnet run` (ensure terminal is in project folder). |




# Chapter 2: Speaking C#

Any projects that target .NET 6 or later, and therefore use the C# 10 or later compiler, generate a `<ProjectName>.GlobalUsings.g.cs` file in the `obj/Debug/net9.0` folder ro implicitly import some common namespaces like System. See `Table 2.5: .NET SDKs and their implicitly imported namespaces` p. 72 of the book.

Verbs are methods.

Nouns are types, variables, fields, and properties
- `Animal` and `Car` are types; they are nouns for categorizing things.
- `Head` and `Engine` might be fields or properties; they are nouns that belong to Animal and Car.
- `Fido` and `Bob` are variables; they are nouns for referring to a specific object.

Every type can be categorized as `class`, `struct`, `enum`, `interface`, or `delegate`.

```text
Good Practice: Use int for whole numbers. Use double for real numbers that will not be
compared for equality to other values; it is okay to compare double values being less than
or greater than, and so on. Use decimal for money, CAD drawings, general engineering,
and wherever the accuracy of a real number is important.
```

**Dynamic types** are most useful when interoperating with non-.NET systems. For example, you might need to work with a class library written in F#, Python, or some JavaScript. You might also need to interop with technologies like the Component Object Model (COM), for example, when automating Excel or Word.

Inferring the type of a variable

- A literal number without a decimal point is inferred as an int variable, that is, unless you add a suffix, as described in the following list:
    - L: Compiler infers long
    - UL: Compiler infers ulong
    - M: Compiler infers decimal
    - D: Compiler infers double
    - F: Compiler infers float
- A literal number with a decimal point is inferred as double unless you add the M suffix (in which case the compiler infers a decimal variable), or the F suffix, in which case it infers a float variable.


---

### Problem Set for Chapter 2: Speaking C#

**The Scenario:**
We are building the foundation of a new CLI (Command Line Interface) tool for our DevOps team, called `NetDash`. Before we add complex logic, we need to establish the entry point, handle basic input/output, and demonstrate a firm grasp of C#'s fundamental type system and memory footprints.

**Your Requirements:**
Write a C# 13 console application (utilizing top-level statements) that accomplishes the following:

1. **Command-Line Arguments:** Read the command-line arguments passed to the application. If an argument matching `--verbose` is passed, store a boolean flag indicating verbose mode is enabled.
2. **Type Exploration:** Output a neatly formatted table to the console showing the exact memory size (in bytes) and the `MinValue` and `MaxValue` for the following CLR types: `sbyte`, `int`, `double`, and `decimal`.
* *Hint:* Consider how you format strings to ensure the table columns align perfectly.


3. **User Interaction:** Prompt the user to enter a mock "Server Name" and an "Allocated Memory in GB" (assume they type a valid number for now, as we haven't covered exception handling in Ch 3).
4. **String Interpolation & Variables:** Output a final summary string that greets the user, displays the server name, and calculates the memory in Megabytes (MB). Use local variables effectively. Choose whether to use `var` or explicit types, but be prepared to defend your choice in our review!

**Constraints & Best Practices for this PR:**

* Do not use any advanced OOP (classes, records) or complex flow control (if/else is fine for the CLI args, but keep it minimal). Rely purely on what is covered in Chapter 2.
* Focus on string formatting (e.g., `PadRight`, composite formatting, or interpolated strings).
* Ensure your naming conventions follow standard C# guidelines (camelCase for locals).
---


# Chapter 3: Controlling Flow, Converting Types, and Handling Exceptions


### Problem Set for Chapter 3: Controlling Flow, Converting Types, and Handling Exceptions

**The Scenario:**
Our DevOps team wants `NetDash` to run continuously until they explicitly tell it to shut down. They also want a new "Port Configuration" tool and a "Diagnostics" tool to test memory limits. Since users make typos, the application must not crash if someone types "pizza" when asked for a number.

**Your Requirements:**
Add to (or replace the body of) your existing `Program.cs` to achieve the following:

1. **The Application Loop:** Wrap the core logic in a `while` loop so the program runs indefinitely until the user inputs the command `exit`.
2. **Pattern Matching & Selection:** Prompt the user for a command (`port`, `diagnostics`, or `exit`). Use a modern C# `switch` statement or `switch` expression to route the application flow based on their input.
3. **Safe Type Conversion (Port Command):** If the user selects `port`, prompt them for a port number. Network ports range from 0 to 65,535. Use the most memory-efficient CLR type for this (`ushort`). Safely attempt to parse the input using `TryParse`. If it fails, output a friendly error message. If it succeeds, echo the port back to them.
4. **Exceptions and Overflow (Diagnostics Command):** If the user selects `diagnostics`, we are going to stress-test integer bounds.
    * Prompt the user to enter a small number to add to the maximum byte value.
    * Set up a `try...catch` block.
    * Inside the `try`, declare a `byte` initialized to `byte.MaxValue`. Open a `checked` block, add the user's parsed input to that byte, and print the result.
    * Catch an `OverflowException` specifically. In the `catch` block, change the console text color to red, print a warning that an overflow occurred, and then reset the text color back to normal.
    * Include a generic `catch (Exception ex)` at the end to catch any other unforeseen errors (like formatting errors if they type text instead of a number).



**Constraints & Best Practices for this PR:**

* Continue using your global static using for `Console` (i.e., just write `WriteLine`, `ForegroundColor`, etc.).
* Think carefully about variable scope. Variables declared inside a `switch` case or a `try` block won't be accessible outside of them.
* Keep your code clean and properly indented.

Whenever you are ready, paste your code for Chapter 3. I will review your flow control architecture and exception handling! Let me know if you have any questions before you start.


# Chapter 4: Writing, Debugging, and Testing Functions

### Writing Unit Tests
- **Arrange**: This part will declare and instantiate variables for input and output.
- **Act**: This part will execute the unit that you are testing. In our case, that means calling the method that we want to test.
- **Assert**: This part will make one or more assertions about the output. An assertion is a belief that, if not true, indicates a failed test. For example, when adding 2 and 2, we would expect the result to be 4.


### Rethrowing exceptions

There are three ways to rethrow an exception inside a `catch` block, as shown in the following list:

- To throw the caught exception with its original call stack, call `throw`.
- To throw the caught exception as if it was thrown at the current level in the call stack, call throw with the caught exception, for example, `throw ex`. This is usually poor practice because you have lost some potentially useful information for debugging but it can be useful when you want to deliberately remove that information when it contains sensitive data.
- To wrap the caught exception in another exception that can include more information in a message that might help the caller understand the problem, throw a new exception, and pass the caught exception as the `innerException` parameter.

---

### Problem Set for Chapter 4: Writing, Debugging, and Testing Functions

**The Scenario:**
Our `NetDash` `Program.cs` is getting a little top-heavy. As architects, we know that giant `switch` statements containing all of our business logic lead to spaghetti code. It is time to modularize our application using functions, introduce Tuples for returning multiple values, and formally document our API.

**Your Requirements:**
Refactor and expand your application using the concepts from Chapter 4:

1. **Extract the UI (Local Function):** Move the menu display logic and the `ReadLine()` prompt out of the `while` loop and into a separate function named `GetMenuChoice()`. This function should return the user's input as a `string`. Your `while` loop should now cleanly call `string choice = GetMenuChoice();`.
2. **The New Command - Ping (Tuples & Optional Parameters):** Add a `ping` option to your menu and `switch` block. Create a function called `SimulatePing`.
* It must take two parameters: `string targetAddress` and an optional parameter `int packetSize` (defaulting to 32).
* It must return a **Tuple** (specifically a `ValueTuple`) containing two named elements: `(bool IsSuccess, int RoundTripTime)`.
* *Mock the logic:* If `targetAddress` is "localhost", return `(true, 1)`. Otherwise, return `(true, 45)`.


3. **Throwing Exceptions:** Inside `SimulatePing`, check if `targetAddress` is null, empty, or whitespace. If it is, explicitly `throw new ArgumentException("Target address cannot be empty.", nameof(targetAddress));`.
* Make sure you wrap the call to `SimulatePing` in your `switch` block with a `try...catch` that specifically catches `ArgumentException` and prints a red error message.


4. **XML Documentation:** Add proper XML documentation (`///`) above the `SimulatePing` function. Describe the summary, the parameters, the return value, and the exception it throws.

**Constraints & Best Practices for this PR:**

* Since you are using top-level statements, you can place your functions at the very bottom of the `Program.cs` file (after the `while` loop finishes).
* Watch your variable scoping! When you extract the menu into a function, make sure you don't break the layout constants.
* Make sure you unpack or access your Tuple cleanly in the `switch` block using C# 13 deconstruction syntax (e.g., `var (success, ping) = ...`).

Take your time refactoring this. Modularizing code is the most important step in scaling an application.


# Chapter 5: Building Your Own Types with Object-Oriented Programming


#### OOP Concepts
- Encapsulation
- Composition
- Aggregation
- Inheritance
- Abstraction
- Polymorphism 

### Type and members
- In C#, we use the C# keywords `class`, `record`, and `struct` to define a type of object. You can think of a type as being a blueprint or template for an object.
- Members are encapsulated within a type. They can be fields, methods, or a specialized versions of both
    - Fields are used to store data. They have 3 categories
        - Constant
        - Read-only
        - Event
    - Methods are used to execute statements. They have 4 categories
        - Constructor
        - Property
        - Indexer
        - Operator

Class library assemblies group types together into easily deployable units (DLL files).

You can only have one file-scoped namespace per file.

### Table 5.1: Six Member Access Modifiers
| **Member Access Modifier**| **Description** |
| --- | --- |
| private | Accessible inside the type only. This is the **default** |
| internal | Accessible inside the type and any type in the same assembly  |
| protected | Accessible inside the type and any type that inherits from the type |
| public | Accessible everywhere |
| internal protected | Accessible inside the type, any type in the same assembly, and any type that inherits from the type. Equivalent to a fictional access modifier named `internal_or_protected`. |
| private protected | Accessible inside the type and any type that inherits from the type and is in the same assembly. Equivalent to a fictional access modifier named `internal_and_protected`. This combination is only available with C# 7.2 or later. |

**Good practice:** Explicitly apply one of the access modifiers to all type members, even if you want to use the implicit access modifier for members, which is `private`. Additionally, fields should usually be `private` or `protected`, and you should then create `public` properties to get or set the field values. This is because the property then controls access. You will do this later in the chapter.

---
### What are the benefits of using public getters and setters for private fields in the OO paradigm?

Excellent question. In the context of **Chapter 5: Building Your Own Types**, we transition from simply "storing data" to "managing state."

Using public getters and setters (collectively known in C# as **Properties**) to wrap private fields is the cornerstone of **Encapsulation**. While it might seem like extra "boilerplate" compared to just making a field `public`, it provides several architectural advantages that are vital for production-grade software.

Here are the primary benefits from an Architect's perspective:

#### 1. Validation and Logic (The "Gatekeeper" Effect)

A public field allows any caller to set a value to anything. A property allows you to execute code when a value is changed.

* *Example:* If you have a `ShippingContainer`, you can ensure the `Temperature` property never goes below absolute zero. If a caller tries to set an invalid value, you can throw an `ArgumentOutOfRangeException`.

#### 2. Implementation Hiding (Abstraction)

The internal storage of data does not have to match the external representation.

* *Example:* You might store a user's birthdate as a `DateTime` field, but provide a public getter for `Age` that calculates the integer on the fly. To the consumer, `Age` looks like data, but to the class, it is a calculation.

#### 3. Granular Access Control

Fields are all-or-nothing. Properties allow you to vary the accessibility of the "get" and "set" operations.

* **Read-Only:** A public getter with a `private` or `protected` setter.
* **Immutable (C# 9+):** Using the `init` keyword allows a property to be set during initialization but never changed again. This is a massive win for thread safety and predictable state.

#### 4. Future-Proofing (The API Contract)

If you start with a public field and later realize you need to add validation logic, changing that field to a property is a **breaking change** for compiled assemblies. By starting with a property (even an auto-implemented one: `public string Name { get; set; }`), you can add logic inside the getter or setter later without changing the "shape" of your class for the code that uses it.

#### 5. Debugging and Interception

You cannot put a breakpoint on a field to see when it changes. You **can** put a breakpoint inside a setter. This is invaluable when hunting for a bug where a value is being overwritten by an unknown part of the program.

#### 6. Framework Compatibility

The .NET ecosystem (Entity Framework Core, JSON.NET, WPF/MAUI Data Binding) is built to work with **Properties**, not fields. Many of these tools use **Reflection** to look for the `get_` and `set_` methods that the compiler generates behind the scenes for properties.


**Mentor Note:** In modern C#, we usually use **Auto-Implemented Properties** for simplicity:

```csharp
public decimal ShippingCost { get; private set; } // Accessible to read, but only changeable within this class.

```

This gives you all the benefits mentioned above with almost no extra typing.

---

### `const` vs. `readonly`

In the context of **Chapter 2 (Speaking C#)** and **Chapter 5 (Building Your Own Types)**, understanding the distinction between `const` and `readonly` is vital for memory management and API stability. While they both create "constants," they behave very differently under the hood.

#### 1. `const`: The Compile-Time Constant

A `const` field is a value that is baked directly into the Intermediate Language (IL) code at compile time.

* **Evaluation:**
* **Advantages:** Slightly faster performance (no memory lookup; the value is embedded like a literal) and clearly communicates that the value will *never* change (e.g.,  or the number of months in a year).
* **Disadvantages:** It is highly inflexible. It can only be assigned at declaration. More importantly, it creates **versioning issues**. If you change a `const` in a library, any assembly using that library must be recompiled to see the new value.

#### 2. `readonly`: The Run-Time Constant

A `readonly` field is assigned a value at runtime, either at declaration or within a constructor.

* **Evaluation:**
* **Advantages:** Flexibility. You can pull the value from a configuration file or a database during the constructor's execution. It also solves the versioning problem: if the value changes in a library, the consuming app will pick up the new value at runtime without needing a recompile.
* **Disadvantages:** Minor overhead compared to `const` because it requires a memory lookup (it lives on the heap or stack as part of the object).


#### Critical Comparison Table

| Feature | `const` | `readonly` |
| --- | --- | --- |
| **Binding** | Compile-time | Run-time |
| **Initialization** | Only at declaration | At declaration or in Constructor |
| **Allowed Types** | Primitive types, strings, or null | Any type (classes, structs, etc.) |
| **Scope** | Static by default (cannot use `static` keyword) | Can be Instance or Static |
| **Memory Allocation** | Replaced with literals in IL | Allocated in memory at runtime |

---

#### The Architect’s Recommendation

* **Use `const` for:** Values that are "mathematically" or "universally" fixed and will never change for the life of the universe (or the software), like `const int DaysInWeek = 7;`.
* **Use `readonly` for:** Values that are constant *for a specific instance* or values that might change in future versions of your library (like a `DefaultTimeout` or a `MaxConnections`).

> [!IMPORTANT]
> In **C# 13**, we often pair `readonly` with **Primary Constructors** (introduced in C# 12) to create concise, immutable types. This is a pattern you'll see frequently as we progress to Chapter 5.

---

### Four ways of passing parameters into a method

- *By value* (this is the default): Think of these as being in-only. Although the value can be changed, this only affects the parameter in the method.
- As an `out` parameter: Think of these as being out-only. out parameters cannot have a default value assigned in their declaration and cannot be left uninitialized. They must be set inside the method; otherwise, the compiler will give an error.
- By reference as a `ref` parameter: Think of these as being in-and-out. Like out parameters, ref parameters also cannot have default values, but since they can already be set outside the method, they do not need to be set inside the method.
- As an `in` parameter: Think of these as being a reference parameter that is read-only. in parameters cannot have their values changed and the compiler will show an error if you try.

### A method returns single value of one type
Each method can only return a single value that has a single type. That type could be a simple type, such as string; a complex type, such as Person; or a collection type, such as List<Person>.

### What is a private backing field and what is its uses?

It is a pleasure to help you navigate the nuances of the .NET ecosystem. To understand **private backing fields**, we have to look at the evolution of "encapsulation"—one of the four pillars of Object-Oriented Programming.


#### 1. The Concept

In C#, we distinguish between **Fields** and **Properties**.

* **Fields** are variables declared directly in a class or struct; they represent the raw data.
* **Properties** are "smart" accessors (methods disguised as variables) that provide a flexible mechanism to read, write, or compute the value of a private field.

A **private backing field** is the underlying storage location for a property. It exists because we often want to protect the internal state of an object from being corrupted by external code. Instead of exposing the raw data, we wrap it in a property to perform validation, logging, or transformation.


#### 2. The "Under the Hood"

When you use a backing field, the memory is allocated on the **Heap** (for classes) as part of the object’s memory block.

In the early days of C#, you *had* to write the field manually. Today, the compiler often does this for you via **Auto-Implemented Properties**. When you write `public string Name { get; set; }`, the C# compiler (Roslyn) actually generates a hidden, private backing field in the Common Intermediate Language (CIL) that you cannot see or access directly.

We only explicitly define a backing field today when we need **Logic** during the `get` or `set` operations that the compiler's "hidden" field can't provide.


#### 3. Modern Code Example

Let’s look at a scenario where a backing field is necessary: a `BankAccount` where we must validate that a balance never goes negative, and a `Temperature` record using modern C# 12+ primary constructors.

```csharp
namespace FinancialApp.Models;

public class BankAccount
{
    // 1. The Private Backing Field
    private decimal _balance; 

    // 2. The Property wrapping the field
    public decimal Balance
    {
        get => _balance;
        // Logic: Prevent the field from being set to a negative value
        set => _balance = value < 0 
            ? throw new ArgumentOutOfRangeException(nameof(value), "Balance cannot be negative.") 
            : value;
    }

    // Modern C# Note: If no logic is needed, we just use:
    public string AccountHolder { get; init; } = string.Empty;
}

// Example of Primary Constructors (C# 12) 
// The 'initialCelsius' parameter acts similarly to a private field for initialization
public class WeatherSensor(double initialCelsius)
{
    private double _celsius = initialCelsius;

    public double Fahrenheit => (_celsius * 9 / 5) + 32;
    
    public void UpdateReading(double newReading) 
    {
        if (Math.Abs(_celsius - newReading) > 0.1)
            _celsius = newReading;
    }
}

```


#### 4. Best Practices

* **Default to Auto-Properties:** If you don't need validation or logic, use `public string Name { get; set; }`. Don't clutter your class with manual backing fields.
* **Naming Convention:** By standard .NET convention, private backing fields are prefixed with an underscore (`_`) and use camelCase (e.g., `_totalItems`).
* **Immutability:** If the value should not change after the object is created, use the `readonly` keyword on your backing field. This tells the CLR the memory location cannot be modified after the constructor finishes.
* **Use `init` for DTOs:** In modern .NET, we prefer `public string Id { get; init; }`. This creates a backing field that can only be set during object creation, ensuring thread safety and predictability.
* **Lazy Initialization:** Backing fields are excellent for "Lazy Loading." You can check if the field is `null` in the `get` accessor and only then fetch the data from a database.

---

## Problem Set for Chapter 5: Building Your Own Types with Object-Oriented Programming

**The Scenario:**  
Until now, NetDash has been dealing with loose variables (like serverName and memorySizeGB). As our system grows, tracking individual strings and integers becomes a nightmare. We need to encapsulate this data and its related behavior into distinct Objects.  
**Your Requirements:**  
We are going to define our domain model. Create a new class to represent a Server, and integrate it into our CLI.

1. **The ServerStatus Enum:** Create an enum named ServerStatus with three explicitly numbered states: Offline \= 0, Online \= 1, and Maintenance \= 2\.  
2. **The Server Class & Encapsulation:**

Create a Server class in a *separate file* (Server.cs). This class must contain:

* A property for the server's name (string).  
* A property for the server's memory capacity (int or decimal for GB).  
* A property for the server's current status (ServerStatus).  
3. **Modern C\# 13 / .NET 9 Idioms (Crucial Step):**  
   * A server's name and memory capacity should *never* change after the server is purchased and provisioned. Use modern C\# features to enforce this. You must use either **init-only properties** combined with the **required** modifier, OR use C\# 12/13 **Primary Constructors** to enforce immutability for the Name and Memory properties.  
   * The Status property *can* change, so it should have a standard get and set (or private set).  
4. **Behavior (Methods):**  
   * Write a method inside the Server class called ToggleStatus(). If the server is Offline, make it Online. If it is Online, make it Offline. If it is in Maintenance, output a console message stating "Cannot toggle status while in maintenance mode."  
5. **Integration in Program.cs:**  
   * Add a server command to your menu.  
   * When chosen, prompt the user for a server name and memory size.  
   * Instantiate a new Server object using the user's input (default the status to Offline).  
   * Print the server's details to the console using an overridden .ToString() method on the Server class, or just by accessing its properties.  
   * Call ToggleStatus() on your object.  
   * Print the server's details again to prove the state changed.

**Constraints & Best Practices for this PR:**

* Use file-scoped namespaces across all your files so they map to the same namespace (e.g., namespace Pset05;).  
* Keep the Program.cs file clean. The Server logic belongs completely inside Server.cs.




# Chapter 6: Implementing Interfaces and Inheriting Classes

```text
Explain this code snippet. In the second line, what is the purpose of the the arrow "=>"? Why is the "=" sign not used?

    public List<Person> Spouses { get; set; } = [];
    public bool Married => Spouses.Count > 0;
```

This is a perfect example of how C# allows you to switch between **storing** data and **calculating** data.

To answer your question directly: The `=>` (Expression-bodied member) defines a **calculated property**, whereas the `=` (Assignment) defines an **initial value** for a stored field.

### The Concept: Storage vs. Logic

In your code, you have two very different types of properties:

1. **The First Line (`= []`):** This is **Storage**. You are telling the computer: "Reserve a spot in memory for a list, and right now, put an empty list in that spot." This happens once when the object is created.
2. **The Second Line (`=> ...`):** This is **Logic**. You are telling the computer: "Don't store a `true` or `false` value in memory. Instead, every single time someone asks if I am `Married`, run this little piece of code to find out the answer."

**Why not use the `=` sign?**
If you used `public bool Married = Spouses.Count > 0;`, the code would check the count **only once** (when the object is born). Since the list is empty at birth, `Married` would be `false` forever, even if you added a spouse later! By using `=>`, you ensure the answer is always fresh and accurate.

---

### "Under the Hood"

The compiler treats these two lines very differently:

* **Line 1 (`=`)** creates a hidden **field** (a variable) to hold the list.
* **Line 2 (`=>`)** is "syntactic sugar" for a **ReadOnly Method**. The compiler actually turns it into this:
```csharp
public bool get_Married() 
{
    return this.Spouses.Count > 0;
}
```



There is no variable named `Married` sitting in memory; there is only a method that calculates the result on the fly.

---

### Modern Code Example

In modern .NET, we use `=>` to keep our classes "lean." We avoid storing data that can be easily derived from other data.

```csharp
namespace SocialModel;

public class Person(string name)
{
    public string Name { get; set; } = name;
    public List<Person> Spouses { get; set; } = [];

    // Calculated Property: Always stays in sync with the Spouses list
    public bool Married => Spouses.Count > 0;

    // Another example: Formatting data for display
    public string StatusDisplay => Married 
        ? $"{Name} is married to {string.Join(", ", Spouses.Select(s => s.Name))}" 
        : $"{Name} is single";
}

// Usage
var pete = new Person("Pete");
Console.WriteLine(pete.Married); // Output: False

pete.Spouses.Add(new Person("Alice"));
Console.WriteLine(pete.Married); // Output: True (The => logic re-evaluated!)
```

---

### Best Practices

* **Use `=>` for Simple Derivations:** If a property can be calculated in one line from other fields (like `FullName => $"{FirstName} {LastName}"`), always use the arrow.
* **Performance Warning:** Since `=>` runs the code **every time** you access the property, avoid putting "expensive" logic there (like calling a database or a heavy web API). Use it for fast, in-memory checks.
* **Read-Only by Default:** An expression-bodied property (`=>`) is read-only. You cannot do `person.Married = true;` because there is no underlying variable to save that "true" into.
* **Naming:** Since these behave like properties but act like methods, ensure they don't have "side effects" (they shouldn't change other data while calculating the result).


When you want to go beyond a simple "calculated" value and actually **save** data or trigger logic when a value changes, you can use the `=>` arrow inside your `get` and `set` blocks. This is the bridge between a simple property and a full method.

### The Concept: Property Expression Bodies

In Modern C#, the `=>` symbol is used as a shortcut for the `return` statement (in getters) or a single assignment/statement (in setters).

* **The Problem:** Traditional property syntax with `get { return _field; }` and `set { _field = value; }` is very "noisy." It takes up 5-10 lines of code for very simple logic.
* **The Solution:** Expression-bodied `get` and `set` allow you to keep that logic on a single, readable line while still allowing you to perform actions like **validation** or **logging**.

---

### "Under the Hood"

Even though it looks like a different syntax, the IL (Intermediate Language) generated by the compiler is identical to the old "curly brace" version.

When you use `set => _name = value.Trim();`, the compiler:

1. Creates a method called `set_Name(string value)`.
2. Executes your logic (`value.Trim()`).
3. Assigns the result to your private backing field.

---

### Modern Code Example

Here is how you use the arrow to add "smart" behavior to your properties without the clutter.

```csharp
namespace SmartModels;

public class User
{
    private string _username = string.Empty;
    private int _age;

    // 1. Using => for both Get and Set
    public string Username
    {
        get => _username;
        // Cleanly transform the input before saving it
        set => _username = value.ToLower().Trim();
    }

    // 2. Using => for Validation
    public int Age
    {
        get => _age;
        set => _age = value >= 0 ? value : throw new ArgumentException("Age cannot be negative");
    }

    // 3. Mixing a normal getter with an expression-bodied 'init'
    // This allows setting the ID only during creation.
    public Guid Id { get; init; } = Guid.NewGuid();
}

// Usage
var user = new User { Username = "  Admin_User  ", Age = 25 };
Console.WriteLine(user.Username); // Output: "admin_user"

```

---

### Best Practices

* **Consistency:** If your `get` is a single line, use `=>`. If your `set` is a single line, use `=>`. If one of them requires 10 lines of logic, use `{ }` for both to keep the visual style consistent.
* **The `value` Keyword:** In a `set` block, `value` is a special keyword representing the data being assigned to the property.
* **Validation:** It’s a great place for "Guard Clauses" (like checking for nulls or negative numbers) before the data ever hits your private fields.
* **Don't Overdo It:** If your setter logic starts having "side effects" (like updating a database or changing 5 other variables), move that logic to a dedicated **Method** instead. Properties should feel "cheap" to the user of your class.

**Would you like to see how "Primary Constructors" in C# 12 can make this entire class definition even shorter?**

In C# 12, the team introduced **Primary Constructors**, which is arguably the most significant change to how we write classes in a decade. It allows you to declare constructor parameters directly in the class header.

### The Concept: Collapsing the Boilerplate

Historically, if you wanted a class to have a `Name` and an `Age`, you had to:

1. Declare private fields.
2. Declare a constructor.
3. Assign the constructor parameters to those fields manually.

With **Primary Constructors**, those parameters are automatically available throughout the entire scope of the class. They behave like "private fields" that are initialized at birth.

---

### "Under the Hood"

When you use a Primary Constructor, the compiler:

1. **Captures** the parameters. If you use a parameter inside a method or a property, the compiler silently generates a private field to store that value.
2. **Scopes** them to the class. These parameters are available in property initializers and all method bodies within that class.
3. **Heap Allocation:** Just like a traditional constructor, this happens when the `new` keyword is used, allocating the object on the Managed Heap.

---

### Modern Code Example

Let's rewrite the `User` class from our previous example using this ultra-modern syntax.

```csharp
namespace ModernApp;

// The parameters (string name, int initialAge) are the Primary Constructor
public class User(string name, int initialAge)
{
    // You can use the parameters to initialize properties directly
    public string Username { get; set; } = name.Trim().ToLower();

    // You can use logic with the parameters
    public int Age { get; set; } = initialAge >= 0 
        ? initialAge 
        : throw new ArgumentException("Age cannot be negative");

    // You can even use the parameters in methods!
    public void PrintDetails() 
        => Console.WriteLine($"User: {name}, Age: {Age}"); 
        // Note: 'name' here is the captured parameter, 'Age' is the property.
}

// Usage is exactly the same as a traditional class
var user = new User("  Alpha_Dev  ", 30);

```

---

### Best Practices

* **Property Initialization:** Use Primary Constructors primarily to initialize your properties. It removes the need for `_name = name;` assignments.
* **Dependency Injection:** This is where Primary Constructors shine the most. In ASP.NET Core, you can inject services directly into the class header without writing a bulky constructor.
* **Be Careful with "Capture":** If you use a parameter (like `name`) inside a method, the compiler creates a hidden field. If you *also* have a property named `Name`, you might accidentally use the parameter when you meant the property.
* **Records vs. Classes:**
* In a `record`, Primary Constructor parameters automatically become **public properties**.
* In a `class`, they remain **private** unless you explicitly assign them to a property.



## Delegates and Events

**Events** are actions that happen to an object. They are built on **delegates** that allow objects to pass messages with each other.
You can call a method via a delegate as long as the delegate has the same types of parameters and return values.

Delegates are reference types like class.

When do you use delegates?
- Creating a queue of methods that need to be called in order. This is common in services to improve scalability.
- Allowing multiple actions to run in parallel.
- Implementing events to pass messages between objects, but those objects don't need to know about each other. This allows loose coupling between components.


Two predefined parameters for a delegate:
- `object? sender` - this is a reference to the object that sends the message or the object the raised the event.
- `EventArgs e` or `TEventArgs e` - this contains additional relevant information about the event. For example, in a GUI app, you might define `MouseMoveEventArgs` which has properties X and Y coordinates for the mouse pointer.

Example:
```csharp
public delegate void EventHandler(object? sender, EventArgs e);

public delegate void EventHandler<TEventArgs>(object? sender, TEventArgs e);
```


# Chapter 7: Packaging and Distributing .NET Types

### Problem Set for Chapter 7: Packaging and Distributing .NET Types

**The Scenario:**
Word has spread about your fantastic `ServerUtilities` domain model. Now, the Web Dashboard team wants to use your `Server` and `DatabaseServer` classes in their ASP.NET Core project.

Right now, your domain classes are physically trapped inside your Console Application project (`Pset06`). This violates the principle of reusability. We need to decouple the domain from the UI entirely by creating a compiled assembly (`.dll`) and packaging it so it can be distributed—potentially as a NuGet package!

**Your Requirements:**

1. **The Class Library:**
* Create a brand new .NET 9 Class Library project named `NetDash.ServerUtilities`.
* Move all your domain files (`Server.cs`, `DatabaseServer.cs`, `ServerFactory.cs`, `ServerEnumTypes.cs`, `IRestartable.cs`) out of your Console App and into this new Class Library project.
* Adjust any namespaces if necessary (though `namespace ServerUtilities;` is perfectly fine).


2. **NuGet Packaging:**
* We want this library to be packagable. Open the `.csproj` file for your new `NetDash.ServerUtilities` project.
* Add the necessary MSBuild properties to generate a NuGet package automatically on build.
* Include metadata in the `.csproj`: a `<Version>`, an `<Authors>` tag, and a `<Description>`.


3. **Project Referencing:**
* Back in your Console Application (let's call the project `NetDash.CLI`), you now have a broken application because it doesn't know what a `Server` is anymore.
* Add a **Project Reference** in your Console Application pointing to your new `NetDash.ServerUtilities` Class Library.



**Constraints & Best Practices for this PR:**

* You are shifting from writing code to configuring solutions and assemblies. This is what true Architects do.
* Make sure your Class Library is targeting `net9.0`.

**Deliverables for Review:**
Because I cannot see your local folder structure, to prove you have completed this architectural split, please reply by pasting **only** the following two files:

1. The XML contents of your new Class Library's `.csproj` file.
2. The XML contents of your Console Application's `.csproj` file.

Once you confirm it builds and runs successfully locally and I review your MSBuild configuration, we will advance to **Chapter 8: Working with Common .NET Types**. Let me know if you run into any dependency issues!


# Chapter 8: Working with Common .NET Types

### Problem Set for Chapter 8: Working with Common .NET Types

**The Scenario:**
Currently, our `NetDash` CLI creates a server, prints it, and immediately forgets it on the next loop iteration. Furthermore, we aren't tracking *where* these servers live or how long they have been running.

We need to implement an in-memory data store using Generic Collections, use Regular Expressions (Regex) to validate network addresses, and utilize .NET's highly precise `DateTimeOffset` and `TimeSpan` types to track server uptimes.

**Your Requirements:**

**1. Domain Model Updates (in `NetDash.ServerUtilities`):**

* Open your `Server.cs` class.
* Add a new property: `public required DateTimeOffset ProvisionedOn { get; init; }`. *(Note: We use `DateTimeOffset` instead of `DateTime` in modern architecture to avoid timezone-related bugs!).*
* Add a computed property (a property with only a `get` accessor that calculates its value on the fly) called `Uptime` of type `TimeSpan`. It should calculate the difference between `DateTimeOffset.UtcNow` and `ProvisionedOn`.

**2. The In-Memory Datastore (in `NetDash.CLI`):**

* In `Program.cs`, right *before* your `while(isRunning)` loop starts, declare and initialize a `Dictionary<string, Server>`.
* The `string` key will be the server's IP Address. The `Server` value will be the object itself.

**3. Regular Expressions for IP Validation:**

* Update your `server` creation case. Before asking for the name and memory, prompt the user for an **IPv4 Address**.
* Use the `System.Text.RegularExpressions.Regex` class to validate the input.
* *Constraint:* For this exercise, a simple regex pattern like `@"^\d{1,3}(\.\d{1,3}){3}$"` is perfectly acceptable to ensure it looks like an IP address (e.g., `192.168.1.1`).
* If the regex fails, print an error and `continue;` to the next loop iteration.
* If it succeeds, proceed with creating the server. Add it to your `Dictionary` using the IP address as the key. (Don't forget to set `ProvisionedOn = DateTimeOffset.UtcNow` when calling the factory!)

**4. The `list` Command:**

* Add a new `list` option to your main menu and `switch` statement.
* When chosen, iterate over your `Dictionary` using a `foreach` loop.
* Print the IP Address (the Key), the Server Name, and its `Uptime`.
* *Formatting requirement:* Format the `TimeSpan` output so it only shows `Hours:Minutes:Seconds` (no microscopic fractional milliseconds). You can use standard TimeSpan format strings (like `hh\:mm\:ss`) or custom string interpolation.

**Constraints & Best Practices for this PR:**

* Be careful with your `ServerFactory.Create` signature. You will need to pass the `ProvisionedOn` date into it, or allow the factory to handle setting it!
* Keep your `Regex` clean. If you want to impress me, look into the modern static `Regex.IsMatch()` implementation.

Take your time wiring up the Dictionary and the Regex. This is where your application starts feeling like a real database-backed tool. Paste your updated `Server.cs`, `ServerFactory.cs`, and `Program.cs` files when you are ready for your Chapter 8 code review!


# Chapter 9: Working with Files, Streams, and Serialization

### Problem Set for Chapter 9: Working with Files, Streams, and Serialization

**The Scenario:**
We need `NetDash` to save our server inventory to a JSON file so we can load it back up the next time the application runs. We will use modern `System.Text.Json` serialization. However, we have a unique architectural challenge: our dictionary holds objects of type `Server`, but some of those objects are actually `DatabaseServer`s. Standard serialization often "forgets" derived properties (like `DatabaseEngine`) unless configured properly!

**Your Requirements:**

**1. File Path Strategy (`Program.cs`):**
* At the top of your `Main` method, use `Environment.GetFolderPath` combined with `System.IO.Path.Combine` to construct a safe, cross-platform path to a file named `servers.json` located on the user's **Desktop** or **MyDocuments** folder.

**2. The `save` Command (`Program.cs`):**
* Add a `save` option to your menu.
* When chosen, use `System.Text.Json.JsonSerializer` to serialize your `Dictionary<string, Server>`.
* *Requirement:* You must use a `JsonSerializerOptions` object to set `WriteIndented = true` so the resulting JSON is human-readable.
* Write the resulting JSON string to your file path using `System.IO.File.WriteAllText`. (If you prefer to use `FileStream`, make sure you use a `using` block to safely dispose of the unmanaged file handles!).

**3. The `load` Command (`Program.cs`):**
* Add a `load` option to your menu.
* Check if the `servers.json` file exists. If it does not, print a friendly message and break.
* If it does exist, read the text from the file and deserialize it back into your `Dictionary<string, Server>`. 
* Print the number of servers successfully loaded.

**4. Polymorphic Serialization (`Server.cs` in `NetDash.ServerUtilities`):**
* *Architectural Hint:* If you just serialize the dictionary right now, `System.Text.Json` will look at the `Dictionary<string, Server>` signature and only serialize the base `Server` properties. The `DatabaseEngine` will be lost.
* Open your `Server.cs` file in your Class Library.
* You need to tell the JSON serializer about derived types. In modern .NET, you do this by adding attributes directly above the `public class Server` declaration:
  ```csharp
  using System.Text.Json.Serialization;
  
  [JsonDerivedType(typeof(Server), typeDiscriminator: "general")]
  [JsonDerivedType(typeof(DatabaseServer), typeDiscriminator: "database")]
  public class Server : IRestartable { ... }
  ```
  *(Add this to your domain model so it handles polymorphism gracefully during saving and loading!)*

**Constraints & Best Practices for this PR:**
* Be very careful about exceptions when dealing with the file system. What if the file is locked? Wrap your file I/O operations in a `try...catch` block.
* Ensure you have `using System.Text.Json;` and `using System.IO;` where necessary.


# Chapter 10: Working with Data Using Entity Framework Core

### Problem Set for Chapter 10: Working with Data Using Entity Framework Core

**The Scenario:**
JSON files are great for simple configurations, but `NetDash` is becoming an enterprise tool. We need true relational data storage to handle concurrent reads, complex querying, and data integrity. We are going to replace our in-memory `Dictionary` and flat JSON file with **SQLite**, orchestrated by **Entity Framework Core (EF Core 9)**.

The beautiful part? EF Core uses "Table-Per-Hierarchy" (TPH) by default. This means it will automatically look at your `Server` and `DatabaseServer` classes and seamlessly create a single database table with a `Discriminator` column, just like our JSON serializer did!

**Your Requirements:**

**1. NuGet Packages:**
* Add the `Microsoft.EntityFrameworkCore.Sqlite` package to your `NetDash.ServerUtilities` Class Library.

**2. The Primary Key (`Server.cs`):**
* Relational databases require a Primary Key. Previously, we used the IP Address as the key in our Dictionary. 
* Open `Server.cs` and add a new property: `public required string IpAddress { get; init; }`. 
* Decorate this property with the `[Key]` attribute (you will need the `System.ComponentModel.DataAnnotations` namespace) to explicitly tell EF Core this is our primary identifier.

**3. The Database Context (`AppDbContext.cs`):**
* Inside `NetDash.ServerUtilities`, create a new class named `AppDbContext` that inherits from EF Core's `DbContext`.
* Add a `DbSet` property: `public DbSet<Server> Servers { get; set; }`.
* Override the `OnConfiguring` method. Inside it, configure EF Core to use SQLite and set the connection string to point to a local file: `optionsBuilder.UseSqlite("Data Source=netdash.db");`.

**4. Wiring it up in `Program.cs`:**
* Delete the `Dictionary`. Delete the `save` and `load` commands entirely (databases persist data in real-time!).
* Right before your `while` loop, instantiate your database context: `using AppDbContext db = new();`.
* Call `db.Database.EnsureCreated();`. (This is a handy development method that will look at your classes and automatically generate the `netdash.db` SQLite file and tables if it doesn't exist).

**5. Refactoring the Commands (`Program.cs`):**
* **The `server` Command:** When a user successfully creates a server, instead of adding it to a dictionary, set its `IpAddress` property, add the server object to `db.Servers`, and explicitly call `db.SaveChanges()`.
* **The `list` Command:** Iterate over `db.Servers` instead of the dictionary to print out the servers.

**Constraints & Best Practices for this PR:**
* Remember to pass the IPv4 address into your `ServerFactory` so it can properly set the `IpAddress` property on the newly generated objects.
* When querying `db.Servers` in the `list` command, you don't need a deconstructor `(var (ip, serv))` anymore, because `IpAddress` is now a property directly on the `Server` object!

This is a major architectural shift. Take it one step at a time. Establish the Context, fix your Domain Model, and then wire up the UI. 

Whenever you are ready, please paste your new `AppDbContext.cs`, your updated `Server.cs`, and your refactored `Program.cs`. Good luck! Let me know if you hit any EF Core configuration snags.



# Chapter 11: Querying and Manipulating Data Using LINQ

### Problem Set for Chapter 11: Querying and Manipulating Data Using LINQ

**The Scenario:**
Now that `NetDash` saves data to a real database, the DevOps team has been entering hundreds of servers. Running the `list` command dumps an unreadable wall of text to the console. They need a new **Analytics Dashboard** to filter, sort, and aggregate this data using **LINQ (Language Integrated Query)**.

This is your final exam. You will demonstrate advanced LINQ Method Syntax, including filtering, projecting, and utilizing brand-new C# 13 / .NET 9 aggregation methods!

**Your Requirements:**

**1. The `analytics` Command (`Program.cs`):**
* Add an `analytics` option to your main menu and `switch` statement.

**2. Query 1: Type Filtering and Sorting**
* The team wants to see a list of *only* the Database Servers, sorted so that the ones with the largest `MemoryCapacity` are at the top.
* *Task:* Write a LINQ query against `db.Servers`. Use the `.OfType<DatabaseServer>()` method to filter only the derived types, followed by `.OrderByDescending(...)`. 
* Print the Name, Memory, and Database Engine of the results.

**3. Query 2: Projection**
* The networking team just needs a flat list of Server Names and IP Addresses—they don't need the whole heavy `Server` object.
* *Task:* Write a LINQ query using `.Select(...)` to project `db.Servers` into an anonymous type (or a Tuple) containing just the `Name` and `IpAddress`. Print them out.

**4. Query 3: C# 13 Aggregation (`CountBy`)**
* The team wants a quick summary of how many servers are currently Offline, Online, or in Maintenance.
* *Task:* .NET 9 introduced the highly anticipated `.CountBy(...)` LINQ method! 
* *Architectural Note:* Because EF Core's SQLite provider might not natively translate the brand-new `CountBy` into SQL yet, you should pull the data into local memory first by calling `.AsEnumerable()` on your `DbSet`, and *then* call `.CountBy(s => s.CurrentStatus)`. 
* Iterate over the resulting `KeyValuePair`s and print out the status and the count (e.g., "Online: 4", "Offline: 2").

**Constraints & Best Practices for this PR:**
* Use **LINQ Method Syntax** (e.g., `db.Servers.Where().Select()`) rather than Query Syntax (e.g., `from s in db.Servers select s`). Method syntax is the modern enterprise standard.
* Ensure your queries only execute when you actually need the data (Deferred Execution). The `foreach` loop triggers the execution!

This is the final feature for `NetDash`. Put everything you've learned together. Paste your updated `Program.cs` file (or just the `analytics` case block) whenever you are ready for your final code review!