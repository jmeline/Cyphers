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
            var columns = (int)Math.Ceiling((float)cipherText.Length / rows);

            var matrix = TextToMatrix(cipherText, rows, columns);

            var plainText = string.Empty;
            var orderedKeywordIndexes = _keyword.OrderBy(x => x).Select((kChar, idx) => (kChar, idx)).ToDictionary(kv => kv.kChar, kv => kv.idx); // determine keyword characters indexes in alphabetical order

            for (var col = 0; col < matrix.GetLength(1); col++)
                foreach (var k in _keyword)
                    plainText += matrix[orderedKeywordIndexes[k], col];

            return plainText;
        }

        public string Encode(string plainText)
        {
            var columns = _keyword.Length;
            var rows = (int)Math.Ceiling((float)plainText.Length / columns);

            var matrix = TextToMatrix(plainText, rows, columns);

            var cipherText = string.Empty;
            var colIdxs = _keyword.Select((kChar, idx) => (kChar, idx)).OrderBy(x => x.kChar).Select(x => x.idx).ToArray(); // create char/index couples, order alphabetically and select indexes

            foreach (var col in colIdxs)
                for (var row = 0; row < matrix.GetLength(0); row++)
                    cipherText += matrix[row, col];

            return cipherText;
        }

        public string GetKeyword() =>
            _keyword;

        public void SetKeyword(string keyword) =>
            _keyword = new string(keyword.Distinct().ToArray());

        private static char[,] TextToMatrix(string text, int rows, int columns)
        {
            var matrix = new char[rows, columns];

            var cipherIdx = 0;

            for (var r = 0; r < rows; r++)
                for (var c = 0; c < columns; c++)
                    matrix[r, c] = text[cipherIdx++ % text.Length];

            return matrix;
        }
    }
}
