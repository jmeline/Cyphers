using Shouldly;
using Xunit;

namespace Ciphers.RouteCipher
{
    public class SpiralRouteCipherTests
    {
        private const string ALL_LETTERS = "THISISASECRETMESSAGET"; // final T is for padding, 21 chars

        private readonly SpiralRouteCipher _cipher;

        public SpiralRouteCipherTests()
        {
            _cipher = new SpiralRouteCipher();
        }

        [Fact]
        public void VerifyEncodeDecode()
        {
            // Arrange
            var message = ALL_LETTERS;
            _cipher.SetSpiralDimenstions(3, 7);

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
