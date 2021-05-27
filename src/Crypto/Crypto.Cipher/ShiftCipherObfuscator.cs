using System.Text;

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
            return Shift(text, _shiftKey);
        }

        public string Decode(string cipher)
        {
            return Shift(cipher, 26 - _shiftKey);
        }
        private string Shift(string text, int shiftBy)
        {
            if (string.IsNullOrEmpty(text))
                return string.Empty;
            var shiftedTextBuilder = new StringBuilder();
            foreach (var character in text)
            {
                if (char.IsUpper(character))
                {
                    shiftedTextBuilder.Append(Shift(character, shiftBy, 'A'));
                }
                else if (char.IsLower(character))
                {
                    shiftedTextBuilder.Append(Shift(character, shiftBy, 'a'));
                }
            }
            return shiftedTextBuilder.ToString();
        }
        private char Shift(char alphabet, int shiftBy, char alphabetBaseLine)
        {
            return (char)((alphabet + shiftBy - alphabetBaseLine) % 26 + alphabetBaseLine);
        }
    }
}
