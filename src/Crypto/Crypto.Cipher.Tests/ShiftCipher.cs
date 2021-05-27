using NUnit.Framework;

namespace Crypto.Cipher.Tests
{
    public class ShiftCipher
    {
        [Test]
        public void Encode_EmptyString_ReturnsEmpty()
        {
            var obfuscator = new ShiftCipherObfuscator(3);
            Assert.IsEmpty(obfuscator.Encode(string.Empty));
        }
        [Test]
        public void Decode_EmptyString_ReturnsEmpty()
        {
            var obfuscator = new ShiftCipherObfuscator(3);
            Assert.IsEmpty(obfuscator.Decode(string.Empty));
        }
       

        [TestCase("HELLO", "KHOOR")]
        [TestCase("HeLLo", "KhOOr")]
        [TestCase("hello", "khoor")]
        [TestCase("ABC", "DEF")]
        public void Encode_PlainText_ReturnsShiftCipher(string input, string output)
        {
            var obfuscator = new ShiftCipherObfuscator(3);
            Assert.AreEqual(output, obfuscator.Encode(input));
        }
        [TestCase("KHOOR", "HELLO")]
        [TestCase("khoor", "hello")]
        [TestCase("KhOOr", "HeLLo")]
        [TestCase("DEF", "ABC")]
        public void Decode_ShiftCipher_ReturnsPlainText(string input, string output)
        {
            var obfuscator = new ShiftCipherObfuscator(3);
            Assert.AreEqual(output, obfuscator.Decode(input));
        }
        [TestCase("XYZ", "ABC")]
        [TestCase("ZAY", "CDB")]
        public void Encode_EdgeCharacters_IsAbleToLoopForward(string input, string output)
        {
            var obfuscator = new ShiftCipherObfuscator(3);
            Assert.AreEqual(output, obfuscator.Encode(input));
        }
        [TestCase("ABC", "XYZ")]
        [TestCase("CDB", "ZAY")]
        public void Decode_EdgeCharacters_IsAbleToLoopBackwards(string input, string output)
        {
            var obfuscator = new ShiftCipherObfuscator(3);
            Assert.AreEqual(output, obfuscator.Decode(input));
        }
        [TestCase("XYZ")]
        [TestCase("ABDCDEF")]
        [TestCase("HOMeOffice")]
        [TestCase("LMNoAxz")]
        public void EncodeAndDecode_AnyValue_ReturnsSameValueAsInput(string input)
        {
            var obfuscator = new ShiftCipherObfuscator(3);
            var encodedString = obfuscator.Encode(input);
            var decodedString = obfuscator.Decode(encodedString);
            Assert.AreEqual(input, decodedString);
        }
    }
}