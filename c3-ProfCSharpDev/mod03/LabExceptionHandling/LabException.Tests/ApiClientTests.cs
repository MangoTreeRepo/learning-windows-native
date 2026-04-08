using Xunit;
using Moq;
using Moq.Protected;
using System.Net;
using System.Net.Http; // Added for HttpRequestMessage
using System.Threading; // Added for CancellationToken
using System.Threading.Tasks;
using LabException.Core;

namespace LabException.Tests;

public class ApiClientTests
{
    [Fact]
    public async Task GetDataAsync_OnTimeout_RetriesAndEventuallyThrows()
    {
        // ARRANGE: Set up a handler that always times out
        var handlerMock = new Mock<HttpMessageHandler>();
        handlerMock
            .Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>()
            )
            .ThrowsAsync(new TaskCanceledException("Timeout simulated"));

        var httpClient = new HttpClient(handlerMock.Object);
        var apiClient = new ApiClient(httpClient);

        // ACT & ASSERT
        // Verify that after all retries, the exception is still bubble up
        await Assert.ThrowsAsync<TaskCanceledException>(() => apiClient.GetDataAsync("https://api.sec.gov/data"));

        // Verify it actually tried 3 times
        handlerMock.Protected().Verify(
            "SendAsync",
            Times.Exactly(3),
            ItExpr.IsAny<HttpRequestMessage>(),
            ItExpr.IsAny<CancellationToken>()
        );
    }

    [Fact]
    public async Task GetDataAsync_SuccessOnSecondTry_ReturnsData()
    {
        // ARRANGE: Fail once, then succeed
        var handlerMock = new Mock<HttpMessageHandler>();

        handlerMock
            .Protected()
            .SetupSequence<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>()
            )
            .ThrowsAsync(new HttpRequestException("First attempt failed")) // Fail 1
            .ReturnsAsync(new HttpResponseMessage // Succeed 2
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent("SEC Data Received")    
            });
        
        var htpClient = new HttpClient(handlerMock.Object);
        var apiClient = new ApiClient(htpClient);

        // ACT
        var result = await apiClient.GetDataAsync("https://api.sec.gov/data");

        // ASSERT
        Assert.Equal("SEC Data Received", result);
    }
}