using System.Linq;

namespace Ciphers.SubstitutionCiphers.Atbash
{
    /*
     * Atbash is a monoalphabetic substitution cipher originally
     * used to encrypt the hebrew alphabet. It can be modified for use
     * with any known writing system with a standard collating order
     *
     * https://en.wikipedia.org/wiki/Atbash
     *
     * How does it work?
     *
     * Take the alphabet and map it to its reverse. First letter becomes
     * the last letter, the second letter becomes the second to the last letter and so on
     *
     * Example:
     *   ABC -> ZYX
     *   
     * Note, this is clearly not secure for any time of modern communication.
     */
    
    public class AtbashCipher : ICipher
    {
        private char Convert(char value)
        {
            var digit = char.IsUpper(value) ? 'A' : 'a';
            var charAsInt = (int)value;
            var offset = -(charAsInt - digit + 1);
            var newValue = Extensions.Mod(offset, 26);
            return (char)(newValue + digit);
        }

        private string IterateAndConvertText(string text) => 
            text.Aggregate("", (current, character) => 
                    current + Convert(character));
        
        public string Encode(string plainText) => IterateAndConvertText(plainText);

        public string Decode(string cipherText) => IterateAndConvertText(cipherText);
    }

}