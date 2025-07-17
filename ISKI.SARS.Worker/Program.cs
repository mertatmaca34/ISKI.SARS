using ISKI.SARS.Worker;
using ISKI.SARS.Application;
using ISKI.SARS.Infrastructure;
using ISKI.OpcUa.Client;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddIskiOpcUaClient();
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration.GetConnectionString("DefaultConnection")!);
builder.Services.AddHostedService<Worker>();

var host = builder.Build();
host.Run();
