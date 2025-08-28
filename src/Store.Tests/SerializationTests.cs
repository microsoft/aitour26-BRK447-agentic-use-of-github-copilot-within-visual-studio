using SearchEntities;
using VectorEntities;
using DataEntities;
using System.Text.Json;

namespace Store.Tests;

[TestClass] 
public class SerializationTests
{
    [TestMethod]
    public void SearchResponse_SerializesAndDeserializes_Correctly()
    {
        // Arrange
        var originalResponse = new SearchResponse
        {
            Response = "Test response message",
            Products = new List<Product>
            {
                new Product { Id = 1, Name = "Test Product", Description = "Test Description", Price = 19.99m, ImageUrl = "test.jpg" },
                new Product { Id = 2, Name = "Another Product", Description = "Another Description", Price = 29.99m, ImageUrl = "another.jpg" }
            }
        };

        // Act
        var json = JsonSerializer.Serialize(originalResponse);
        var deserializedResponse = JsonSerializer.Deserialize<SearchResponse>(json);

        // Assert
        Assert.IsNotNull(deserializedResponse);
        Assert.AreEqual(originalResponse.Response, deserializedResponse.Response);
        Assert.AreEqual(originalResponse.Products.Count, deserializedResponse.Products.Count);
        Assert.AreEqual(originalResponse.Products[0].Name, deserializedResponse.Products[0].Name);
        Assert.AreEqual(originalResponse.Products[0].Price, deserializedResponse.Products[0].Price);
    }

    [TestMethod]
    public void SearchResponse_SerializesEmptyProducts_Correctly()
    {
        // Arrange
        var originalResponse = new SearchResponse
        {
            Response = "No products found",
            Products = new List<Product>()
        };

        // Act
        var json = JsonSerializer.Serialize(originalResponse);
        var deserializedResponse = JsonSerializer.Deserialize<SearchResponse>(json);

        // Assert
        Assert.IsNotNull(deserializedResponse);
        Assert.AreEqual("No products found", deserializedResponse.Response);
        Assert.AreEqual(0, deserializedResponse.Products.Count);
    }

    [TestMethod]
    public void ProductVector_SerializesAndDeserializes_Correctly()
    {
        // Arrange
        var originalVector = new ProductVector
        {
            Id = 42,
            Name = "Vector Product",
            Description = "Vector Description",
            Price = 99.99m,
            ImageUrl = "vector.jpg",
            Vector = new ReadOnlyMemory<float>(new float[] { 0.1f, 0.2f, 0.3f, 0.4f, 0.5f })
        };

        // Act
        var json = JsonSerializer.Serialize(originalVector);
        var deserializedVector = JsonSerializer.Deserialize<ProductVector>(json);

        // Assert
        Assert.IsNotNull(deserializedVector);
        Assert.AreEqual(originalVector.Id, deserializedVector.Id);
        Assert.AreEqual(originalVector.Name, deserializedVector.Name);
        Assert.AreEqual(originalVector.Description, deserializedVector.Description);
        Assert.AreEqual(originalVector.Price, deserializedVector.Price);
        Assert.AreEqual(originalVector.ImageUrl, deserializedVector.ImageUrl);
        
        // Compare the vector arrays by converting to arrays
        var originalArray = originalVector.Vector.ToArray();
        var deserializedArray = deserializedVector.Vector.ToArray();
        CollectionAssert.AreEqual(originalArray, deserializedArray);
    }

    [TestMethod]
    public void ProductVector_SerializesNullVector_Correctly()
    {
        // Arrange
        var originalVector = new ProductVector
        {
            Id = 1,
            Name = "Product Without Vector",
            Description = "Description",
            Price = 10.00m,
            ImageUrl = "image.jpg",
            Vector = ReadOnlyMemory<float>.Empty
        };

        // Act
        var json = JsonSerializer.Serialize(originalVector);
        var deserializedVector = JsonSerializer.Deserialize<ProductVector>(json);

        // Assert
        Assert.IsNotNull(deserializedVector);
        Assert.AreEqual(originalVector.Id, deserializedVector.Id);
        Assert.AreEqual(originalVector.Name, deserializedVector.Name);
        Assert.IsTrue(deserializedVector.Vector.IsEmpty);
    }

    [TestMethod]
    public void SearchResponse_JsonFormat_MatchesExpectedStructure()
    {
        // Arrange
        var response = new SearchResponse
        {
            Response = "Found 1 product",
            Products = new List<Product>
            {
                new Product { Id = 123, Name = "Sample", Description = "Desc", Price = 50.00m, ImageUrl = "sample.jpg" }
            }
        };

        // Act
        var json = JsonSerializer.Serialize(response, new JsonSerializerOptions { WriteIndented = true });

        // Assert - Check actual JSON property names based on JsonPropertyName attributes
        Assert.IsTrue(json.Contains("\"id\":")); // Response property maps to "id"
        Assert.IsTrue(json.Contains("\"products\":")); // Products property maps to "products"
        Assert.IsTrue(json.Contains("Found 1 product"));
        Assert.IsTrue(json.Contains("\"name\":"));
        Assert.IsTrue(json.Contains("\"price\":"));
        Assert.IsTrue(json.Contains("\"description\":"));
    }
}