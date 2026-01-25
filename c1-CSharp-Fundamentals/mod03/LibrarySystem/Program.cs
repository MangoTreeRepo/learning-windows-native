using System;

namespace LibrarySystem
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1. Initial State
            string[] books = new string[5] { "", "", "", "", "" };

            Console.WriteLine("--- Scalable Library System (Production-Ready) ---");

            while (true)
            {
                Console.WriteLine("\nChoose: [add], [remove], [display], or [exit]");
                // Fixed CS8602 by ensuring null-safety before calling methods
                string action = Console.ReadLine()?.ToLower().Trim() ?? string.Empty;

                if (action == "exit") 
                {
                    break;
                }
                else if (action == "add")
                {
                    // 2. Production-Ready Add Logic
                    int slot = Array.IndexOf(books, "");

                    if (slot == -1)
                    {
                        Console.WriteLine("Error: Library is full (Max 5 books).");
                        continue;
                    }

                    Console.Write("Enter book title: ");
                    string newTitle = Console.ReadLine()?.Trim() ?? string.Empty;

                    // Validation: Check for empty input
                    if (string.IsNullOrWhiteSpace(newTitle))
                    {
                        Console.WriteLine("Error: Title cannot be empty.");
                    }
                    // Validation: Check for duplicates
                    else if (Array.Exists(books, b => b.Equals(newTitle, StringComparison.OrdinalIgnoreCase)))
                    {
                        Console.WriteLine($"Error: '{newTitle}' is already in the library.");
                    }
                    else
                    {
                        books[slot] = newTitle;
                        Console.WriteLine($"Success: '{newTitle}' added.");
                    }
                }
                else if (action == "remove")
                {
                    // 3. Production-Ready Remove Logic
                    Console.Write("Enter title to remove: ");
                    string target = Console.ReadLine()?.Trim() ?? string.Empty;

                    if (string.IsNullOrWhiteSpace(target))
                    {
                        Console.WriteLine("Error: Please enter a title to remove.");
                        continue;
                    }

                    bool found = false;
                    for (int i = 0; i < books.Length; i++)
                    {
                        if (books[i].Equals(target, StringComparison.OrdinalIgnoreCase))
                        {
                            books[i] = ""; 
                            found = true;
                            Console.WriteLine($"Success: '{target}' removed.");
                            break; 
                        }
                    }

                    if (!found) Console.WriteLine($"Error: Book '{target}' not found.");
                }
                else if (action == "display")
                {
                    // 4. Clean Display Logic
                    Console.WriteLine("\nCurrent Collection:");
                    bool hasBooks = false;
                    foreach (string book in books)
                    {
                        if (!string.IsNullOrWhiteSpace(book))
                        {
                            Console.WriteLine($"- {book}");
                            hasBooks = true;
                        }
                    }
                    if (!hasBooks) Console.WriteLine("(Library is currently empty)");
                }
                else
                {
                    Console.WriteLine("Invalid command. Please use add, remove, display, or exit.");
                }
            }
        }
    }
}