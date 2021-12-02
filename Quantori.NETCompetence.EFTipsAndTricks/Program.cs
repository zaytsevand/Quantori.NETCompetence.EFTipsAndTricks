using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using Quantori.NETCompetence.EFTipsAndTricks;
using AppContext = Quantori.NETCompetence.EFTipsAndTricks.AppContext;

using var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
        services.AddDbContext<AppContext>(builder => builder
            .UseSqlServer(context.Configuration.GetConnectionString("Default")));
        services.AddLogging(builder => builder
            .AddConsole()
            .SetMinimumLevel(LogLevel.Warning)
            .AddFilter<ConsoleLoggerProvider>("Quantori", LogLevel.Information));
        services.AddTransient<Example1>();
    })
    .UseConsoleLifetime()
    .Build();

var example = host.Services.GetRequiredService<Example1>();

if(ShouldCreateUsers())
{
    await example.CreateUsersAsync();
}

if(ShouldReadUsers())
{
    await example.ReadUsersAsync();
}

host.Run();

bool ShouldCreateUsers()
{
    return args.Contains("--create-users");
}

bool ShouldReadUsers()
{
    return args.Contains("--read-users");
}