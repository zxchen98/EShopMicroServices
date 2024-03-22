using Microsoft.EntityFrameworkCore;
using OrderAPI.ApplicationCore.Contracts.IRepository;
using OrderAPI.ApplicationCore.Contracts.IService;
using OrderAPI.Infrastructure.Data;
using OrderAPI.Infrastructure.Repository;
using OrderAPI.Infrastructure.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient();

builder.Services.AddDbContext<OrderDbContext>(options => {

    options.UseSqlServer(builder.Configuration.GetConnectionString("TrainingDB"));
    //options.UseSqlServer(Environment.GetEnvironmentVariable("eshopConnectString"));
});

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddScoped<IOrderRepositoryAsync, OrderRepositoryAsync>();
builder.Services.AddScoped<IShoppingCartRepositoryAsync, ShoppingCartRepositoryAsync>();
builder.Services.AddScoped<IShoppingCartItemRepositoryAsync, ShoppingCartItemRepositoryAsync>();


builder.Services.AddScoped<IOrderServiceAsync, OrderServiceAsync>();
builder.Services.AddScoped<IShoppingCartServiceAsync, ShoppingCartServiceAsync>();
builder.Services.AddScoped<IShoppingCartItemServiceAsync, ShoppingCartItemServiceAsync>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
