using System;
using Ciphers.SubstitutionCiphers.PolybiusSquare;
using Shouldly;
using Xunit;

namespace Ciphers.SubstitutionCiphers.PolybiusSquare
{
    public class PolybiusSquareTest
    {
        private readonly PolybiusSquare _polybiusSquare;
        public PolybiusSquareTest()
        {
            _polybiusSquare = new PolybiusSquare();
        }

        [Fact]
        public void TestPSfullAlphabet()
        {
            var plain_message = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            // J is replaced by I, that's why the messages are different
            var decoded_message = "ABCDEFGHIIKLMNOPQRSTUVWXYZ";
            string encodedText = _polybiusSquare.Encode(plain_message);
            _polybiusSquare.Decode(encodedText).ShouldBe(decoded_message);
        }

        [Fact]
        public void TestPStextWithSpaces()
        {
            var plain_message = "A Polybius Square is a table that allows someone to translate letters into numbers";
            string encodedText = _polybiusSquare.Encode(plain_message);
            _polybiusSquare.Decode(encodedText).ShouldBe(plain_message.ToUpper());
        }

    }

}
