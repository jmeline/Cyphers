using System;
using System.Linq;
using Ciphers.SubstitutionCiphers.Keyword;

namespace Ciphers.TranspositionCiphers
{
    public class ColumnarTranspositionCipher : IKeywordCipher
    {
        private string _keyword;

        public ColumnarTranspositionCipher() { }

        public ColumnarTranspositionCipher(string keyword) =>
            SetKeyword(keyword);

        public string Decode(string cipherText)
        {
            var rows = _keyword.Length;
            var columns = cipherText.Length / rows;

            if (cipherText.Length != columns * rows)
                throw new ArgumentException("Text length is not a multiple of configured rails", nameof(cipherText));

            var plainText = string.Empty;
            var orderedKeywordIndexes = _keyword.OrderBy(x => x).Select((kChar, idx) => (kChar, idx)).ToDictionary(kv => kv.kChar, kv => kv.idx); // determine keyword characters indexes in alphabetical order

            for (var col = 0; col < columns; col++)
                foreach (var k in _keyword)
                    plainText += cipherText[orderedKeywordIndexes[k] + col * rows];

            return plainText;
        }

        public string Encode(string plainText)
        {
            var columns = _keyword.Length;
            var rows = (int)Math.Ceiling((float)plainText.Length / columns);

            var cipherText = string.Empty;
            var colIdxs = _keyword.Select((kChar, idx) => (kChar, idx)).OrderBy(x => x.kChar).Select(x => x.idx).ToArray(); // create char/index couples, order alphabetically and select indexes

            foreach (var col in colIdxs)
                for (var row = 0; row < rows; row++)
                    cipherText += plainText[(col + row * columns) % plainText.Length];

            return cipherText;
        }

        public string GetKeyword() =>
            _keyword;

        public void SetKeyword(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                throw new ArgumentException("Keyword must be a not empty, not null string", nameof(keyword));

            _keyword = new string(keyword.Distinct().ToArray());
        }
    }
}
