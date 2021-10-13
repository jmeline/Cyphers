namespace Ciphers
{
    public interface ICipher
    {
        public string Encode(string plainText);
        public string Decode(string cipherText);
    }
}