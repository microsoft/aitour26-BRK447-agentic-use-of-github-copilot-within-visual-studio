using PaymentsService.DTOs;

namespace PaymentsService.Services;

public interface IPaymentRepository
{
    Task<Models.PaymentRecord> CreatePaymentAsync(CreatePaymentRequest request);
    Task<(List<Models.PaymentRecord> Items, int TotalCount)> GetPaymentsAsync(int page = 1, int pageSize = 10, string? status = null);
    Task<Models.PaymentRecord?> GetPaymentByIdAsync(Guid paymentId);
}