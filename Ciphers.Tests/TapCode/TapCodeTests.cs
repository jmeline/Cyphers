using Shouldly;
using System.Linq;
using Xunit;

namespace Ciphers.TapCode
{
    public class TapCodeTests
    {
        private readonly ICipher _cipher;

        public TapCodeTests()
        {
            _cipher = new TapCode();
        }

        /// <summary>
        /// Verifies that:
        /// - Lower and upper case characters are supported
        /// - Double spaces are added between characters
        /// - Slashes are added between words
        /// - Char 'K' gets replaced by 'C'
        /// </summary>
        [Fact]
        public void VerifyMechanics()
        {
            // Arrange
            var inputMessage = "this is a message and K Should Get replaced bY c";
            var expectedEncoded = ".... ....  .. ...  .. ....  .... ...  /  .. ....  .... ...  /  . .  /  ... ..  . .....  .... ...  .... ...  . .  .. ..  . .....  /  . .  ... ...  . ....  /  . ...  /  .... ...  .. ...  ... ....  .... .....  ... .  . ....  /  .. ..  . .....  .... ....  /  .... ..  . .....  ... .....  ... .  . .  . ...  . .....  . ....  /  . ..  ..... ....  /  . ...";
            var expectedDecoded = inputMessage.ToUpperInvariant().Select(c => c == 'K' ? 'C' : c);

            // Act
            var encoded = _cipher.Encode(inputMessage);
            var decoded = _cipher.Decode(encoded);

            // Asset
            encoded.ShouldBe(expectedEncoded);
            decoded.ShouldBe(expectedDecoded);
        }
    }
}
