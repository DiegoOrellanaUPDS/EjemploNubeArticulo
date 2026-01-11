using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using simple.Data;

var url = Environment.GetEnvironmentVariable("DATABASE");
Console.WriteLine($"La cadena de coneccion es esta: {url}");

var builder = WebApplication.CreateBuilder(args);

// ✅ fallback a appsettings.json si DATABASE viene vacío
if (string.IsNullOrWhiteSpace(url))
{
    url = builder.Configuration.GetConnectionString("simpleContext");
    Console.WriteLine($"DATABASE estaba vacío, usando appsettings: {url}");
}

// ✅ Configurar DbContext con PostgreSQL
builder.Services.AddDbContext<simpleContext>(options =>
    options.UseNpgsql(url));

// Add services to the container.
builder.WebHost.UseUrls("http://0.0.0.0:8080");

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Aplicar migraciones automáticamente al iniciar
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<simpleContext>();
    db.Database.Migrate();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
