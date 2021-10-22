using Ciphers.SubstitutionCiphers.Keyword;
using Ciphers.TranspositionCiphers;
using Shouldly;
using Xunit;

namespace Ciphers.Tests.TranspositionCipher
{
    public class ColumnarTranspositionCipherTests
    {
        private readonly IKeywordCipher _cipher;

        public ColumnarTranspositionCipherTests()
        {
            _cipher = new ColumnarTranspositionCipher();
        }

        /// <summary>
        /// Verifies that
        /// - Duplicate letters are removed
        /// - Order is preserved
        /// </summary>
        [Fact]
        public void VerifyUniqueKeywordLetters()
        {
            _cipher.SetKeyword("aA bBb ");
            _cipher.GetKeyword().ShouldBe("aA bB");
        }

        /// <re>
        /// Verifies that cipher correctly encodes and decodes
        /// </summary>
        [Fact]
        public void VerifyEncodeDecode()
        {
            // Arrange
            const string message = "WEAREDISCOVEREDFLEEATONCE";
            _cipher.SetKeyword("ZEBRAS");

            // Act
            var encoded = _cipher.Encode(message);
            var decoded = _cipher.Decode(encoded);

            // Asset
            encoded.ShouldNotBe(decoded);
            encoded.ShouldBe("EVLNRACDTEESEAWROFOADEECEWIREE");
            decoded.StartsWith(message);
        }
    }
}