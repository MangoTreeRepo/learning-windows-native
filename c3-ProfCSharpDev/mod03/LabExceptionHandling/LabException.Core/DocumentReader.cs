namespace LabException.Core;

public class DocumentReader
{
    /// <summary>
    /// Reads a document and returns its content.
    /// Exceptions are bubbled up to the caller for proper handling.
    /// </summary>
    public string ReadDocument(string filePath)
    {
        if (string.IsNullOrEmpty(filePath))
            throw new ArgumentException("File path cannot be empty.", nameof(filePath));
        
        try
        {
            return File.ReadAllText(filePath);
        }
        catch (DirectoryNotFoundException)
        {
            throw;
        }
        catch (FileNotFoundException)
        {
            throw;
        }
        catch (UnauthorizedAccessException)
        {
            throw;
        }
        catch (IOException)
        {
            throw;
        }
    }
}
