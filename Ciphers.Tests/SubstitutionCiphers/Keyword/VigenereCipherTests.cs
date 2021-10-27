using Shouldly;
using Xunit;

namespace Ciphers.SubstitutionCiphers.Keyword
{
    public class VigenereCipherTests : VigenereAutokeyCipherTests
    {
        private readonly IKeywordCipher _cipher;

        private const string ALL_LETTERS = "the quick brown fox jumps over the lazy dog";

        public VigenereCipherTests()
        {
            _cipher = new VigenereCipher();
        }

        /// <summary>
        /// Verifies that the alghoritm correctly encodes and decodes back a given text
        /// </summary>
        [Fact]
        public override void VerifyWhenKeywordIsNotEmpty()
        {
            // Arrange
            var message = ALL_LETTERS;
            _cipher.SetKeyword("testkeyword");

            // Act
            var encoded = _cipher.Encode(message);
            var decoded = _cipher.Decode(encoded);

            // Asset
            encoded.ShouldNotBe(decoded);
            // cfr. https://www.boxentriq.com/code-breaking/vigenere-cipher, plain = "the quick brown fox jumps over the lazy dog", key = "testkeyword", std. Mode
            encoded.ShouldBe("mlw jemag pirpr xhh nsidj roij mri jwnp ghk");
            decoded.ShouldBe(message);
        }
    }
}