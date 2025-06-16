using Lab8_RodrigoLupo.DTOs;
using Lab8_RodrigoLupo.Models;
using Lab8_RodrigoLupo.Repositories;
using Lab8_RodrigoLupo.Repositories.Unit;
using Lab8_RodrigoLupo.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<PedidosDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register the repository and unit of work
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
// Register AutoMapper

builder.Services.AddAutoMapper(typeof(ProductProfile).Assembly);


// Register the services
builder.Services.AddScoped<GetClientesbyName>();
builder.Services.AddScoped<GetDetailProductinOrder>();
builder.Services.AddScoped<GetProductsGreatherThan>();
builder.Services.AddScoped<GetAverageOfProducts>();
builder.Services.AddScoped<GetNullDescriptionsInProducts>();
builder.Services.AddScoped<GetOrderInDate>();
builder.Services.AddScoped<GetProductExpensive>();
builder.Services.AddScoped<GetTotalProductsInOrden>();
builder.Services.AddScoped<GetClientThanOrders>();
builder.Services.AddScoped<GetOrdersAndDetailsWithProducts>();
builder.Services.AddScoped<GetProductsbyClient>();
builder.Services.AddScoped<GetClientsbyProduct>();

// Register the repository
builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.     
if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1");
    c.RoutePrefix = string.Empty;
});
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();