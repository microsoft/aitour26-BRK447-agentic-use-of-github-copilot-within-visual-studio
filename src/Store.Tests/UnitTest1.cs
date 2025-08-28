using Store.Services;
using DataEntities;
using SearchEntities;
using Microsoft.Extensions.Logging;
using Moq;
using Moq.Protected;
using System.Net;
using System.Text;
using System.Text.Json;

namespace Store.Tests;

[TestClass]
public class ProductServiceTests
{
    private Mock<HttpMessageHandler> _mockHttpMessageHandler = null!;
    private HttpClient _httpClient = null!;
    private Mock<ILogger<ProductService>> _mockLogger = null!;
    private ProductService _productService = null!;

    [TestInitialize]
    public void Setup()
    {
        _mockHttpMessageHandler = new Mock<HttpMessageHandler>();
        _httpClient = new HttpClient(_mockHttpMessageHandler.Object)
        {
            BaseAddress = new Uri("https://localhost")
        };
        _mockLogger = new Mock<ILogger<ProductService>>();
        _productService = new ProductService(_httpClient, _mockLogger.Object);
    }

    [TestCleanup]
    public void Cleanup()
    {
        _httpClient?.Dispose();
    }

    [TestMethod]
    public async Task GetProducts_ReturnsProducts_WhenHttpOk()
    {
        // Arrange
        var products = new List<Product>
        {
            new Product { Id = 1, Name = "Test Product", Description = "Test", Price = 10.99m, ImageUrl = "test.jpg" }
        };
        var json = JsonSerializer.Serialize(products);
        var response = new HttpResponseMessage(HttpStatusCode.OK)
        {
            Content = new StringContent(json, Encoding.UTF8, "application/json")
        };

        _mockHttpMessageHandler
            .Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(response);

        // Act
        var result = await _productService.GetProducts();

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(1, result.Count);
        Assert.AreEqual("Test Product", result[0].Name);
    }

    [TestMethod]
    public async Task GetProducts_ReturnsEmpty_WhenHttpNotOkOrException()
    {
        // Arrange
        var response = new HttpResponseMessage(HttpStatusCode.InternalServerError);

        _mockHttpMessageHandler
            .Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(response);

        // Act
        var result = await _productService.GetProducts();

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(0, result.Count);
    }

    [TestMethod]
    public async Task GetProducts_ReturnsEmpty_WhenException()
    {
        // Arrange
        _mockHttpMessageHandler
            .Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
            .ThrowsAsync(new HttpRequestException("Network error"));

        // Act
        var result = await _productService.GetProducts();

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(0, result.Count);
    }

    [TestMethod]
    public async Task Search_UsesAiEndpoint_WhenSemanticSearchTrue()
    {
        // Arrange
        var searchResponse = new SearchResponse { Response = "AI Response", Products = new List<Product>() };
        var json = JsonSerializer.Serialize(searchResponse);
        var response = new HttpResponseMessage(HttpStatusCode.OK)
        {
            Content = new StringContent(json, Encoding.UTF8, "application/json")
        };

        _mockHttpMessageHandler
            .Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.Is<HttpRequestMessage>(req => req.RequestUri!.ToString().Contains("/api/aisearch/")),
                ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(response);

        // Act
        var result = await _productService.Search("tent", semanticSearch: true);

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual("AI Response", result.Response);
    }

    [TestMethod]
    public async Task Search_UsesStandardEndpoint_WhenSemanticSearchFalse()
    {
        // Arrange
        var searchResponse = new SearchResponse { Response = "Standard Response", Products = new List<Product>() };
        var json = JsonSerializer.Serialize(searchResponse);
        var response = new HttpResponseMessage(HttpStatusCode.OK)
        {
            Content = new StringContent(json, Encoding.UTF8, "application/json")
        };

        _mockHttpMessageHandler
            .Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.Is<HttpRequestMessage>(req => req.RequestUri!.ToString().Contains("/api/product/search/")),
                ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(response);

        // Act
        var result = await _productService.Search("tent", semanticSearch: false);

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual("Standard Response", result.Response);
    }

    [TestMethod]
    public async Task Search_ReturnsDefaultResponse_WhenException()
    {
        // Arrange
        _mockHttpMessageHandler
            .Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
            .ThrowsAsync(new HttpRequestException("Network error"));

        // Act
        var result = await _productService.Search("tent");

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual("No response", result.Response);
    }
}
