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
            _atBashCipher.Encode("DeFeNd ThE CaStLe!").ShouldBe("WvUvMw GsV XzHgOv!");
            _atBashCipher.Decode("WvUvMw GsV XzHgOv!").ShouldBe("DeFeNd ThE CaStLe!");
        }
        
        [Fact]
        public void VerifyDecodingWorks()
        {
            _atBashCipher.Decode("ZyX").ShouldBe("AbC");
        }
    }
}