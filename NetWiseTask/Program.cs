using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Net.Http.Json;

using IHost host = CreateHostBuilder().Build();
using var scope = host.Services.CreateScope();

var services = scope.ServiceProvider;

try
{
    await services.GetRequiredService<FactService>().Run();
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

static IHostBuilder CreateHostBuilder()
{
    return Host.CreateDefaultBuilder()
        .ConfigureServices((_, services) =>
        {
            services.AddSingleton<IFileManager, FileManager>();
            services.AddSingleton<FactService>();
        });
}

