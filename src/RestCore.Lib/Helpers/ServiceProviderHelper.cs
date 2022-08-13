using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace RestCore.Lib.Helpers;

public static class ServiceProviderHelper
{
    private static IServiceProvider? sp { get; set; }

    public static void Initial(IServiceProvider? Provider)
    {
        if (Provider != null)
        {
            sp = Provider;
            return;
        }

        IHostBuilder builder = Host.CreateDefaultBuilder();
        builder.ConfigureServices(services =>
        {
            services.AddLogging();
            services.AddHttpClient();
        });
        sp = builder.Build().Services;
    }

    public static object? GetService(Type service)
    {
        if (sp == null)
            Initial(sp);

        return sp!.GetService(service);
    }

    public static TResponse? GetService<TResponse>()
    => (TResponse?)GetService(typeof(TResponse));
}
