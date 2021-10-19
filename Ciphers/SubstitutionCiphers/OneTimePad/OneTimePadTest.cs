using System;
using Ciphers.SubstitutionCiphers.OneTimePad;
using Shouldly;
using Xunit;

namespace Ciphers.SubstitutionCiphers.OneTimePad
{
    public class OneTimePadTest
    {
        private readonly OneTimePad _oneTimePad;
        public OneTimePadTest()
        {
            _oneTimePad = new OneTimePad();
        }

        [Fact]
        public void TestOTP()
        {
            var message = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string encodedText = _oneTimePad.Encode(message);
            _oneTimePad.Decode(encodedText).ShouldBe(message);
        }
    }
}
