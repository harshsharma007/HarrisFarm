using DeserializeBuyersAppJson;
using DeserializeBuyersAppJson.ParseJson;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
        services.AddScoped<IParseBuyersAppStoreJson, ParseBuyersAppStoreJson>();
        services.AddScoped<JsonParser>();
    })
    .Build();

var app = host.Services.GetRequiredService<JsonParser>();
app.Run();