namespace App.Web.Services.Interfaces
{
    public interface ICryptographyService
    {
        bool AreHashesEqual(byte[] firstHash, byte[] secondHash);
        byte[] GenerateHash(string textToEncrypt, byte[] salt);
        byte[] GenerateSalt();
    }
}
