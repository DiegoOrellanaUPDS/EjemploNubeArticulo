using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using simple.Data;
var url = Environment.GetEnvironmentVariable("DATABASE");
Console.WriteLine($"La cadena de coneccion es esta: {url}");

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<simpleContext>(options =>
    options.UseNpgsql(url));

// Add services to the container.
builder.WebHost.UseUrls("http://0.0.0.0:8080");

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using(var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<simpleContext>();
    db.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
