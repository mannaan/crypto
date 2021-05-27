using NUnit.Framework;

namespace Crypto.Cipher.Tests
{
    public class ShiftCipher
    {
        [Test]
        public void Encrypt_EmptyString_ReturnsEmpty()
        {
            var obfuscator = new ShiftCipherObfuscator(3);
            Assert.IsEmpty(obfuscator.Encrypt(string.Empty));
        }
        [Test]
        public void Decrypt_EmptyString_ReturnsEmpty()
        {
            var obfuscator = new ShiftCipherObfuscator(3);
            Assert.IsEmpty(obfuscator.Decrypt(string.Empty));
        }
        [TestCase("Abd9man", "Deg9pdq")]
        [TestCase("09", "09")]
        [TestCase("_Name", "_Qdph")]
        [TestCase("Abd man", "Deg pdq")]
        public void Encrypt_NonTextualInput_NonAlphabetsReturnedAsItIs(string input, string output)
        {
            var obfuscator = new ShiftCipherObfuscator(3);
            Assert.AreEqual(output, obfuscator.Encrypt(input));
        }
        [TestCase("Deg9pdq", "Abd9man")]
        [TestCase("09", "09")]
        [TestCase("_Qdph", "_Name")]
        [TestCase("Deg pdq", "Abd man")]
        public void Decrypt_NonTextualInput_NonAlphabetsReturnedAsItIs(string input, string output)
        {
            var obfuscator = new ShiftCipherObfuscator(3);
            Assert.AreEqual(output, obfuscator.Decrypt(input));
        }

        [TestCase("HELLO", "KHOOR")]
        [TestCase("HeLLo", "KhOOr")]
        [TestCase("hello", "khoor")]
        [TestCase("ABC", "DEF")]
        public void Encrypt_PlainText_ReturnsShiftCipher(string input, string output)
        {
            var obfuscator = new ShiftCipherObfuscator(3);
            Assert.AreEqual(output, obfuscator.Encrypt(input));
        }
        [TestCase("KHOOR", "HELLO")]
        [TestCase("khoor", "hello")]
        [TestCase("KhOOr", "HeLLo")]
        [TestCase("DEF", "ABC")]
        public void Decrypt_ShiftCipher_ReturnsPlainText(string input, string output)
        {
            var obfuscator = new ShiftCipherObfuscator(3);
            Assert.AreEqual(output, obfuscator.Decrypt(input));
        }
        [TestCase("XYZ", "ABC")]
        [TestCase("ZAY", "CDB")]
        public void Encrypt_EdgeCharacters_IsAbleToLoopForward(string input, string output)
        {
            var obfuscator = new ShiftCipherObfuscator(3);
            Assert.AreEqual(output, obfuscator.Encrypt(input));
        }
        [TestCase("ABC", "XYZ")]
        [TestCase("CDB", "ZAY")]
        public void Decrypt_EdgeCharacters_IsAbleToLoopBackwards(string input, string output)
        {
            var obfuscator = new ShiftCipherObfuscator(3);
            Assert.AreEqual(output, obfuscator.Decrypt(input));
        }
        [TestCase("XYZ")]
        [TestCase("ABDCDEF")]
        [TestCase("HOMeOffice")]
        [TestCase("LMNoAxz")]
        public void EncryptAndDecrypt_AnyValue_ReturnsSameValueAsInput(string input)
        {
            var obfuscator = new ShiftCipherObfuscator(3);
            var encryptedString = obfuscator.Encrypt(input);
            var decryptedString = obfuscator.Decrypt(encryptedString);
            Assert.AreEqual(input, decryptedString);
        }
        [TestCase("XYZ", "XYZ")]
        [TestCase("ABDCDEF", "ABDCDEF")]
        [TestCase("HOMeOffice", "HOMeOffice")]
        [TestCase("LMNoAxz", "LMNoAxz")]
        public void Encrypt_WhenShiftKeyIs0_DoesNotEncrypt(string input, string output)
        {
            var obfuscator = new ShiftCipherObfuscator(0);
            Assert.AreEqual(output, obfuscator.Encrypt(input));
        }
        [TestCase("XYZ", "XYZ")]
        [TestCase("ABDCDEF", "ABDCDEF")]
        [TestCase("HOMeOffice", "HOMeOffice")]
        [TestCase("LMNoAxz", "LMNoAxz")]
        public void Decrypt_WhenShiftKeyIs0_ReturnInputValue(string input, string output)
        {
            var obfuscator = new ShiftCipherObfuscator(0);
            Assert.AreEqual(output, obfuscator.Decrypt(input));
        }
        [TestCase("KHOOR", "HELLO")]
        [TestCase("khoor", "hello")]
        [TestCase("KhOOr", "HeLLo")]
        [TestCase("DEF", "ABC")]
        public void Encrypt_WhenShiftKeyIsNegative_ReturnsBackwardShiftedCipher(string input, string output)
        {
            var obfuscator = new ShiftCipherObfuscator(-3);
            Assert.AreEqual(output, obfuscator.Encrypt(input));
        }
        [TestCase("HELLO", "KHOOR")]
        [TestCase("HeLLo", "KhOOr")]
        [TestCase("hello", "khoor")]
        [TestCase("ABC", "DEF")]
        public void Decrypt_WhenShiftKeyIsNegative_ReturnsDecryptedText(string input, string output)
        {
            var obfuscator = new ShiftCipherObfuscator(-3);
            Assert.AreEqual(output, obfuscator.Decrypt(input));
        }
    }
}