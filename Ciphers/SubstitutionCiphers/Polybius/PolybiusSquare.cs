using System;
using System.Collections.Generic;
using System.Linq;

namespace Ciphers.SubstitutionCiphers.PolybiusSquare
{
    /// <summary>
    /// Polybius square
    /// https://en.wikipedia.org/wiki/Polybius_square
    /// A Polybius Square is a table that allows someone to translate letters into numbers. 
    /// To give a small level of encryption, this table can be randomized and shared with the recipient.
    /// In order to fit the 26 letters of the alphabet into the 25 spots created by the table, the letters i and j are usually combined.
    /// </summary>

    public class PolybiusSquare : ICipher
    {
        // Polybius Square table
        private Dictionary<char, int> squareTable = new Dictionary<char, int>();

        public PolybiusSquare()
        {
            // generate Polibius Square table
            char letter = 'A';
            for (int r = 1; r <= 5; r++)
                for (int c = 1; c <= 5; c++)
                {
                    // skip "J" and return column number to the previous position 
                    if (letter == 'J')
                        c--;
                    else
                        squareTable.Add(letter, r * 10 + c);
                    letter++;
                }
        }
        public string Encode(string plainText)
        {
            plainText = plainText.ToUpper().Replace('J', 'I');
            string encoded_text = string.Empty;
            int letter_code;
            foreach (char c in plainText)
            {
                // if the symbol is in the Polybius Square Table - encode it
                if (squareTable.TryGetValue(c, out letter_code))
                {
                    encoded_text += letter_code.ToString();
                }
                // otherwise we add space to the encoded string
                else
                    encoded_text += ' ';

            }

            return encoded_text;
        }

        public string Decode(string encodedText)
        {
            string decoded_text = string.Empty;
            for (int i = 0; i < encodedText.Length; i += 2)
            {
                //int encodedLetter = 0;
                int.TryParse(encodedText.Substring(i, 2), out int encodedLetter);
                // if the symbol is not a Letter, we shift the index back and add space
                if (encodedLetter < 11 || encodedLetter > 55)
                {
                    decoded_text += ' ';
                    i--;
                    continue;
                }

                //squareTable.FirstOrDefault(x => x.Value == encodedLetter).Key;
                char decodedLetter = squareTable.FirstOrDefault(x => x.Value == encodedLetter).Key;
                decoded_text += decodedLetter;
            }

            return decoded_text;
        }
    }
}