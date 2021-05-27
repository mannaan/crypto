using System;
using System.Text;

namespace Crypto.Cipher
{
    public class ShiftCipherObfuscator : IObfuscator
    {
        private readonly int _shiftKey;

        public ShiftCipherObfuscator(int shiftKey)
        {
            //convert to absolute key if a negative number provided
            _shiftKey = shiftKey >= 0 ? shiftKey : 26 - Math.Abs(shiftKey);
        }
        /// <summary>
        /// Encrypts the given text using Caesar/Shift cipher technique
        /// </summary>
        /// <param name="text"></param>
        /// <returns>Encrypted text</returns>
        public string Encrypt(string text)
        {
            return Shift(text, _shiftKey);
        }
        /// <summary>
        /// Decrypts the Caesar/Shift cipher
        /// </summary>
        /// <param name="cipher"></param>
        /// <returns>Decrypted text</returns>
        public string Decrypt(string cipher)
        {
            return Shift(cipher,26 - _shiftKey);
        }
        /// <summary>
        /// Shifts each character in text forward by "n"
        /// </summary>
        /// <param name="text"></param>
        /// <param name="shiftBy"></param>
        /// <returns>A new string containing shifted characters</returns>
        private string Shift(string text, int shiftBy)
        {
            if (string.IsNullOrEmpty(text))
                return string.Empty;
            if (shiftBy == 0)
                return text;
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
                else
                {
                    shiftedTextBuilder.Append(character);
                }
            }
            return shiftedTextBuilder.ToString();
        }
        /// <summary>
        /// Shifts an alphabet by "n"
        /// </summary>
        /// <param name="alphabet"></param>
        /// <param name="shiftBy"></param>
        /// <param name="alphabetBaseLine"></param>
        /// <returns></returns>
        private char Shift(char alphabet, int shiftBy, char alphabetBaseLine)
        {
            return (char)((alphabet + shiftBy - alphabetBaseLine) % 26 + alphabetBaseLine);
        }
    }
}
