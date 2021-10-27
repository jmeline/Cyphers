namespace Ciphers.SubstitutionCiphers.Keyword
{
    public class VigenereAutokeyCipher : IKeywordCipher
    {
        protected const char LowercaseAlphabetStart = 'a'; // 97
        protected string _keyword = string.Empty;

        public VigenereAutokeyCipher() { }

        public VigenereAutokeyCipher(string keyword) =>
            SetKeyword(keyword);

        public string Decode(string cipherText)
        {
            var extKey = GetDecodingKeyword(cipherText);
            var plainText = string.Empty;
            var keyIdx = 0;

            foreach (var c in cipherText)
            {
                var cipherChar = char.ToLower(c);

                if (!char.IsLower(cipherChar))  // if it's not lower after .ToLower(), it's not a letter, don't decode/add to key
                {
                    plainText += c;
                    continue;
                }

                var keyChar = extKey[keyIdx++];

                var plainChar = DenormalizeChar(NormalizeChar(cipherChar) - NormalizeChar(keyChar)); // left shift the character in the alphabet using key and cipher char
                if (plainChar < LowercaseAlphabetStart)
                    plainChar = (char)(plainChar + 26);

                plainText += char.IsUpper(c) ? char.ToUpper(plainChar) : plainChar;
                extKey += plainChar;
            }

            return plainText;
        }

        public string Encode(string plainText)
        {
            var extKey = GetEncodingKeyword(plainText);
            var keyIdx = 0;
            var cipherText = string.Empty;

            foreach (var c in plainText)
            {
                var plainChar = char.ToLower(c);

                if (!char.IsLower(plainChar)) // if it's not lower after .ToLower(), it's not a letter, don't encode
                {
                    cipherText += c;
                    continue;
                }

                var keyChar = extKey[keyIdx++];

                var cipherChar = DenormalizeChar((NormalizeChar(plainChar) + NormalizeChar(keyChar)) % 26); // right shift the character in the alphabet using key and plain char
                cipherText += char.IsUpper(c) ? char.ToUpper(cipherChar) : cipherChar;
            }

            return cipherText;
        }

        public string GetKeyword() =>
            _keyword;

        public void SetKeyword(string keyword)
        {
            foreach (var c in keyword)
            {
                var lowerC = char.ToLower(c); // keyword needs to be normalized in lowercase
                if (char.IsLower(lowerC)) // if it's not lower after .ToLower(), it's not a letter, don't encode
                    _keyword += lowerC;
            }
        }

        /// <summary>
        /// Normalizes a lowercase <see cref="char"/>, converting it to the corresponding index in the alphabet (0-indexed)
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        private static int NormalizeChar(char c) =>
            c - LowercaseAlphabetStart;

        /// <summary>
        /// Denormalizes an <see cref="int"/>, converting it to the corresponding character assuming it's an alphabet index (0-indexed)
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        private static char DenormalizeChar(int c) =>
            (char)(c + LowercaseAlphabetStart);

        #region ... protected ...
        protected virtual string GetEncodingKeyword(string plainText) =>
            $"{_keyword}{plainText.Replace(" ", string.Empty)}";
        protected virtual string GetDecodingKeyword(string cipherText) =>
            _keyword.ToString(); // clone the string keyword, so it can be padded with plain text

        #endregion ... protected ...

    }
}
