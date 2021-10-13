using Shouldly;
using Xunit;

namespace Ciphers.SubstitutionCiphers.Atbash
{
    public class AtbashTests
    {
        private readonly AtbashCipher _atBashCipher;

        public AtbashTests()
        {
            _atBashCipher = new AtbashCipher();
        }

        [Fact]
        public void VerifyEncodingWorks()
        {
            _atBashCipher.Encode("AbC").ShouldBe("ZyX");
        }
        
        [Fact]
        public void VerifyDecodingWorks()
        {
            _atBashCipher.Decode("ZyX").ShouldBe("AbC");
        }
    }
}