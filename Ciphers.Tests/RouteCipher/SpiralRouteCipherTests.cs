using Shouldly;
using Xunit;

namespace Ciphers.RouteCipher
{
    public class SpiralRouteCipherTests
    {
        private const string ALL_LETTERS = "THISISASECRETMESSAGET"; // final T is for padding
        private const int ROWS = 3;
        private const int COLS = 7;

        private readonly SpiralRouteCipher _cipher;

        public SpiralRouteCipherTests()
        {
            _cipher = new SpiralRouteCipher(ROWS, COLS);
        }

        [Fact]
        public void VerifyEncodeDecode()
        {
            // Arrange
            var message = ALL_LETTERS;

            // Act
            var encoded = _cipher.Encode(message);
            var decoded = _cipher.Decode(encoded);

            // Asset
            encoded.ShouldNotBe(decoded);
            encoded.ShouldStartWith("TSACTSGETAEEESIHISRMS");
            decoded.ShouldBe(message);
        }
    }
}
