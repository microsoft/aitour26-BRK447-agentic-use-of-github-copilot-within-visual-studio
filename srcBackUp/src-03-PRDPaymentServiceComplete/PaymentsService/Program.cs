using Microsoft.EntityFrameworkCore;
using PaymentsService.Components;
using PaymentsService.Data;
using PaymentsService.Services;

var builder = WebApplication.CreateBuilder(args);

// Add Aspire service defaults - provides service discovery, telemetry, health checks
builder.AddServiceDefaults();

// Use Aspire helper to configure SQL Server DbContext like Products project
builder.AddSqlServerDbContext<PaymentsDbContext>("paymentsDb");

// Add repository for payment data access
builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();

// Add controllers for API endpoints
builder.Services.AddControllers();

// Add Swagger/OpenAPI support for development
if (builder.Environment.IsDevelopment())
{
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
}

// Add Blazor services for UI
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Map Aspire default endpoints (health checks, etc.)
app.MapDefaultEndpoints();

// Ensure database is created and ready. For production, prefer migrations (context.Database.Migrate()).
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<PaymentsDbContext>();
    try
    {
        app.Logger.LogInformation("Ensure Payments database created");
        context.Database.EnsureCreated();
    }
    catch (Exception exc)
    {
        app.Logger.LogError(exc, "Error creating Payments database");
    }
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{
    // Enable Swagger in development
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

// Map API controllers
app.MapControllers();

// Map Blazor components
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
