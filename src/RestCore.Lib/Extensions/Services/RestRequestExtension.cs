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
        var parameters = request.Parameters.Where(item => item._id.Equals(ParameterType.Query)).ToList();

        if (!parameters.Any())
            return request.RequestUri;

        var query = parameters
            .Select(p => string.Format("{0}={1}", p.key, p.values.Union(',')))
            .Union("&");

        return new Uri(request.RequestUri.AbsoluteUri.Union("?", query));
    }
}
