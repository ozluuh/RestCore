using RestCore.Lib.Extensions;
using RestCore.Lib.Helpers;

namespace RestCore;

public class RestClient
{
    private readonly IHttpClientFactory _factory;
    public readonly Uri BaseAddress;

    public RestClient(string uri)
    {
        _factory = ServiceProviderHelper.GetService<IHttpClientFactory>()!;
        BaseAddress = new Uri(uri);
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
        var message = request.GetRequestMessage(BaseAddress);

        return client.SendAsync(message);
    }
}
