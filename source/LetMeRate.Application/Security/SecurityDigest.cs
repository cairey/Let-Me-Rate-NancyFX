using System;
using System.Security.Cryptography;
using System.Text;

namespace LetMeRate.Application.Security
{
    public class SecurityDigest : ISecurityDigest
    {
        public string CreateSalt()
        {
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] buff = new byte[32];
            rng.GetBytes(buff);
            return Convert.ToBase64String(buff);
        }

        // one way encryption, hash
        public string EncryptPhase(string phase, string salt)
        {
            UnicodeEncoding uEncode = new UnicodeEncoding();
            byte[] bytD2e = uEncode.GetBytes(string.Concat(phase, salt));
            SHA256Managed sha = new SHA256Managed();
            byte[] hash = sha.ComputeHash(bytD2e);
            return Convert.ToBase64String(hash);
        }

        public bool Authenticated(string phase, string storedEncrypedPhase, string storedSalt)
        {
            string encryptedPhase = EncryptPhase(phase, storedSalt);
            return encryptedPhase == storedEncrypedPhase;
        }
    }
}