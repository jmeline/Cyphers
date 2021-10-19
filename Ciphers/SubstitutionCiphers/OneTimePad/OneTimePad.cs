using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ciphers.SubstitutionCiphers.OneTimePad
{
    /// <summary>
    /// One-time Pad Cipher
    /// https://en.wikipedia.org/wiki/One-time_pad
    /// The one-time pad is a long sequence of random letters.
    /// These letters are combined with the plaintext message to produce the ciphertext.
    /// To decipher the message, a person must have a copy of the one-time pad to reverse the process.
    /// A one-time pad should be used only once (hence the name) and then destroyed.
    /// This is the first and only encryption algorithm that has been proven to be unbreakable.
    /// </summary>
    public class OneTimePad : ICipher
    {
        
        public string Encode(string plainText)
        {
            Random rand = new Random();
            string encodedText = string.Empty;
            string onePadTimeCode = string.Empty;
            foreach (char c in plainText)
            {
                int nRandom = rand.Next(1, 27);
                   
                // ASCII code: A - 065 Z = 090
                // we need to bring ASCII code to the letter number then bring it back to ASCII by adding 65
                char encodedChar = (char)(((int)c - 66 + nRandom ) % 26 + 65);
                encodedText += encodedChar;
                onePadTimeCode += (char)(nRandom + 64);
            }
            
            return encodedText+";"+ onePadTimeCode;
        }

        // cipherText must contain encoded text plus on  pad time code separated by ";" symbol
        // example cipherText = "UMLKLNGLEDFXY;CIJTHUUHMLFRU";
        public string Decode(string cipherText)
        {
            
            string encodedText = cipherText.Split(";")[0];
            string onePadTimeCode = cipherText.Split(";")[1];
            string plainText = string.Empty;

            for(int i=0; i< encodedText.Length; i++)
            {
                // ASCII code: A - 065 Z = 090
                int a = onePadTimeCode[i] - 64;
                int b = encodedText[i] - 64;
                char encodedChar = (char)((b - a + 26) % 26 + 65);

                plainText += encodedChar;
            }

            return plainText;
        }
    }
}