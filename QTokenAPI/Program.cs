using Microsoft.EntityFrameworkCore;
using QTokenAPI.DBContext;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<QTokenDBContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
    new MySqlServerVersion(new Version(9, 0, 3))
    )
);

builder.Services.AddControllers(); // This is missing in your current code

var app = builder.Build();

app.MapGet("/", () => "API Server Running");

app.MapControllers();     // Registers your controller endpoints
app.UseRouting();         // Enables routing middleware
app.UseAuthorization();   // Optional, but good for future role-based access

app.Run();
