namespace Crypto.Cipher
{
    public interface IObfuscator
    {
        string Encrypt(string text);
        string Decrypt(string cipher);
    }
}