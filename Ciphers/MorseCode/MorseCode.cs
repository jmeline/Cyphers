using System;
using System.Collections.Generic;
using System.Linq;

namespace Ciphers.MorseCode
{
    public class MorseCode : ICipher
    {
        public static readonly Dictionary<char, string> CODES = new Dictionary<char, string>()
        {
            { 'a', ".-"},
            { 'b', "-..."},
            { 'c', "-.-."},
            { 'd', "-.."},
            { 'e', "."},
            { 'f', "..-."},
            { 'g', "--."},
            { 'h', "...."},
            { 'i', ".."},
            { 'j', ".---"},
            { 'k', "-.-"},
            { 'l', ".-.."},
            { 'm', "--"},
            { 'n', "-."},
            { 'o', "---"},
            { 'p', ".--."},
            { 'q', "--.-"},
            { 'r', ".-."},
            { 's', "..."},
            { 't', "-"},
            { 'u', "..-"},
            { 'v', "...-"},
            { 'w', ".--"},
            { 'x', "-..-"},
            { 'y', "-.--"},
            { 'z', "--.."},
            { '0', "-----"},
            { '1', ".----"},
            { '2', "..---"},
            { '3', "...--"},
            { '4', "....-"},
            { '5', "....."},
            { '6', "-...."},
            { '7', "--..."},
            { '8', "---.."},
            { '9', "----."},
        };

        public string Decode(string cipherText)
        {
            if (cipherText == null)
                throw new ArgumentNullException(nameof(cipherText));

            string morseCode = string.Empty;
            string decodedText = string.Empty;

            for (int i = 0; i < cipherText.Length; i++)
            {
                if (cipherText[i] == '.' || cipherText[i] == '-')
                    morseCode += cipherText[i];
                else
                {
                    if (string.IsNullOrEmpty(morseCode))
                    {
                        // Found a white space
                        decodedText += ' ';
                    }
                    else
                    {
                        // End of morse code reached
                        decodedText += DecodeMorseCode(morseCode);
                        morseCode = string.Empty;
                    }
                }
            }

            if (!string.IsNullOrEmpty(morseCode))
            {
                // Let's not forget the morse code we were currently reading
                decodedText += DecodeMorseCode(morseCode);
            }

            return decodedText;
        }

        public string Encode(string plainText)
        {
            if (plainText == null)
                throw new ArgumentNullException(nameof(plainText));

            return plainText.ToLowerInvariant()
                .Aggregate("", (current, character) =>
                {
                    if (char.IsLetterOrDigit(character))
                        return current + Encode(character) + ' ';
                    else if (char.IsWhiteSpace(character))
                        return current + character;
                    else
                        return current;
                })
                .Trim();
        }

        private static char DecodeMorseCode(string code)
        {
            return CODES.First(x => x.Value == code).Key;
        }

        private static string Encode(char c)
        {
            return CODES[c];
        }
    }
}
