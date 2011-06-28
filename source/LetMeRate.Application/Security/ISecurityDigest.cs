namespace LetMeRate.Application.Security
{
    public interface ISecurityDigest
    {
        string CreateSalt();
        string EncryptPhase(string phase, string salt);
        bool Authenticated(string phase, string storedEncrypedPhase, string storedSalt);
    }
}