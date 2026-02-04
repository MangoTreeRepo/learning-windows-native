/// <summary>
    /// Entry point for the MediaLibrarySystem application.
    /// </summary>
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Media Library Management System!");
            Console.WriteLine("=============================================");
            try
            {
                // Create media library
                MediaLibrary library = new MediaLibrary();
                // Add various media items to demonstrate inheritance and polymorphism
                library.AddItem(new Book("The Great Gatsby", 1925, "F. Scott Fitzgerald", 180));
                library.AddItem(new Book("To Kill a Mockingbird", 1960, "Harper Lee", 324));
                library.AddItem(new DVD("The Matrix", 1999, "The Wachowskis", 136));
                library.AddItem(new DVD("Inception", 2010, "Christopher Nolan", 148));
                library.AddItem(new MusicAlbum("Abbey Road", 1969, "The Beatles", 17));
                library.AddItem(new MusicAlbum("Dark Side of the Moon", 1973, "Pink Floyd", 10));
                // Demonstrate polymorphic display
                library.DisplayAllItems();
                // Demonstrate search functionality
                Console.WriteLine("\n=== Search Demo ===");
                var searchResults = library.SearchItems("Matrix");
                Console.WriteLine($"Search results for 'Matrix':");
                foreach (var item in searchResults)
                {
                    Console.WriteLine($"  - {item.GetDisplayInfo()}");
                }
                // Demonstrate detailed reporting with polymorphic method calls
                library.GetDetailedReport();
                // Demonstrate finding specific items
                Console.WriteLine("\n=== Find by Title Demo ===");
                var foundItem = library.FindByTitle("Great Gatsby");
                if (foundItem != null)
                {
                    Console.WriteLine($"Found: {foundItem.GetDisplayInfo()}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            Console.WriteLine("\nThank you for using the Media Library System!");
            Console.ReadLine();
        }
    }


