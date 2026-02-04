/// <summary>
    /// Represents a book in the media library, including author and page count information.
    /// </summary>
    {
        private string _author = string.Empty;
        private int _pageCount;
        public Book(string title, int year, string author, int pageCount)
            : base(title, year)
        {
            Author = author;
            PageCount = pageCount;
        }
        public string Author
    /// <summary>
    /// Gets or sets the author of the book.
    /// </summary>
        {
            get => _author;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Author cannot be empty");
                _author = value;
            }
        }
        public int PageCount
    /// <summary>
    /// Gets or sets the number of pages in the book.
    /// </summary>
        {
            get => _pageCount;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Page count must be positive");
                _pageCount = value;
            }
        }
        public override string GetDisplayInfo()
    /// <inheritdoc/>
        {
            return $"Book: {Title} by {Author} ({Year}) - {PageCount} pages";
        }
        public override string GetShortDescription()
    /// <inheritdoc/>
        {
            return $"{Title} by {Author}";
        }
        public override double GetEstimatedValue()
    /// <inheritdoc/>
        {
            double baseValue = base.GetEstimatedValue();
            // Books with more pages tend to be worth more
            double pageBonus = PageCount > 300 ? 5.0 : 0.0;
            return baseValue + pageBonus;
        }
        public override string GetCategoryInfo()
    /// <inheritdoc/>
        {
            return "Literature";
        }
        public override List<string> GetSearchableTerms()
    /// <inheritdoc/>
        {
            var terms = base.GetSearchableTerms();
            terms.Add(Author);
            return terms;
        }
    }
    public class DVD : MediaItem
    /// <summary>
    /// Represents a DVD in the media library, including director and duration information.
    /// </summary>
    {
        private string _director = string.Empty;
        private int _durationMinutes;
        public DVD(string title, int year, string director, int durationMinutes)
            : base(title, year)
        {
            Director = director;
            DurationMinutes = durationMinutes;
        }
        public string Director
    /// <summary>
    /// Gets or sets the director of the DVD.
    /// </summary>
        {
            get => _director;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Director cannot be empty");
                _director = value;
            }
        }
        public int DurationMinutes
    /// <summary>
    /// Gets or sets the duration of the DVD in minutes.
    /// </summary>
    /// <inheritdoc/>
    /// <inheritdoc/>
    /// <inheritdoc/>
    /// <inheritdoc/>
    /// <inheritdoc/>
        {
            get => _durationMinutes;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Duration must be positive");
                _durationMinutes = value;
            }
        }
        public override string GetDisplayInfo()
        {
            return $"DVD: {Title} directed by {Director} ({Year}) - {DurationMinutes} min";
        }
        public override string GetShortDescription()
        {
            return $"{Title} directed by {Director}";
        }
        public override double GetEstimatedValue()
        {
            double baseValue = base.GetEstimatedValue();
            // DVDs with longer duration may be worth a bit more
            double durationBonus = DurationMinutes > 120 ? 3.0 : 0.0;
            return baseValue + durationBonus;
        }
        public override string GetCategoryInfo()
        {
            return "Film";
        }
        public override List<string> GetSearchableTerms()
        {
            var terms = base.GetSearchableTerms();
            terms.Add(Director);
            return terms;
        }
    }
    public class MusicAlbum : MediaItem
    /// <summary>
    /// Represents a music album in the media library, including artist and track information.
    /// </summary>
    {
        private string _artist = string.Empty;
        private int _trackCount;
        public MusicAlbum(string title, int year, string artist, int trackCount)
            : base(title, year)
        {
            Artist = artist;
            TrackCount = trackCount;
        }
        public string Artist
    /// <summary>
    /// Gets or sets the artist of the music album.
    /// </summary>
        {
            get => _artist;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Artist cannot be empty");
                _artist = value;
            }
        }
        public int TrackCount
    /// <summary>
    /// Gets or sets the number of tracks in the music album.
    /// </summary>
    /// <inheritdoc/>
    /// <inheritdoc/>
    /// <inheritdoc/>
    /// <inheritdoc/>
    /// <inheritdoc/>
        {
            get => _trackCount;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Track count must be positive");
                _trackCount = value;
            }
        }
        public override string GetDisplayInfo()
        {
            return $"Music Album: {Title} by {Artist} ({Year}) - {TrackCount} tracks";
        }
        public override string GetShortDescription()
        {
            return $"{Title} by {Artist}";
        }
        public override double GetEstimatedValue()
        {
            double baseValue = base.GetEstimatedValue();
            // Albums with more tracks may be worth a bit more
            double trackBonus = TrackCount > 12 ? 4.0 : 0.0;
            return baseValue + trackBonus;
        }
        public override string GetCategoryInfo()
        {
            return "Music";
        }
        public override List<string> GetSearchableTerms()
        {
            var terms = base.GetSearchableTerms();
            terms.Add(Artist);
            return terms;
        }
    }
