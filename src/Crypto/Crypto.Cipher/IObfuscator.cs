namespace Crypto.Cipher
{
    public interface IObfuscator
    {
        string Encode(string text);
        string Decode(string cipher);
    }
}