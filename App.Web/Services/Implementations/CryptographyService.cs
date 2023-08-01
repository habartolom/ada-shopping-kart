using App.Web.Services.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace App.Web.Services.Implementations
{
    public class CryptographyService : ICryptographyService
    {
        public bool AreHashesEqual(byte[] firstHash, byte[] secondHash)
        {
            int minHashLength = firstHash.Length <= secondHash.Length ? firstHash.Length : secondHash.Length;
            var xor = firstHash.Length ^ secondHash.Length;
            for (int i = 0; i < minHashLength; i++)
                xor |= firstHash[i] ^ secondHash[i];
            return xor == 0;
        }

        public byte[] GenerateHash(string textToEncrypt, byte[] salt)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] textToEncryptBytes = Encoding.UTF8.GetBytes(textToEncrypt);
                byte[] textToEncryptWithSaltBytes = new byte[textToEncryptBytes.Length + salt.Length];

                for (int i = 0; i < textToEncryptBytes.Length; i++)
                    textToEncryptWithSaltBytes[i] = textToEncryptBytes[i];

                for (int i = 0; i < salt.Length; i++)
                    textToEncryptWithSaltBytes[textToEncryptBytes.Length + i] = salt[i];

                return sha256.ComputeHash(textToEncryptWithSaltBytes);
            }
        }

        public byte[] GenerateSalt()
        {
            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            return salt;
        }
    }
}
