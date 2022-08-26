using RestCore.Enumerators;

namespace RestCore.Extensions;

public static class RestMethodExtension
{
    public static HttpMethod GetHttpMethod(this RestMethod value)
    => value switch
    {
        RestMethod.Post => HttpMethod.Post,
        RestMethod.Put => HttpMethod.Put,
        RestMethod.Delete => HttpMethod.Delete,
        RestMethod.Patch => HttpMethod.Patch,
        _ => HttpMethod.Get
    };
}
