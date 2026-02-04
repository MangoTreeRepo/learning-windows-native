/// <summary>
/// MediaLibrarySystem provides a framework for managing a digital media library, supporting books, DVDs, and music albums.
/// </summary>
using System;
using System.Collections.Generic;
namespace MediaLibrarySystem
{  // remember to include new code within the namespace
    public interface IDisplayable
    /// <summary>
    /// Defines a method for displaying information about a media item.
    /// </summary>
    {
        string GetDisplayInfo();
    }
    public interface ISearchable
    /// <summary>
    /// Provides methods for searching and describing media items.
    /// </summary>
    {
        bool MatchesSearch(string searchTerm);
        List<string> GetSearchableTerms();
        string GetShortDescription();
    }
    public abstract class MediaItem : IDisplayable, ISearchable
    /// <summary>
    /// Abstract base class representing a generic media item with common properties and validation logic.
    /// </summary>
    {
        private static int _nextId = 1;
        private readonly int _mediaId;
        private string _title = string.Empty;
        private int _year;
        protected MediaItem(string title, int year)
        {
            _mediaId = _nextId++;
            Title = title; // Uses property setter for validation
            Year = year;   // Uses property setter for validation
        }
        public int MediaId => _mediaId;
    /// <summary>
    /// Gets the unique identifier for this media item.
    /// </summary>
        public string Title
    /// <summary>
    /// Gets or sets the title of the media item.
    /// </summary>
        {
            get => _title;
            set
            {
                ValidateTitle(value);
                _title = value;
            }
        }
        public int Year
    /// <summary>
    /// Gets or sets the year the media item was released or published.
    /// </summary>
        {
            get => _year;
            set
            {
                ValidateYear(value);
                _year = value;
            }
        }
        protected void ValidateTitle(string title)
    /// <summary>
    /// Validates the <paramref name="title"/> for a media item.
    /// </summary>
    /// <param name="title">The title to validate.</param>
    /// <exception cref="ArgumentException">Thrown if the title is invalid.</exception>
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException("Title cannot be empty or whitespace");
            if (title.Length > 100)
                throw new ArgumentException("Title cannot exceed 100 characters");
        }
        protected void ValidateYear(int year)
    /// <summary>
    /// Validates the <paramref name="year"/> for a media item.
    /// </summary>
    /// <param name="year">The year to validate.</param>
    /// <exception cref="ArgumentException">Thrown if the year is out of range.</exception>
        {
            if (year < 1800 || year > DateTime.Now.Year)
                throw new ArgumentException($"Year must be between 1800 and {DateTime.Now.Year}");
        }
        // Abstract method - must be implemented by derived classes
        public abstract string GetDisplayInfo();
    /// <summary>
    /// Returns a detailed string representation of the media item for display.
    /// </summary>
    /// <returns>A string with detailed information about the media item.</returns>
        // Virtual method - can be overridden by derived classes
        public virtual string GetBasicInfo()
    /// <summary>
    /// Returns a basic string representation of the media item.
    /// </summary>
    /// <returns>A string with the title and year.</returns>
        {
            return $"{Title} ({Year})";
        }
        public virtual double GetEstimatedValue()
    /// <summary>
    /// Estimates the value of the media item based on its age and other factors.
    /// </summary>
    /// <returns>The estimated value in dollars.</returns>
        {
            int age = DateTime.Now.Year - Year;
            return Math.Max(5.0, 25.0 - (age * 2.0));
        }
        public virtual string GetCategoryInfo()
    /// <summary>
    /// Returns the category of the media item (e.g., Book, Film, Music).
    /// </summary>
    /// <returns>The category as a string.</returns>
        {
            return "General Media Item";
        }
        // Interface implementations
        public abstract string GetShortDescription();
    /// <summary>
    /// Returns a short description of the media item for summary views.
    /// </summary>
    /// <returns>A short string description.</returns>
        public virtual bool MatchesSearch(string searchTerm)
    /// <summary>
    /// Determines if the media item matches the given search term.
    /// </summary>
    /// <param name="searchTerm">The search term to match.</param>
    /// <returns><c>true</c> if the item matches; otherwise, <c>false</c>.</returns>
        {
            return Title.ToLower().Contains(searchTerm.ToLower());
        }
        public virtual List<string> GetSearchableTerms()
    /// <summary>
    /// Gets a list of terms that can be used to search for this media item.
    /// </summary>
    /// <returns>A list of searchable terms.</returns>
        {
            return new List<string> { Title };
        }
    }
//NEW CODE GOES HERE
}

