using System.Reflection;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;
using Serilog;
using StackExchange.Redis;
using Texnokaktus.ProgOlymp.OpenTelemetry;
using Texnokaktus.ProgOlymp.UserService.Converters;
using Texnokaktus.ProgOlymp.UserService.DataAccess;
using Texnokaktus.ProgOlymp.UserService.Endpoints;
using Texnokaktus.ProgOlymp.UserService.Infrastructure;
using Texnokaktus.ProgOlymp.UserService.Logic;
using Texnokaktus.ProgOlymp.UserService.Services;
using Texnokaktus.ProgOlymp.UserService.Services.Abstractions;

var builder = WebApplication.CreateBuilder(args);

builder.Services
       .AddDataAccess(optionsBuilder => optionsBuilder.UseSqlServer(builder.Configuration.GetConnectionString("DefaultDb")))
       .AddLogicServices()
       .AddScoped<IRegistrationService, RegistrationService>();

var connectionMultiplexer = await ConnectionMultiplexer.ConnectAsync(builder.Configuration.GetConnectionString("DefaultRedis")!);
builder.Services.AddSingleton<IConnectionMultiplexer>(connectionMultiplexer);
builder.Services.AddStackExchangeRedisCache(options => options.ConnectionMultiplexerFactory = () => Task.FromResult<IConnectionMultiplexer>(connectionMultiplexer));

builder.Services.AddMemoryCache();

builder.Services.AddSingleton(TimeProvider.System);

builder.Services.AddGrpcClients(builder.Configuration);

builder.Services.AddOpenApi(options => options.AddSchemaTransformer<SchemaTransformer>());

builder.Services.AddGrpc();
builder.Services.AddGrpcReflection();
builder.Services
       .AddGrpcHealthChecks()
       .AddDatabaseHealthChecks();

builder.Host.UseSerilog((context, configuration) => configuration.ReadFrom.Configuration(context.Configuration));

builder.Services.AddTexnokaktusOpenTelemetry(builder.Configuration, "UserService", null, null);

builder.Services
       .AddDataProtection(options => options.ApplicationDiscriminator = Assembly.GetEntryAssembly()?.GetName().Name)
       .PersistKeysToStackExchangeRedis(connectionMultiplexer);

var app = builder.Build();

app.UseOpenTelemetryPrometheusScrapingEndpoint();

app.MapGrpcHealthChecksService();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options => options.ConfigObject.Urls = [new() { Name = "v1", Url = "/openapi/v1.json" }]);
}

app.MapGroup("api")
   .MapRegistrationEndpoints()
   .MapRegionEndpoints();

/*
await using (var scope = app.Services.CreateAsyncScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    await context.Database.EnsureDeletedAsync();
    await context.Database.EnsureCreatedAsync();

    await using var f = File.OpenRead(@"D:\kav128\Downloads\regions.json");
    var jsonNode = JsonNode.Parse(f);
    
    context.Regions.AddRange(jsonNode.AsArray()
                                     .Select(x => new Region
                                      {
                                          Id = x["Id"].GetValue<int>(),
                                          Name = x["Name"].GetValue<string>(),
                                          Order = x["Id"].GetValue<int>() switch
                                          {
                                              78 => 10,
                                              47 => 9,
                                              77 => 5,
                                              _  => 0
                                          }
                                      }));
    await context.SaveChangesAsync();
}
*/

await app.RunAsync();
