using Microsoft.EntityFrameworkCore;
using PaymentsService.Data;
using PaymentsService.DTOs;
using System.Text.Json;

namespace PaymentsService.Services;

public class PaymentRepository : IPaymentRepository
{
    private readonly PaymentsDbContext _context;
    private readonly ILogger<PaymentRepository> _logger;

    public PaymentRepository(PaymentsDbContext context, ILogger<PaymentRepository> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<Models.PaymentRecord> CreatePaymentAsync(CreatePaymentRequest request)
    {
        try
        {
            var payment = new Models.PaymentRecord
            {
                PaymentId = Guid.NewGuid(),
                UserId = request.UserId,
                StoreId = request.StoreId,
                CartId = request.CartId,
                Currency = request.Currency,
                Amount = request.Amount,
                Status = "Success", // Mock payment always succeeds
                PaymentMethod = request.PaymentMethod,
                ItemsJson = JsonSerializer.Serialize(request.Items),
                CreatedAt = DateTime.UtcNow,
                ProcessedAt = DateTime.UtcNow
            };

            _context.Payments.Add(payment);
            await _context.SaveChangesAsync();

            _logger.LogInformation("Payment {PaymentId} created for user {UserId} with amount {Amount} {Currency}", 
                payment.PaymentId, payment.UserId, payment.Amount, payment.Currency);

            return payment;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error creating payment for user {UserId}", request.UserId);
            throw;
        }
    }

    public async Task<(List<Models.PaymentRecord> Items, int TotalCount)> GetPaymentsAsync(int page = 1, int pageSize = 10, string? status = null)
    {
        try
        {
            var query = _context.Payments.AsQueryable();

            if (!string.IsNullOrEmpty(status))
            {
                query = query.Where(p => p.Status == status);
            }

            var totalCount = await query.CountAsync();

            var items = await query
                .OrderByDescending(p => p.CreatedAt)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (items, totalCount);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving payments with page {Page}, pageSize {PageSize}, status {Status}", 
                page, pageSize, status);
            throw;
        }
    }

    public async Task<Models.PaymentRecord?> GetPaymentByIdAsync(Guid paymentId)
    {
        try
        {
            return await _context.Payments
                .FirstOrDefaultAsync(p => p.PaymentId == paymentId);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving payment {PaymentId}", paymentId);
            throw;
        }
    }
}