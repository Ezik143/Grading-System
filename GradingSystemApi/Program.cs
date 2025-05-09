using Team_Yeri_enrollment_system.GradingLibrary.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();


// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Grading System API",
        Version = "v1"
    });
});


builder.Services.AddDbContext<enrollmentDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("GradingSystemApiConnectionString")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Grading System API V1");
        c.RoutePrefix = string.Empty; // Set Swagger UI at the app's root
    });
}


app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();


app.Run();
