using System;
using Ciphers.TranspositionCiphers;
using Shouldly;
using Xunit;

namespace Ciphers.Tests.TranspositionCiphers
{
    public class RailFenceCipherTests
    {
        private readonly ICipher _cipher;

        public RailFenceCipherTests()
        {
            _cipher = new RailFenceCipher(3);
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
            Should.Throw(() => _cipher.Decode(encoded), typeof(ArgumentException));
        }

        /// <summary>
        /// Verifies that cipher correctly encodes and decodes
        /// </summary>
        [Fact]
        public void VerifyEncodeDecode()
        {
            // Arrange
            const string message = "THIS IS A SECRET MESSAGE";

            // Act
            var encoded = _cipher.Encode(message);
            var decoded = _cipher.Decode(encoded);

            // Asset
            encoded.ShouldNotBe(decoded);
            encoded.ShouldBe("TSACTSGHISRMSEISEEEAT"); // final T is from message repetition for padding
            decoded.StartsWith(message);
        }
    }
}