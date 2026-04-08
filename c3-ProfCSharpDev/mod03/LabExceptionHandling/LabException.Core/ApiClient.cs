using System.Net.Sockets;

namespace LabException.Core;

public class ApiClient
{
    private readonly HttpClient _client;

    public ApiClient(HttpClient client)
    {
        _client = client;
    }
    public async Task<string> GetDataAsync(string url)
    {
        int maxRetries = 3;
        int delayMs = 1000;

        for (int i = 0; i < maxRetries; i++)
        {
            try
            {
                return await _client.GetStringAsync(url);
            }
            catch (Exception ex) when (ex is HttpRequestException || ex is TaskCanceledException || ex is SocketException)
            {
                // If it's thge last attempt, we give up and throw
                if (i == maxRetries - 1) throw;

                // Log retry attemt (Architect's tip: avoid Console in production, but useful for lab)
                Console.WriteLine($"Transient error detected. Retry {i + 1} of {maxRetries} after {delayMs}ms...");
            
                await Task.Delay(delayMs);
                delayMs *= 2; // Exponential backoff
            }
        }

        throw new Exception("Execution reached unreachable code in ApiClient.");
    }
}