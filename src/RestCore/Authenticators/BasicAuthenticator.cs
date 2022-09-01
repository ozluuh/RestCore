using System.Text;
using RestCore.Contracts.Authenticators;

namespace RestCore.Authenticators;

public class BasicAuthenticator : IAuthenticator
{
    readonly string _user;
    readonly string _pass;

    public BasicAuthenticator(string user, string pass)
    {
        _user = user;
        _pass = pass;
    }

    public ValueTask<string> HandleAuthentication()
    {
        var dataBytes = Encoding.UTF8.GetBytes(string.Format("{0}:{1}", _user, _pass));
        var encodedData = Convert.ToBase64String(dataBytes);

        return new ValueTask<string>(string.Format("Basic {0}", encodedData));
    }
}
