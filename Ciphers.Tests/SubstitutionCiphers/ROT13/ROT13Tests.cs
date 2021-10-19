using Shouldly;
using Xunit;

namespace Ciphers.SubstitutionCiphers.ROT13
{
    public class ROT13Tests
    {
        private readonly RotateBy13PlacesCipher _rot13;

        public ROT13Tests()
        {
            _rot13 = new RotateBy13PlacesCipher();
        }
        
        [Fact]
        public void VerifyROT13Works()
        {
            _rot13.Encode("Defend the Gate!").ShouldBe("Qrsraq gur Tngr!");
            _rot13.Decode("Qrsraq gur Tngr!").ShouldBe("Defend the Gate!");
        }
        
    }
}