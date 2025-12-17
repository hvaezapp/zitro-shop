using Microsoft.EntityFrameworkCore;
using ZitroShop.Modules.ProductModule.Persistence.Context;
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


builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.Run();
