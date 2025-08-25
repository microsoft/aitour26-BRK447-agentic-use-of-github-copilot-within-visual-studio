using System.Text.Json;

namespace Store.Services;

public interface IPaymentsClient
{
    Task<PaymentResult> ProcessPaymentAsync(CreatePaymentRequest request);
}

public class PaymentsClient : IPaymentsClient
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<PaymentsClient> _logger;

    public PaymentsClient(HttpClient httpClient, ILogger<PaymentsClient> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
    }

    public async Task<PaymentResult> ProcessPaymentAsync(CreatePaymentRequest request)
    {
        try
        {
            _logger.LogInformation("Processing payment for user {UserId} with amount {Amount} {Currency}", 
                request.UserId, request.Amount, request.Currency);

            var response = await _httpClient.PostAsJsonAsync("/api/payments", request);
            
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<CreatePaymentResponse>(content, new JsonSerializerOptions 
                { 
                    PropertyNameCaseInsensitive = true 
                });
                
                return new PaymentResult 
                { 
                    IsSuccess = true, 
                    PaymentId = result?.PaymentId ?? Guid.Empty,
                    ProcessedAt = result?.ProcessedAt ?? DateTime.UtcNow
                };
            }
            else
            {
                var error = await response.Content.ReadAsStringAsync();
                _logger.LogError("Payment failed with status {StatusCode}: {Error}", response.StatusCode, error);
                return new PaymentResult 
                { 
                    IsSuccess = false, 
                    ErrorMessage = $"Payment failed: {response.StatusCode}"
                };
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error processing payment for user {UserId}", request.UserId);
            return new PaymentResult 
            { 
                IsSuccess = false, 
                ErrorMessage = "An error occurred while processing the payment"
            };
        }
    }
}

// DTOs for payment integration
public class CreatePaymentRequest
{
    public string? StoreId { get; set; }
    public string UserId { get; set; } = string.Empty;
    public string? CartId { get; set; }
    public string Currency { get; set; } = "USD";
    public decimal Amount { get; set; }
    public List<PaymentItem> Items { get; set; } = new();
    public string PaymentMethod { get; set; } = string.Empty;
    public object? Metadata { get; set; }
}

public class PaymentItem
{
    public string ProductId { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
}

public class CreatePaymentResponse
{
    public Guid PaymentId { get; set; }
    public string Status { get; set; } = "Success";
    public DateTime ProcessedAt { get; set; }
}

public class PaymentResult
{
    public bool IsSuccess { get; set; }
    public Guid PaymentId { get; set; }
    public DateTime ProcessedAt { get; set; }
    public string? ErrorMessage { get; set; }
}