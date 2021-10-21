namespace Ciphers.SubstitutionCiphers.Vigenere
{
    public class VigenereCipher : VigenereAutokeyCipher
    {
        private string PadKeyword(int desiredLength)
        {
            var kw = _keyword.Length > desiredLength ? _keyword[..desiredLength] : _keyword;

            var idx = 0;
            while (kw.Length < desiredLength)
                kw += _keyword[idx++ % _keyword.Length];

            return kw;
        }

        protected override string GetEncodingKeyword(string plainText) =>
            PadKeyword(plainText.Length);

        protected override string GetDecodingKeyword(string cipherText) =>
            PadKeyword(cipherText.Length);
    }
}
