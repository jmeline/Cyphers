using System;
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

        /// <summary>
        /// Verifies that cipher checks the keyword is not null and not empty
        /// </summary>
        [Fact]
        public void VerifyCheckValidKeyword()
        {
            // Assert
            Should.Throw(() =>
            {
                _cipher.SetKeyword(string.Empty);
            }, typeof(ArgumentException));

            Should.Throw(() =>
            {
                _cipher.SetKeyword(null);
            }, typeof(ArgumentException));
        }

        /// <summary>
        /// Verifies that cipher returns error if encoded text is not a multiple of the rails number
        /// </summary>
        [Fact]
        public void VerifyWrongDecodedMessage()
        {
            // Arrange
            const string encoded = "MESSAGE OF 25 CHARACTERS!";

            // Assert
            Should.Throw(() =>
            {
                _cipher.SetKeyword("key");
                _cipher.Decode(encoded);
            }, typeof(ArgumentException));
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