using Microsoft.EntityFrameworkCore;
using ZitroShop.Modules.BasketModule.Registration;
using ZitroShop.Modules.ProductModule.Persistence.Context;
using ZitroShop.Modules.ProductModule.Registration;
using ZitroShop.Shared.Infrastructure.Redis;

var builder = WebApplication.CreateBuilder(args);


// ProductModuleDbContext
builder.Services.AddDbContext<ProductModuleDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("SvcDbContext"),
        sqlOptions =>
        {
            sqlOptions.MigrationsAssembly("ZitroShop.Modules");
            sqlOptions.MigrationsHistoryTable("__EFMigrationsHistory", ProductModuleDbContextSchema.DefaultSchema);
        }));


// Redis
builder.Services.AddSingleton<IRedisConnectionFactory>(sp =>
{
    var connectionString = builder.Configuration.GetConnectionString("Redis:ConnectionString") ?? "localhost:6379";
    return new RedisConnectionFactory(connectionString);
});


builder.Services.RegisterProductModuleServices();
builder.Services.RegisterBasketModuleServices();

builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.Run();
