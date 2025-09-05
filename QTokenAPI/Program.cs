using Microsoft.EntityFrameworkCore;
using QTokenAPI.DBContext;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
builder.Services.AddDbContext<QTokenDBContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
    new MySqlServerVersion(new Version(8, 0, 34))));

app.MapGet("/", () => "Hello World!");

app.Run();
