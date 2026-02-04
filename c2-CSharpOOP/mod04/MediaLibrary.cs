/// <summary>
    /// Manages a collection of media items, providing methods to add, search, and display items in the library.
    /// </summary>
    {
        private List<MediaItem> _mediaItems;
        public MediaLibrary()
        {
            _mediaItems = new List<MediaItem>();
        }
        public void AddItem(MediaItem item)
    /// <summary>
    /// Adds a <see cref="MediaItem"/> to the library.
    /// </summary>
    /// <param name="item">The media item to add.</param>
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));
            _mediaItems.Add(item);
            Console.WriteLine($"Added: {item.GetShortDescription()}");
        }
        public void DisplayAllItems()
    /// <summary>
    /// Displays all media items in the library.
    /// </summary>
        {
            if (_mediaItems.Count == 0)
            {
                Console.WriteLine("No items in the library.");
                return;
            }
            Console.WriteLine("\n=== Media Library Contents ===");
            foreach (MediaItem item in _mediaItems)
            {
                // Polymorphic method call - each type displays differently
                Console.WriteLine(item.GetDisplayInfo());
            }
        }
        public MediaItem? FindByTitle(string title)
    /// <summary>
    /// Finds a <see cref="MediaItem"/> by its title.
    /// </summary>
    /// <param name="title">The title to search for.</param>
    /// <returns>The found <see cref="MediaItem"/>, or <c>null</c> if not found.</returns>
        {
            if (string.IsNullOrWhiteSpace(title))
                return null;
            foreach (MediaItem item in _mediaItems)
            {
                if (item.Title.ToLower().Contains(title.ToLower()))
                    return item;
            }
            return null;
        }
        public List<MediaItem> SearchItems(string searchTerm)
    /// <summary>
    /// Searches for media items that match the given search term.
    /// </summary>
    /// <param name="searchTerm">The term to search for.</param>
    /// <returns>A list of matching <see cref="MediaItem"/> objects.</returns>
        {
            List<MediaItem> results = new List<MediaItem>();
            foreach (MediaItem item in _mediaItems)
            {
                if (item.MatchesSearch(searchTerm))
                    results.Add(item);
            }
            return results;
        }
        public void GetDetailedReport()
    /// <summary>
    /// Displays a detailed report of all media items, including category and estimated value.
    /// </summary>
        {
            Console.WriteLine("\n=== Detailed Library Report ===");
            double totalValue = 0;
            foreach (MediaItem item in _mediaItems)
            {
                Console.WriteLine($"{item.GetDisplayInfo()}");
                Console.WriteLine($"  Category: {item.GetCategoryInfo()}");
                Console.WriteLine($"  Estimated Value: ${item.GetEstimatedValue():F2}");
                Console.WriteLine();
                totalValue += item.GetEstimatedValue();
            }
            Console.WriteLine($"Total Library Value: ${totalValue:F2}");
        }
    }
