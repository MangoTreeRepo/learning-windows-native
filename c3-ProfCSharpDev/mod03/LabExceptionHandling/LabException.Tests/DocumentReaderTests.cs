using Xunit;
using LabException.Core;
using System;
using System.IO;

namespace LabException.Tests;

public class DocumentReaderTests
{
    private readonly DocumentReader _reader = new();

    [Fact]
    public void ReadDocument_ValidFile_ReturnsContent()
    {
        // ARRANGE
        string path = Path.GetTempFileName();
        string expectedContent = "SEC Financial Data 2026";
        File.WriteAllText(path, expectedContent);

        // ACT
        string result = _reader.ReadDocument(path);

        // ASSERT
        Assert.Equal(expectedContent, result);

        // Cleanup
        File.Delete(path);
    }

    [Fact]
    public void ReadDocument_FileNotFound_ThrowsFileNotFoundException()
    {
        // ARRANGE
        string path = "missing_file_123.txt";

        // ACT & ASSERT
        Assert.Throws<FileNotFoundException>(() => _reader.ReadDocument(path));
    }

    [Fact]
    public void ReadDocument_DirectoryNotFound_ThrowsDirectoryNotFoundException()
    {
        // ARRANGE
        string path = @"/Invalid/Path/To/Folder/file.txt";

        // ACT & ASSERT
        Assert.Throws<DirectoryNotFoundException>(() => _reader.ReadDocument(path));
    }

    [Fact]
    public void ReadDocument_UnauthorizedAccess_ThrowsUnauthorizedAccessException()
    {
        // ARRANGE: Path that requires admin/root privileges on Mac
        string path = "/etc/sudoers";

        // ACT & ASSERT
        Assert.Throws<UnauthorizedAccessException>(() => _reader.ReadDocument(path));
    }

    [Fact]
    public void ReadDocument_LockedFile_ThrowsIOException()
    {
        // ARRANGE: Create a file and lock it
        string path = Path.GetTempFileName();
        using var stream = File.Open(path, FileMode.Open, FileAccess.ReadWrite, FileShare.None);

        // ACT & ASSERT
        Assert.Throws<IOException>(() => _reader.ReadDocument(path));
    }
}
