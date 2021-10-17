using System;
using System.Linq;

namespace Ciphers.SubstitutionCiphers.Keyword
{
    /// <summary>
    /// Implementation of the Keyword Cipher from:
    /// https://www.braingle.com/brainteasers/codes/keyword.php
    /// </summary>
    public class KeywordCipher : IKeywordCipher
    {
        private string _keyword;
        private int maxKeywordCharOffset;

        public KeywordCipher() : this(string.Empty) { }

        public KeywordCipher(string keyword)
        {
            _keyword = keyword ?? throw new ArgumentNullException(nameof(keyword));
        }

        public string Decode(string cipherText)
        {
            if (cipherText == null)
                throw new ArgumentNullException(nameof(cipherText));

            if (_keyword.Length == 0)
                return cipherText;

            return cipherText.Aggregate("", (current, character) =>
                current + (!char.IsLetterOrDigit(character)
                    ? character
                    : Decode(character)));
        }

        public string Encode(string plainText)
        {
            if (plainText == null)
                throw new ArgumentNullException(nameof(plainText));

            if (_keyword.Length == 0)
                return plainText;

            return plainText.Aggregate("", (current, character) =>
                current + (!char.IsLetterOrDigit(character)
                    ? character
                    : Encode(character)));
        }

        private char Decode(char input)
        {
            var startChar = char.IsUpper(input) ? 'A' : 'a';
            var inputCharOffset = input - startChar;
            var inputCharLower = (char)(input - startChar + 'a');

            if (_keyword.Contains(inputCharLower))
            {
                // Input was replaced by keyword so we assign original character
                return (char)(_keyword.IndexOf(inputCharLower) + startChar);
            }
            else if (inputCharOffset > maxKeywordCharOffset)
            {
                // Input was not effected by keyword so we return the input character.
                return input;
            }
            else
            {
                // Input was effected by keyword but not part of it.
                // We assign the original alphabet character
                return (char)(inputCharOffset + _keyword.Length + startChar);
            }
        }

        private char Encode(char input)
        {
            var startChar = char.IsUpper(input) ? 'A' : 'a';
            var inputCharOffset = input - startChar;

            if (inputCharOffset < _keyword.Length)
            {
                // Input is part of keyword so we assign keyword character
                return (char)(_keyword[inputCharOffset] - 'a' + startChar);
            }
            else if (inputCharOffset > maxKeywordCharOffset)
            {
                // Input is not effected by keyword so we return the input character.
                return input;
            }
            else
            {
                // Input is effected by keyword but not part of it.
                // We assign a replaced alphabet character
                return (char)(inputCharOffset - _keyword.Length + startChar);
            }
        }

        public string GetKeyword() => _keyword;

        public void SetKeyword(string keyword)
        {
            if (keyword == null)
                throw new ArgumentNullException(nameof(keyword));

            _keyword = string.Join(string.Empty, keyword.ToLowerInvariant().Distinct());

            // Precalculations
            maxKeywordCharOffset = _keyword.Length == 0 ? 0 : _keyword.Max() - 'a';
        }
    }

    public interface IKeywordCipher : ICipher
    {
        string GetKeyword();
        void SetKeyword(string keyword);
    }
}
