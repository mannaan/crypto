using System;

namespace Crypto.Cipher
{
    public class ShiftCipherObfuscator : IObfuscator
    {
        private readonly int _shiftKey;

        public ShiftCipherObfuscator(int shiftKey)
        {
            _shiftKey = shiftKey;
        }
        public string Encode(string text)
        {
            throw new NotImplementedException();
        }

        public string Decode(string cipher)
        {
            throw new NotImplementedException();
        }
    }
}
