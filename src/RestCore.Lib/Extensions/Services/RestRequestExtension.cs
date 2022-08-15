using RestCore.Lib.Enumerators;

namespace RestCore.Lib.Extensions;

public static class RestRequestExtension
{
    public static HttpRequestMessage GetRequestMessage(this RestRequest? request)
    {
        var message = new HttpRequestMessage();

        if (request != null)
        {
            message.Content = request.Body?.GetHttpContent();
            message.Method = request.Method.GetHttpMethod();
            message.RequestUri = GetRequestUri(request);

            foreach (var header in request.Parameters.Where(item => item._id.Equals(ParameterType.RequestHeader)))
                message.Headers.Add(header.key, header.values);

            foreach (var header in request.Parameters.Where(item => item._id.Equals(ParameterType.ContentHeader)))
                message.Content?.Headers.Add(header.key, header.values);
        }

        return message;
    }

    private static Uri? GetRequestUri(RestRequest request)
    {
        if (!request.Parameters.Any(item => item._id.Equals(ParameterType.Query)))
            return request.RequestUri;

        var query = request.Parameters
            .Where(item => item._id.Equals(ParameterType.Query))
            .Select(p => string.Format("{0}={1}", p.key, string.Join(',', p.values)));

        var queryNormalized = string.Join('&', query);
        var requestUri = request.RequestUri?.OriginalString;

        return new Uri(string.Join('?', requestUri, queryNormalized));
    }
}
