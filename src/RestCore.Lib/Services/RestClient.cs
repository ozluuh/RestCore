using RestCore.Lib.Extensions;
using RestCore.Lib.Helpers;

namespace RestCore.Lib;

public class RestClient
{
    private readonly IHttpClientFactory _factory;

    public RestClient()
    {
        _factory = ServiceProviderHelper.GetService<IHttpClientFactory>()!;
    }

    private HttpClient ConfigureClient()
    {
        var client = _factory.CreateClient();
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
