using Shouldly;
using Xunit;

namespace Ciphers.SubstitutionCiphers.Keyword
{
    public class VigenereAutokeyCipherTests
    {
        private readonly IKeywordCipher _cipher;

        private const string ALL_LETTERS = "the quick brown fox jumps over the lazy dog";

        public VigenereAutokeyCipherTests()
        {
            _cipher = new VigenereAutokeyCipher();
        }

        /// <summary>
        /// Verifies that
        /// - Keyword is stored in lower case characters and without special characters (spaces included)
        /// </summary>
        [Fact]
        public void VerifyKeyworkdLowerCaseNoSpecialCharacters()
        {
            _cipher.SetKeyword("a B!c,D-e$F");
            _cipher.GetKeyword().ShouldBe("abcdef");
        }

        /// <summary>
        /// Verifies that the alghoritm correctly encodes and decodes back a given text
        /// </summary>
        [Fact]
        public virtual void VerifyWhenKeywordIsNotEmpty()
        {
            // Arrange
            var message = ALL_LETTERS;
            _cipher.SetKeyword("testkeyword");

            // Act
            var encoded = _cipher.Encode(message);
            var decoded = _cipher.Decode(encoded);

            // Asset
            encoded.ShouldNotBe(decoded);
            // cfr. https://www.boxentriq.com/code-breaking/vigenere-cipher, plain = "the quick brown fox jumps over the lazy dog", key = "testkeyword, AutoKey variant"
            encoded.ShouldBe("mlw jemag pirpu jer rwwqj crrw hen fmoq rjk");
            decoded.ShouldBe(message);
        }
    }
}