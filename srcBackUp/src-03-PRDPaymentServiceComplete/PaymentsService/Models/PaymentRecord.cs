using System.ComponentModel.DataAnnotations;

namespace PaymentsService.Models;

public class PaymentRecord
{
    [Key]
    public Guid PaymentId { get; set; } = Guid.NewGuid();
    
    [Required]
    public string UserId { get; set; } = string.Empty;
    
    public string? StoreId { get; set; }
    
    public string? CartId { get; set; }
    
    [Required]
    public string Currency { get; set; } = "USD";
    
    [Required]
    public decimal Amount { get; set; }
    
    [Required]
    public string Status { get; set; } = "Success";
    
    [Required]
    public string PaymentMethod { get; set; } = string.Empty;
    
    public string? ItemsJson { get; set; }
    
    public string? ProductEnrichmentJson { get; set; }
    
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    
    public DateTime ProcessedAt { get; set; } = DateTime.UtcNow;
}