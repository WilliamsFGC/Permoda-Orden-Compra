using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using OrdenCompra.Api.Filter;
using OrdenCompra.Application.Comandos;
using OrdenCompra.Application.Consultas.Producto;
using OrdenCompra.Application.Dto;
using OrdenCompra.Application.Interfaces;
using OrdenCompra.Domain.Interfaces;
using OrdenCompra.Infrastructure.Mensajeria;
using OrdenCompra.Infrastructure.Persistencia;
using OrdenCompra.Infrastructure.Repositorios;
using OrdenCompra.Infrastructure.Services;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<OrdenCompraDbContext>(o => o.UseSqlite("Data source=ordencompra.db"));

// Inyectar repositorio
builder.Services.AddScoped<OrdenCompra.Application.Interfaces.IOrdenRepository, OrdenRepository>();
builder.Services.AddScoped<OrdenCompra.Domain.Interfaces.IOrdenRepository, OrdenRepository>();
builder.Services.AddScoped<OrdenCompra.Application.Interfaces.IProductoRepository, ProductoRepository>();
builder.Services.AddScoped<OrdenCompra.Domain.Interfaces.IProductoRepository, ProductoRepository>();
builder.Services.AddScoped<IOrdenItemRepository, OrdenItemRepository>();

// Servicios
builder.Services.AddHttpClient<IInventarioService, InventarioService>(
    client =>
    {
        client.BaseAddress = new Uri("https://localhost:7074");
    });

// Registrar eventos
builder.Services.AddSingleton<IEventBus, OrdenConfirmadaEventBus>();

// Registrar MediatR
builder.Services.AddMediatR(c => c.RegisterServicesFromAssemblyContaining<CrearOrdenCommand>());
builder.Services.AddMediatR(c => c.RegisterServicesFromAssemblyContaining<ConfirmarOrdenCommand>());
builder.Services.AddMediatR(c => c.RegisterServicesFromAssemblyContaining<AgregarItemCommand>());
builder.Services.AddMediatR(c => c.RegisterServicesFromAssemblyContaining<EliminarItemCommand>());
builder.Services.AddMediatR(c => c.RegisterServicesFromAssemblyContaining<EliminarOrdenCompraCommand>());
builder.Services.AddMediatR(c => c.RegisterServicesFromAssemblyContaining<ModificarCantidadCommand>());
builder.Services.AddMediatR(c => c.RegisterServicesFromAssemblyContaining<ObtenerProductosQuery>());

// Jwt
// Podemos configurar la llave en una variable de entorno para no dejar la llave del JWT expuesta en archivos
JwtDto jwt = builder.Configuration.GetSection("Jwt").Get<JwtDto>() ?? new JwtDto();
builder.Services.AddOptions<JwtDto>().BindConfiguration("Jwt");
builder.Services.AddAuthentication(o =>
{
    o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(j =>
{
    j.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer= true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwt.Issuer,
        ValidAudience = jwt.Audience,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.JwtKey))
    };
});

builder.Services.AddControllers();

// Middleware
builder.Services.AddControllers(c => c.Filters.Add<ApiFilterException>());

// CORS
builder.Services.AddCors(c => c.AddPolicy("CorsFront", p => p.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod()));

// Swagger
builder.Services.AddAuthentication();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseStaticFiles();
app.UseSwagger();
app.UseSwaggerUI(s =>
{
    s.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");
    s.RoutePrefix = string.Empty;
});

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

// Usar CORS
app.UseCors("CorsFront");

app.Run();
