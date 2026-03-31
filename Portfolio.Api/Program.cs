using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.RateLimiting;
using Npgsql;
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

var dbConnectionString = ResolveDbConnectionString(builder.Configuration);

//
// 1. Register services (DI container)
//

// Enables controller-based APIs
builder.Services.AddControllers();

// Enables Swagger / OpenAPI for API testing
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Temporary open CORS policy for frontend integration
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader());
});

// Register EF Core DbContext with PostgreSQL
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(dbConnectionString));

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

// CORS
app.UseCors("AllowAll");

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

static string ResolveDbConnectionString(IConfiguration configuration)
{
    var raw = configuration.GetConnectionString("DefaultConnection");
    if (string.IsNullOrWhiteSpace(raw))
    {
        raw = configuration["DATABASE_URL"];
    }

    if (string.IsNullOrWhiteSpace(raw))
    {
        throw new InvalidOperationException(
            "Database connection string is missing. Set ConnectionStrings:DefaultConnection or DATABASE_URL.");
    }

    if (raw.StartsWith("postgres://", StringComparison.OrdinalIgnoreCase) ||
        raw.StartsWith("postgresql://", StringComparison.OrdinalIgnoreCase))
    {
        return ConvertPostgresUrlToNpgsql(raw);
    }

    return raw;
}

static string ConvertPostgresUrlToNpgsql(string url)
{
    var uri = new Uri(url);
    var dbName = uri.AbsolutePath.Trim('/');
    var userParts = uri.UserInfo.Split(':', 2, StringSplitOptions.None);

    var csb = new NpgsqlConnectionStringBuilder
    {
        Host = uri.Host,
        Port = uri.IsDefaultPort ? 5432 : uri.Port,
        Database = string.IsNullOrWhiteSpace(dbName) ? "postgres" : Uri.UnescapeDataString(dbName),
        Username = userParts.Length > 0 ? Uri.UnescapeDataString(userParts[0]) : string.Empty,
        Password = userParts.Length > 1 ? Uri.UnescapeDataString(userParts[1]) : string.Empty
    };

    var query = uri.Query.TrimStart('?');
    if (!string.IsNullOrWhiteSpace(query))
    {
        foreach (var segment in query.Split('&', StringSplitOptions.RemoveEmptyEntries))
        {
            var pair = segment.Split('=', 2, StringSplitOptions.None);
            var key = Uri.UnescapeDataString(pair[0]);
            var value = pair.Length > 1 ? Uri.UnescapeDataString(pair[1]) : string.Empty;

            try
            {
                csb[key] = value;
            }
            catch (ArgumentException)
            {
                // Ignore unknown query options.
            }
        }
    }

    return csb.ConnectionString;
}
