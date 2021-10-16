using Shouldly;
using Xunit;

namespace Ciphers.SubstitutionCiphers.Keyword
{
    public class KeywordCipherTests
    {
        private readonly IKeywordCipher _cipher;

        private const string ALPHABET = "abcdefghijklmnopqrstuvwxyz";
        private const string ALL_LETTERS = "the quick brown fox jumps over the lazy dog";

        public KeywordCipherTests()
        {
            _cipher = new KeywordCipher();
        }

        /// <summary>
        /// Verifies that
        /// - Duplicate letters are removed
        /// - Order is preserved
        /// - Keyword is stored in lower case characters
        /// </summary>
        [Fact]
        public void VerifyUniqueKeywordLetters()
        {
            _cipher.SetKeyword("babaABAB");
            _cipher.GetKeyword().ShouldBe("ba");
        }

        [Fact]
        public void VerifyWhenKeywordIsEmpty()
        {
            // Arrange
            var message = ALL_LETTERS;
            _cipher.SetKeyword(string.Empty);

            // Act
            var encoded = _cipher.Encode(message);
            var decoded = _cipher.Decode(encoded);

            // Asset
            encoded.ShouldBe(decoded);
            decoded.ShouldBe(message);
        }

        [Fact]
        public void VerifyWhenKeywordIsAlphabet()
        {
            // Arrange
            var message = ALL_LETTERS;
            _cipher.SetKeyword(ALPHABET);

            // Act
            var encoded = _cipher.Encode(message);
            var decoded = _cipher.Decode(encoded);

            // Asset
            encoded.ShouldBe(decoded);
            decoded.ShouldBe(message);
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
            var message = "abcabc";
            _cipher.SetKeyword("b");

            // Act
            var encoded = _cipher.Encode(message);
            var decoded = _cipher.Decode(encoded);

            // Asset
            encoded.ShouldNotBe(decoded);
            encoded.ShouldBe("bacbac");
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