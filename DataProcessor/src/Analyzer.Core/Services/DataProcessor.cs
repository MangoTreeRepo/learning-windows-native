using Analyzer.Core.Interfaces;

namespace Analyzer.Core.Services;

// Primary Constructor: Dependencies are injected here
public class DataProcessor(
    IFileReader reader,
    IFileWriter writer,
    IRepository repo,
    IValidator validator)
{
    public async Task ProcessDataAsync(string filePath)
    {
        // 1. Read (Decoupled)
        string rawData = reader.ReadText(filePath);

        // 2. Persist (Decoupled)
        repo.SaveRawData(rawData);

        // 3. Validate (Async & Decoupled)
        bool isValid = await validator.ValidateAsync(rawData);

        if (!isValid)
        {
            throw new InvalidOperationException("SEC Data Validation Failed.");
        }

        // 4. Transform (Business Logic)
        string processedData = rawData.ToUpper().Trim();

        // 5. Output (Decoupled)
        writer.WriteText("processed_report.txt", processedData);
    }
}
