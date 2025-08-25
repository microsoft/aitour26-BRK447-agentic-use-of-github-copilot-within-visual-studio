namespace PaymentsService.DTOs;

public class CreatePaymentResponse
{
    public Guid PaymentId { get; set; }
    public string Status { get; set; } = "Success";
    public DateTime ProcessedAt { get; set; } = DateTime.UtcNow;
}