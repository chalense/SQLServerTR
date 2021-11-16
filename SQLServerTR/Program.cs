using Microsoft.EntityFrameworkCore;
using SQLServerTR.Data;
using SQLServerTR.Service;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// otra forma de configurar la conexión a la base de datos para .net core 6
//string connString = builder.Configuration.GetConnectionString("DefaultConnection");

// Add services to the container.
//configuración cadena de conexión en .net core 6
builder.Services.AddDbContext<DataContext>(options =>
   {
       options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
   });

builder.Services.AddScoped<iProductoService, ProductoService>();
builder.Services.AddScoped<iCategoriaService, CategoriaService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllersWithViews()
    .AddNewtonsoftJson(options =>
   {
       options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
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

app.Run();
