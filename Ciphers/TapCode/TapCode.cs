using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Ciphers.TapCode
{
    public class TapCode : ICipher
    {
        private static Dictionary<char, (int x, int y)> CODES_INTERNAL;
        private static readonly char[,] MATRIX = new char[5, 5]
        {
            { 'A', 'B', 'C', 'D', 'E' },
            { 'F', 'G', 'H', 'I', 'J' },
            { 'L', 'M', 'N', 'O', 'P' },
            { 'Q', 'R', 'S', 'T', 'U' },
            { 'V', 'W', 'X', 'Y', 'Z' },
        };

        private static IReadOnlyDictionary<char, (int x, int y)> CODES
        {
            get
            {
                if(CODES_INTERNAL == null)
                {
                    CODES_INTERNAL = new();
                    for (var y = 0; y < MATRIX.GetLength(0); y++)
                        for (var x = 0; x < MATRIX.GetLength(1); x++)
                            CODES_INTERNAL.Add(MATRIX[y, x], (x, y));
                    CODES_INTERNAL.TryAdd('K', CODES_INTERNAL['C']); //special case - 'C' replaces 'K'
                }
                return CODES_INTERNAL;
            }
        }

        private const char TAP_CHAR = '.';
        private const char TAP_GROUP_SEPARATOR_CHAR = ' ';
        private const string LETTER_SEPARATOR = "  ";
        private const string WORD_SEPARATOR = "/";

        public string Decode(string cipherText)
        {
            if (cipherText == null)
                throw new ArgumentNullException(nameof(cipherText));

            var splittedChars = cipherText.Split(LETTER_SEPARATOR);
            var decodedChars = splittedChars.Select(c => DecodeChar(c)).ToArray();

            return new string(decodedChars);
        }

        private char DecodeChar(string s)
        {
            if (s == WORD_SEPARATOR)
                return ' ';

            if (!Regex.IsMatch(s, $"^{Regex.Escape(TAP_CHAR.ToString())}{{1,5}}{Regex.Escape(TAP_GROUP_SEPARATOR_CHAR.ToString())}{Regex.Escape(TAP_CHAR.ToString())}{{1,5}}$"))
                throw new InvalidOperationException($"Decoded char '{s}' can not be decrypted.");

            var splittedTapGroups = s.Split(TAP_GROUP_SEPARATOR_CHAR);
            var x = splittedTapGroups[0].Length - 1; //make it 0-based
            var y = splittedTapGroups[1].Length - 1; //make it 0-based

            return MATRIX[x, y];
        }

        public string Encode(string plainText)
        {
            if (plainText == null)
                throw new ArgumentNullException(nameof(plainText));

            plainText = plainText.ToUpperInvariant();
            var encodedChars = plainText.Select(c => EncodeChar(c));
            var encodedString = string.Join(LETTER_SEPARATOR, encodedChars);

            return encodedString;
        }

        private string EncodeChar(char c)
        {
            if (c == ' ') 
                return WORD_SEPARATOR;

            if (!CODES.ContainsKey(c))
                throw new InvalidOperationException($"Char '{c}' can not be encrypted.");

            var coordinate = CODES[c];
            coordinate.x += 1; //make it 1-based
            coordinate.y += 1; //make it 1-based
            return $"{new string(TAP_CHAR, coordinate.y)}{TAP_GROUP_SEPARATOR_CHAR}{new string(TAP_CHAR, coordinate.x)}";
        }
    }
}
