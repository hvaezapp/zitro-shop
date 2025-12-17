using Scalar.AspNetCore;
using ZitroShop.Modules.BasketModule.Registration;
using ZitroShop.Modules.ProductModule.Registration;
using ZitroShop.Shared.Registration;

var builder = WebApplication.CreateBuilder(args);




var configuration = builder.Configuration;

builder.Services.RegisterInfraServices(configuration);
builder.Services.RegisterProductModuleServices(configuration);
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
