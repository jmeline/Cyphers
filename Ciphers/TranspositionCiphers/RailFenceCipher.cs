using System;

namespace Ciphers.TranspositionCiphers
{
    public class RailFenceCipher : ICipher
    {
        private int _rails;

        public RailFenceCipher() { }

        public RailFenceCipher(int rails) => _rails = rails;

        public void SetRail(int rails) =>
            _rails = rails;

        public string Decode(string cipherText)
        {
            var rows = _rails;
            var columns = cipherText.Length / rows;

            if (cipherText.Length != columns * rows)
                throw new ArgumentException("Text length is not a multiple of configured rails", nameof(cipherText));

            var plainText = string.Empty;

            for (var col = 0; col < columns; col++)
                for (var row = 0; row < rows; row++)
                    plainText += cipherText[col + row * columns];

            return plainText;
        }

        public string Encode(string plainText)
        {
            var toEncode = plainText.Replace(" ", string.Empty);

            var rows = _rails;
            var columns = (int)Math.Ceiling((float)toEncode.Length / rows);

            var cipherText = string.Empty;

            for (var row = 0; row < rows; row++)
                for (var col = 0; col < columns; col++)
                    cipherText += toEncode[(row + col * rows) % toEncode.Length];

            return cipherText;
        }
    }
}
