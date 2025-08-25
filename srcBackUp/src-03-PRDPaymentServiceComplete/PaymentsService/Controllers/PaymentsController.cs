using Microsoft.AspNetCore.Mvc;
using PaymentsService.Services;
using PaymentsService.DTOs;
using System.Text.Json;

namespace PaymentsService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PaymentsController : ControllerBase
{
    private readonly IPaymentRepository _paymentRepository;
    private readonly ILogger<PaymentsController> _logger;

    public PaymentsController(IPaymentRepository paymentRepository, ILogger<PaymentsController> logger)
    {
        _paymentRepository = paymentRepository;
        _logger = logger;
    }

    /// <summary>
    /// Create a new payment record
    /// </summary>
    /// <param name="request">Payment creation request</param>
    /// <returns>Payment creation response</returns>
    [HttpPost]
    public async Task<ActionResult<CreatePaymentResponse>> CreatePayment([FromBody] CreatePaymentRequest request)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Log payment request (excluding sensitive data)
            _logger.LogInformation("Processing payment request for user {UserId} with amount {Amount} {Currency} and payment method {PaymentMethod}", 
                request.UserId, request.Amount, request.Currency, request.PaymentMethod);

            var payment = await _paymentRepository.CreatePaymentAsync(request);

            var response = new CreatePaymentResponse
            {
                PaymentId = payment.PaymentId,
                Status = payment.Status,
                ProcessedAt = payment.ProcessedAt
            };

            return CreatedAtAction(nameof(GetPayment), new { id = payment.PaymentId }, response);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error processing payment for user {UserId}", request.UserId);
            return StatusCode(500, "An error occurred while processing the payment");
        }
    }

    /// <summary>
    /// Get payments with optional filtering and pagination
    /// </summary>
    /// <param name="page">Page number (default: 1)</param>
    /// <param name="pageSize">Page size (default: 10, max: 100)</param>
    /// <param name="status">Filter by payment status</param>
    /// <returns>Paginated payment list</returns>
    [HttpGet]
    public async Task<ActionResult<PaymentResponse>> GetPayments(
        [FromQuery] int page = 1, 
        [FromQuery] int pageSize = 10, 
        [FromQuery] string? status = null)
    {
        try
        {
            // Validate pagination parameters
            if (page < 1) page = 1;
            if (pageSize < 1) pageSize = 10;
            if (pageSize > 100) pageSize = 100;

            var (items, totalCount) = await _paymentRepository.GetPaymentsAsync(page, pageSize, status);

            var response = new PaymentResponse
            {
                Items = items.Select(p => new DTOs.PaymentRecord
                {
                    PaymentId = p.PaymentId,
                    UserId = p.UserId,
                    StoreId = p.StoreId,
                    CartId = p.CartId,
                    Currency = p.Currency,
                    Amount = p.Amount,
                    Status = p.Status,
                    PaymentMethod = p.PaymentMethod,
                    CreatedAt = p.CreatedAt,
                    ProcessedAt = p.ProcessedAt,
                    Items = string.IsNullOrEmpty(p.ItemsJson) ? null : JsonSerializer.Deserialize<List<PaymentItem>>(p.ItemsJson)
                }).ToList(),
                TotalCount = totalCount
            };

            return Ok(response);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving payments for page {Page}, pageSize {PageSize}, status {Status}", 
                page, pageSize, status);
            return StatusCode(500, "An error occurred while retrieving payments");
        }
    }

    /// <summary>
    /// Get a specific payment by ID
    /// </summary>
    /// <param name="id">Payment ID</param>
    /// <returns>Payment details</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<DTOs.PaymentRecord>> GetPayment(Guid id)
    {
        try
        {
            var payment = await _paymentRepository.GetPaymentByIdAsync(id);
            
            if (payment == null)
            {
                return NotFound($"Payment with ID {id} not found");
            }

            var response = new DTOs.PaymentRecord
            {
                PaymentId = payment.PaymentId,
                UserId = payment.UserId,
                StoreId = payment.StoreId,
                CartId = payment.CartId,
                Currency = payment.Currency,
                Amount = payment.Amount,
                Status = payment.Status,
                PaymentMethod = payment.PaymentMethod,
                CreatedAt = payment.CreatedAt,
                ProcessedAt = payment.ProcessedAt,
                Items = string.IsNullOrEmpty(payment.ItemsJson) ? null : JsonSerializer.Deserialize<List<PaymentItem>>(payment.ItemsJson)
            };

            return Ok(response);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving payment {PaymentId}", id);
            return StatusCode(500, "An error occurred while retrieving the payment");
        }
    }
}