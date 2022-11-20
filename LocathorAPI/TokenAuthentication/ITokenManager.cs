namespace DemoProjekatAPI.TokenAuthentication
{
    public interface ITokenManager
    {
        bool Authenticate(string username, byte[] password);
        Token GenerateToken();
        bool VerifyToken(string token);
    }
}