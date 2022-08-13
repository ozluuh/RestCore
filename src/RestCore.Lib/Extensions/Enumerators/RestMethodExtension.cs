using RestCore.Lib.Enumerators;

namespace RestCore.Lib.Extensions.Enumerators;

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
