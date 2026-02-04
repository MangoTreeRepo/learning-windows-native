namespace Analyzer.Core.Interfaces;
public interface IValidator
{
    Task<bool> ValidateAsync(string data);
}
