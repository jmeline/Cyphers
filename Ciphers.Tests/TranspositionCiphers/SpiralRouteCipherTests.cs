using System;
using Shouldly;
using Xunit;

namespace Ciphers.TranspositionCiphers
{
    public class SpiralRouteCipherTests
    {
        private readonly SpiralRouteCipher _cipher;

        public SpiralRouteCipherTests()
        {
            _cipher = new SpiralRouteCipher();
        }

        /// <summary>
        /// Verifies that the cipher works in both encoding and decoding, cfr. https://www.braingle.com/brainteasers/codes/route.php
        /// </summary>
        [Fact]
        public void VerifyEncodeDecode()
        {
            // Arrange
            const int ROWS = 3;
            const int COLS = 7;
            const string message = "THISISASECRETMESSAGE";
            _cipher.SetSpiralSize(ROWS, COLS);

            // Act
            var encoded = _cipher.Encode(message);
            var decoded = _cipher.Decode(encoded);

            // Assert
            encoded.ShouldNotBe(decoded);
            encoded.ShouldBe("TSACTSGETAEEESIHISRMS");
            decoded.ShouldBe($"{message}{message[..(ROWS * COLS - message.Length)]}"); // pad the string to match the desired length
        }

        /// <summary>
        /// Verify that the cipher pads the text repeating it to reach the spiral length (rows + columns)
        /// </summary>
        [Fact]
        public void VerifyPadText()
        {
            // Arrange
            const string message = "SECRET TEXT";
            _cipher.SetSpiralSize(4, 4);

            // Act
            var encoded = _cipher.Encode(message);
            var decoded = _cipher.Decode(encoded);

            // Assert
            decoded.ShouldBe("SECRETTEXTSECRET");
        }

        /// <summary>
        /// Verifies that the cipher returns error if the encoded text doesn't match the spiral size
        /// </summary>
        [Fact]
        public void VerifyCheckOnEncodedText()
        {
            // Arrange
            const string encodedMessage = "THIS TEXT IS TOO LONG";
            _cipher.SetSpiralSize(4, 4);

            // Assert
            Should.Throw(() => _cipher.Decode(encodedMessage), typeof(ArgumentException));
        }
    }
}
