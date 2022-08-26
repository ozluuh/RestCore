using System.Text;
using RestCore.Enumerators;
using RestCore.Models;

namespace RestCore;

public class RestRequest
{
    /// <summary>
    /// Define all client parameters (query, headers)
    /// </summary>
    public List<(ParameterType _id, string key, IEnumerable<string> values)> Parameters { get; private set; }
    public RequestBody? Body { get; private set; }
    public readonly string ResourceUri;
    public RestMethod Method { get; set; }

    /// <summary>
    /// Initializes a new instance of the RestCore.RestRequest class.
    /// </summary>
    /// <param name="resourceUri">Requested resource.</param>
    /// <param name="httpMethod">Http method.</param>
    public RestRequest(string resourceUri, RestMethod? httpMethod = null)
    {
        Parameters = new List<(ParameterType, string, IEnumerable<string>)>();
        ResourceUri = resourceUri;
        Method = httpMethod ?? RestMethod.Get;
    }

    /// <summary>
    /// Add parameter to requisition
    /// </summary>
    /// <param name="key">Parameter key</param>
    /// <param name="values">Values related to key</param>
    /// <param name="parameterType">Which parameter type must adopt in requisition</param>
    public void AddParameter(string key, IEnumerable<string> values, ParameterType parameterType)
    {
        Parameters.Add((parameterType, key, values));
    }

    /// <summary>
    /// Add parameter to requisition
    /// </summary>
    /// <param name="key">Parameter key</param>
    /// <param name="value">Value related to key</param>
    /// <param name="parameterType">Which parameter type must adopt in requisition</param>
    public void AddParameter(string key, string value, ParameterType parameterType)
    => AddParameter(key, new[] { value }, parameterType);

    /// <summary>
    /// Add request body.
    /// </summary>
    /// <param name="content">Content body.</param>
    /// <param name="encode">Encoding to adopt. Default to UTF8.</param>
    /// <param name="mediaType">Content type. Default to application/json.</param>
    public void AddRequestBody(string content, Encoding? encode = null, string? mediaType = null)
    {
        Body = new RequestBody(content, encode, mediaType);
    }
}
