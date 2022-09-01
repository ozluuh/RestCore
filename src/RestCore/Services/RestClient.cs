using Microsoft.Net.Http.Headers;
using RestCore.Contracts.Authenticators;
using RestCore.Extensions;
using RestCore.Helpers;

namespace RestCore;

public class RestClient
{
    private readonly IHttpClientFactory _factory;
    public readonly Uri BaseAddress;
    public IAuthenticator? Authenticator { get; set; }

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

        if (Authenticator != null)
        {
            var authentication = Authenticator.HandleAuthentication();

            if (authentication.IsCompleted)
                message.Headers.TryAddWithoutValidation(HeaderNames.Authorization, authentication.Result);
        }

        return client.SendAsync(message);
    }
}
