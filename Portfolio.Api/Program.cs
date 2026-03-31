using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.RateLimiting;
using Portfolio.Api.Data;
using Portfolio.Api.Interfaces;
using Portfolio.Api.Repositories;
using Portfolio.Api.Services;

var builder = WebApplication.CreateBuilder(args);

// Optional local-only overrides (ignored by git)
builder.Configuration.AddJsonFile("appsettings.Local.json", optional: true, reloadOnChange: true);

// Local development secrets from dotnet user-secrets
if (builder.Environment.IsDevelopment())
{
    builder.Configuration.AddUserSecrets<Program>(optional: true);
}

//
// 1. Register services (DI container)
//

// Enables controller-based APIs
builder.Services.AddControllers();

// Enables Swagger / OpenAPI for API testing
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register EF Core DbContext with PostgreSQL
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("DefaultConnection")));

// Register custom services and repositories
builder.Services.AddScoped<IPortfolioRepository, PortfolioRepository>();
builder.Services.AddScoped<ISectionRepository, SectionRepository>();
builder.Services.AddScoped<IPortfolioService, PortfolioService>();
builder.Services.AddScoped<ISectionService, SectionService>();

// In-memory caching
builder.Services.AddMemoryCache();

// Rate limiting
builder.Services.AddRateLimiter(options =>
{
    options.AddFixedWindowLimiter("fixed", limiter =>
    {
        limiter.PermitLimit = 10;                 // 10 requests
        limiter.Window = TimeSpan.FromMinutes(1); // per minute
        limiter.QueueLimit = 2;                   // extra 2 queued
    });
});

var app = builder.Build();

//
// 2. Middleware pipeline
//

// Swagger UI
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Force HTTPS outside local development.
// In Development, many setups run only the http profile, which has no https port.
if (!app.Environment.IsDevelopment())
{
    app.UseHttpsRedirection();
}

// Apply rate limiting
app.UseRateLimiter();

// Friendly root endpoint for browser hits.
if (app.Environment.IsDevelopment())
{
    app.MapGet("/", () => Results.Redirect("/swagger")).ExcludeFromDescription();
}
else
{
    app.MapGet("/", () => Results.Ok("Portfolio API is running.")).ExcludeFromDescription();
}

// Map controller routes
app.MapControllers();

app.Run();
