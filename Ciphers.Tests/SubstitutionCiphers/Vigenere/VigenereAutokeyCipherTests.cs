using Ciphers.SubstitutionCiphers.Keyword;
using Shouldly;
using Xunit;

namespace Ciphers.SubstitutionCiphers.Vigenere
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

        /// <re>
        /// Verifies that
        /// - Input letters are replaced multiple times by the keyword
        ///   In this case 'a' is replaced by 'b' multiple times
        /// - Keyword letters are given a new alphabet letter multiple times
        ///   In this case 'b' is given the letter 'a'
        /// - Any other input letter is still functioning
        ///   In this case 'c' stil has 'c'
        /// </summary>
        [Fact]
        public void VerifyWhenKeywordIsNotEmpty()
        {
            // Arrange
            var message = ALL_LETTERS;
            _cipher.SetKeyword("testkeyword");

            // Act
            var encoded = _cipher.Encode(message);
            var decoded = _cipher.Decode(encoded);

            // Asset
            encoded.ShouldNotBe(decoded);
            // cfr. https://www.boxentriq.com/code-breaking/vigenere-cipher, plain = "the quick brown fox jumps over the lazy dog", key = "testkeyword"
            encoded.ShouldBe("mlw jemag pirpu jer rwwqj crrw hen fmoq rjk");
            decoded.ShouldBe(message);
        }

        [Fact]
        public void VerifyWhenKeywordIsNotEmpty_And_MixedMessageCasing()
        {
            // Arrange
            var message = "abcABC";
            _cipher.SetKeyword("b");

            // Act
            var encoded = _cipher.Encode(message);
            var decoded = _cipher.Decode(encoded);

            // Asset
            encoded.ShouldNotBe(decoded);
            encoded.ShouldBe("bacBAC");
            decoded.ShouldBe(message);
        }
    }
}