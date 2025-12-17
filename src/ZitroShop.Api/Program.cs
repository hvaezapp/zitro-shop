using Scalar.AspNetCore;
using ZitroShop.Modules.BasketModule.Registration;
using ZitroShop.Modules.ProductModule.Registration;
using ZitroShop.Shared.Registration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.RegisterInfraServices(builder.Configuration);
builder.Services.RegisterProductModuleServices(builder.Configuration);
builder.Services.RegisterBasketModuleServices();

builder.Services.AddOpenApi();

builder.Services.AddControllers();

builder.Services.AddRouting();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseRouting();
app.MapControllers();

app.Run();
