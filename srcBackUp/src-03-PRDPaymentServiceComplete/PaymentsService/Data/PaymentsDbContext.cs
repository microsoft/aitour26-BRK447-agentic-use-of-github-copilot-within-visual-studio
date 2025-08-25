using Microsoft.EntityFrameworkCore;

namespace PaymentsService.Data;

public class PaymentsDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Models.PaymentRecord> Payments => Set<Models.PaymentRecord>();
}