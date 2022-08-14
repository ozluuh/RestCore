using RestCore.Lib.Enumerators;

namespace RestCore.Lib.Services;

public class RestRequest
{
    /// <summary>
    /// Define all client parameters (query, headers)
    /// </summary>
    private readonly IEnumerable<(ParameterType _id, string key, IEnumerable<string> values)> Parameters;

    /// <summary>
    /// Instantiate RestRequest object
    /// </summary>
    public RestRequest()
    {
        Parameters = new List<(ParameterType, string, IEnumerable<string>)>();
    }

    /// <summary>
    /// Add parameter to requisition
    /// </summary>
    /// <param name="key">Parameter key</param>
    /// <param name="values">Values related to key</param>
    /// <param name="parameterType">Which parameter type must adopt in requisition</param>
    public void AddParameter(string key, IEnumerable<string> values, ParameterType parameterType)
    {
        Parameters.Append((parameterType, key, values));
    }

    /// <summary>
    /// Add parameter to requisition
    /// </summary>
    /// <param name="key">Parameter key</param>
    /// <param name="value">Value related to key</param>
    /// <param name="parameterType">Which parameter type must adopt in requisition</param>
    public void AddParameter(string key, string value, ParameterType parameterType)
    => AddParameter(key, new[] { value }, parameterType);
}
