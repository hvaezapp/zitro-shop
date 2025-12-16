using Microsoft.EntityFrameworkCore;
using ZitroShop.Modules.ProductModule.Persistence.Context;

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


builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.Run();
