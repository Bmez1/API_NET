using Microsoft.EntityFrameworkCore;
using UniversityAPI.Database;
using Microsoft.Extensions.DependencyInjection;
using UniversityAPI.Repositories.Interfaces;
using UniversityAPI.Repositories.Clases;
using UniversityAPI.Services.Interfaces;
using UniversityAPI.Services.Clases;
using UniversityAPI.Contracts;

var builder = WebApplication.CreateBuilder(args);

// Conexion a la base de datos
builder.Services.AddDbContext<UniversityDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Connection"))
);

// Inyectando el Unit of Work del Repositorio
builder.Services.AddScoped(typeof(IRepositoryWrapper), typeof(RepositoryWrapper));
// Inyectando el Unit of Work del Servicio
builder.Services.AddScoped(typeof(IServiceWrapper), typeof(ServiceWrapper));


// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Agregando el cors
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "Corspolicy", builder =>
    {
        builder.AllowAnyOrigin();
        builder.AllowAnyMethod();
        builder.AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// Levantar el cors
app.UseCors("Corspolicy");

app.Run();
