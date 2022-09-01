namespace RestCore.Contracts.Authenticators;

public interface IAuthenticator
{
    ValueTask<string> HandleAuthentication();
}
