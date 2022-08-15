using RestCore.Lib.Enumerators;
using RestCore.Lib.Extensions;
using RestCore.Lib.Helpers;

namespace RestCore.Lib;

public class RestClient
{
    private readonly IHttpClientFactory _factory;
    public Uri? BaseAddress { get; set; }

    public RestClient(Uri? baseAddress = null)
    {
        _factory = ServiceProviderHelper.GetService<IHttpClientFactory>()!;
        BaseAddress = baseAddress;
    }

    private HttpClient ConfigureClient()
    {
        var client = _factory.CreateClient();
        client.BaseAddress = BaseAddress;
        client.DefaultRequestHeaders.Clear();

        return client;
    }

    public async Task SendAsync(RestRequest? request = null)
    {
        var client = ConfigureClient();
        var message = request.GetRequestMessage();

        var response = await client.SendAsync(message);
    }
}
