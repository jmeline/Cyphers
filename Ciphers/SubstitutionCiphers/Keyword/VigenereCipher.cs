namespace Ciphers.SubstitutionCiphers.Keyword
{
    public class VigenereCipher : VigenereAutokeyCipher
    {
        private string PadKeyword(int desiredLength)
        {
            if (_keyword.Length > desiredLength)
                return _keyword[..desiredLength];

            var kw = _keyword.ToString();

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
