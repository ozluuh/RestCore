using RestCore.Enumerators;

namespace RestCore.Extensions;

internal static class RestRequestExtension
{
    internal static HttpRequestMessage GetRequestMessage(this RestRequest? request, Uri baseAddress)
    {
        var message = new HttpRequestMessage();

        if (request != null)
        {
            message.Content = request.Body?.GetHttpContent();
            message.Method = request.Method.GetHttpMethod();
            message.RequestUri = request.GetRequestUri(baseAddress);

            foreach (var header in request.Parameters.Where(item => item._id.Equals(ParameterType.RequestHeader)))
                message.Headers.TryAddWithoutValidation(header.key, header.values);

            foreach (var header in request.Parameters.Where(item => item._id.Equals(ParameterType.ContentHeader)))
                message.Content?.Headers.TryAddWithoutValidation(header.key, header.values);
        }

        return message;
    }

    internal static Uri GetRequestUri(this RestRequest request, Uri baseAddress)
    {
        var parameters = request.Parameters.Where(item => item._id.Equals(ParameterType.Query)).ToList();
        var uriString = string.Join("", baseAddress.AbsoluteUri, request.ResourceUri);

        if (parameters.Any())
        {
            var query = parameters
                .Select(p => string.Format("{0}={1}", p.key, p.values.Union(',')))
                .Union("&");

            uriString = uriString.Union("?", query);
        }

        return new Uri(uriString);
    }
}
