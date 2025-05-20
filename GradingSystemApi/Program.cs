// Import the namespace that contains the database context class (GradingDbContext)
using Team_Yeri_enrollment_system.GradingLibrary.Data;

// Import Entity Framework Core – used for interacting with the database
using Microsoft.EntityFrameworkCore;

// Import OpenAPI tools – used for auto-generating API documentation (Swagger)
using Microsoft.OpenApi.Models;

// Create a WebApplicationBuilder, which sets up the app and its services
var builder = WebApplication.CreateBuilder(args);

// --------------------------------------------------
// Add services to the container (dependency injection)
// --------------------------------------------------

// Add controller support – this allows the app to respond to HTTP requests using controller classes
builder.Services.AddControllers();

// Add Swagger/OpenAPI generation support for documenting the API
builder.Services.AddSwaggerGen(c =>
{
    // Define an OpenAPI document with version and title
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Grading System API", // Title of the API shown in Swagger UI
        Version = "v1"                 // API version
    });
});

// Register the database context (GradingDbContext) with the dependency injection system
// Use SQL Server as the database provider, and get the connection string from app settings
builder.Services.AddDbContext<GradingDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("GradingSystemApiConnectionString")));

// Build the app from the builder – this prepares the application to be run
var app = builder.Build();

// --------------------------------------------------
// Configure the HTTP request pipeline (middleware)
// --------------------------------------------------

// If the app is running in the development environment...
if (app.Environment.IsDevelopment())
{
    // Enable middleware to generate the Swagger JSON document
    app.UseSwagger();

    // Enable middleware to serve the Swagger UI at the app's root ("/")
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Grading System API V1"); // Link to Swagger JSON
        c.RoutePrefix = string.Empty; // Show Swagger UI at root URL (e.g., http://localhost:5000/)
    });
}

// Enable automatic redirection from HTTP to HTTPS
app.UseHttpsRedirection();

// Enable authorization middleware – checks user permissions for protected endpoints
app.UseAuthorization();

// Map controller endpoints – this tells ASP.NET to use controller classes to handle requests
app.MapControllers();

// Run the app – start listening for HTTP requests
app.Run();
