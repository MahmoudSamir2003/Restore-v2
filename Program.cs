using API.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// -----------------------------------------------------------------------------
// Configure Services (Dependency Injection Container)
// -----------------------------------------------------------------------------

// Add controller services (API endpoints)
builder.Services.AddControllers();

// Add Swagger/OpenAPI for API documentation
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure Entity Framework with SQLite
builder.Services.AddDbContext<StoreContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Enable Cross-Origin Resource Sharing (CORS)
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", policy =>
    {
        policy.AllowAnyHeader()
              .AllowAnyMethod()
              .WithOrigins("https://localhost:3000"); // Frontend origin (React)
    });
});

var app = builder.Build();

// -----------------------------------------------------------------------------
// Configure HTTP Request Pipeline
// -----------------------------------------------------------------------------

// Use Swagger middleware in Development only
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Redirect HTTP to HTTPS
app.UseHttpsRedirection();

// Apply the configured CORS policy
app.UseCors("CorsPolicy");

// Authorization middleware (JWT or other policies)
app.UseAuthorization();

// Map controller routes to endpoints
app.MapControllers();

// -----------------------------------------------------------------------------
// Initialize and Seed the Database
// -----------------------------------------------------------------------------
DbInitializer.InitDb(app);

// -----------------------------------------------------------------------------
// Start the Application
// -----------------------------------------------------------------------------
app.Run();
