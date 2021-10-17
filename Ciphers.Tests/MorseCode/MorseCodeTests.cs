using Shouldly;
using Xunit;

namespace Ciphers.MorseCode
{
    public class MorseCodeTests
    {
        private readonly ICipher _cipher;

        public MorseCodeTests()
        {
            _cipher = new MorseCode();
        }

        /// <summary>
        /// Verifies that:
        /// - Lower and upper case characters are supported
        /// - Numbers are supported
        /// - Spaces are added between characters
        /// - Double spaces are added between words
        /// </summary>
        [Fact]
        public void VerifyMechanics()
        {
            // Arrange
            var message = "aB C  0";

            // Act
            var encoded = _cipher.Encode(message);
            var decoded = _cipher.Decode(encoded);

            // Asset
            encoded.ShouldNotBe(decoded);
            encoded.ShouldBe($"{MorseCode.CODES['a']} {MorseCode.CODES['b']}  {MorseCode.CODES['c']}   {MorseCode.CODES['0']}");
            decoded.ShouldBe(message.ToLowerInvariant());
        }

        [Fact]
        public void VerifyLongText()
        {
            // Arrange
            var message = "Just some longer text including some 123456789 numbers";

            // Act
            var encoded = _cipher.Encode(message);
            var decoded = _cipher.Decode(encoded);

            // Asset
            encoded.ShouldNotBe(decoded);
            decoded.ShouldBe(message.ToLowerInvariant());
        }
    }
}
