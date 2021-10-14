using System.Linq;

namespace Ciphers.SubstitutionCiphers.ROT13
{
    /*
     * ROT13 is a special case of the Cesar Cipher
     * Rotate by 13 places is a simple letter substitution cipher that replaces
     * a letter with the 13th letter after it in the alphabet
     * 
     * https://en.wikipedia.org/wiki/ROT13
     */
    public class RotateBy13PlacesCipher : ICipher
    {
        public const int RotationSize = 13;
        
        public char Convert(char value, int rotation)
        {
            int offset = char.IsUpper(value) ? 'A' : 'a';
            var result = Extensions.Mod((value - offset + rotation), 26) + offset;
            return (char)result;
        }
        
        public string Encode(string plainText)
        {
            return plainText
                .Aggregate("", (current, character) => 
                   current + (!char.IsLetterOrDigit(character) 
                       ? character 
                       : Convert(character, RotationSize)));
        }

        public string Decode(string cipherText)
        {
            return cipherText
                .Aggregate("", (current, character) => 
                   current + (!char.IsLetter(character) 
                       ? character 
                       : Convert(character, -RotationSize)));
        }
    }
}