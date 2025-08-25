using System.ComponentModel.DataAnnotations;

namespace PaymentsService.DTOs;

public class CreatePaymentRequest
{
    public string? StoreId { get; set; }
    
    [Required]
    public string UserId { get; set; } = string.Empty;
    
    public string? CartId { get; set; }
    
    [Required]
    public string Currency { get; set; } = "USD";
    
    [Required]
    [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be greater than 0")]
    public decimal Amount { get; set; }
    
    [Required]
    public List<PaymentItem> Items { get; set; } = new();
    
    [Required]
    public string PaymentMethod { get; set; } = string.Empty;
    
    public object? Metadata { get; set; }
}

public class PaymentItem
{
    [Required]
    public string ProductId { get; set; } = string.Empty;
    
    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1")]
    public int Quantity { get; set; }
    
    [Required]
    [Range(0, double.MaxValue, ErrorMessage = "Unit price must be non-negative")]
    public decimal UnitPrice { get; set; }
}