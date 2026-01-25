# Learning C#

### **Phase 1: The Foundations (Days 1–10)**

**Goal:** Learn the "grammar" of C# and how to control the flow of a program.

* **Days 1-3: Environment & Entry Points** 💻
* Set up the `.NET 10` environment in VS Code.
* Master the `dotnet CLI` (`new`, `run`, `build`) to manage your solution.
* Learn **Top-level statements** to write clean code without the old-fashioned "boilerplate."


* **Days 4-7: Data Types & Logic** 🔢
* **Variables:** Learn how to store numbers (`int`, `decimal`), text (`string`), and truth values (`bool`).
* **Control Flow:** Use `if/else` statements and modern `switch` expressions to make decisions.
* **Loops:** Focus on `foreach` to move through lists of data (like a list of stock prices).


* **Days 8-10: Methods & String Power** ✍️
* Learn **String Interpolation** to build dynamic messages.
* Write **Methods** with parameters and return types to make your code reusable.



### **Phase 2: Data Structures & "Professional" Patterns (Days 11–20)**

**Goal:** Organize code for a complex financial system.

* **Days 11-13: Records, Classes, & Structs** 🏗️
* Master **Records** for "Immutable" (unchangeable) data—essential for financial audit trails.
* Use **Classes** for the "brains" of the app (like the logic that calculates tax).


* **Days 14-17: Interfaces & Clean Architecture** 🧩
* Focus on **Interfaces** to define "contracts" for your code (e.g., "Any data source must have a `GetRevenue()` method").
* Learn **Primary Constructors** to keep your code concise.


* **Days 18-20: Collections & LINQ** 🔍
* Master `List<T>` and `Dictionary<K,V>` to store groups of financial records.
* Learn **LINQ** (C#'s superpower) to filter and search through data with single-line commands.



### **Phase 3: Moving Data & The Local Brain (Days 21–30)**

**Goal:** Handle external files and local AI processing.

* **Days 21-23: Async/Await (Concurrency)** ⏳
* Learn to use `Task` and `await` so the app stays responsive while processing large PDF files.


* **Days 24-27: Local Data with SQLite** 🗄️
* Learn how to save and load the "Cartridge" (`.secproj`) files using **Entity Framework Core**.


* **Days 28-30: AI Orchestration** 🧠
* Introduction to **Microsoft Semantic Kernel** to prepare for running local LLMs like Phi-3.



---

### **Phase 4: Building the Sovereign-Ironclad (Day 31+)**

**Goal:** Deep integration with Windows and Excel.

* **Native Windows UI:** Building the visual shell with **WinUI 3**.
* **Excel Integration:** Building the **VSTO** bridge and using **Named Pipes** for microsecond-fast communication between your app and spreadsheets.
* **The Deck Builder:** Generating PowerPoint and Word files using the **OpenXML SDK**.
