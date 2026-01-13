using Microsoft.EntityFrameworkCore;
using simple.Data;

var builder = WebApplication.CreateBuilder(args);

// =========================
// CONFIGURAR BASE DE DATOS
// =========================
builder.Services.AddDbContext<simpleContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("DefaultConnection")
    )
);

// =========================
// SERVICIOS
// =========================
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// =========================
// PUERTO
// =========================
builder.WebHost.UseUrls("http://localhost:8080");

var app = builder.Build();

// =========================
// APLICAR MIGRACIONES
// =========================
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<simpleContext>();
    db.Database.Migrate();
}

// =========================
// MIDDLEWARE
// =========================
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

// =========================
// RUTA RAÍZ
// =========================
app.MapGet("/", () => "API funcionando correctamente");

// =========================
// CONTROLADORES
// =========================
app.MapControllers();

app.Run();

