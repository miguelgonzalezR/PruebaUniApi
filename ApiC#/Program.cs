using ApiC_.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Agregar el servicio de DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Agregar el servicio de controladores
builder.Services.AddControllers();

// Configurar CORS para permitir solicitudes desde el cliente Angular
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularApp",
        builder => builder.WithOrigins("http://localhost:4200") // Reemplaza con la URL de tu aplicación Angular
                          .AllowAnyHeader()
                          .AllowAnyMethod());
});

// Agregar Swagger para documentar la API
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "API de Productos", Version = "v1" });
});

var app = builder.Build();

// Usar CORS
app.UseCors("AllowAngularApp");  // Asegúrate de que esto coincida con la política que creaste

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();   // Muestra detalles del error durante el desarrollo
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API de Productos v1");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
