using RestCore.Lib.Extensions;
using RestCore.Lib.Helpers;

namespace RestCore;

public class RestClient
{
    private readonly IHttpClientFactory _factory;

    public RestClient()
    {
        _factory = ServiceProviderHelper.GetService<IHttpClientFactory>()!;
    }

    private HttpClient CreateClient()
    {
        var client = _factory.CreateClient();
        client.DefaultRequestHeaders.Clear();

        return client;
    }

    public Task<HttpResponseMessage> SendAsync(RestRequest? request = null)
    {
        var client = CreateClient();
        var message = request.GetRequestMessage();

        return client.SendAsync(message);
    }
}
