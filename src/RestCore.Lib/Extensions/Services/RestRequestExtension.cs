using RestCore.Lib;

namespace RestCore.Lib.Extensions;

public static class RestRequestExtension
{
    public static HttpRequestMessage GetRequestMessage(this RestRequest @this)
    {
        var response = new HttpRequestMessage();

        return response;
    }
}
