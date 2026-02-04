namespace Analyzer.Core.Interfaces;

public interface IFileReader
{
    string ReadText(string path);
}

public interface IFileWriter
{
    void WriteText(string path, string content);
}
