namespace PaymentsService.DTOs;

public class PaymentResponse
{
    public List<PaymentRecord> Items { get; set; } = new();
    public int TotalCount { get; set; }
}

public class PaymentRecord
{
    public Guid PaymentId { get; set; }
    public string UserId { get; set; } = string.Empty;
    public string? StoreId { get; set; }
    public string? CartId { get; set; }
    public string Currency { get; set; } = "USD";
    public decimal Amount { get; set; }
    public string Status { get; set; } = "Success";
    public string PaymentMethod { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public DateTime ProcessedAt { get; set; }
    public List<PaymentItem>? Items { get; set; }
}