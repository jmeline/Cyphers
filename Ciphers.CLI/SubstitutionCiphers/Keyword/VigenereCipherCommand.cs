using System;
using System.CommandLine.Invocation;
using Ciphers.SubstitutionCiphers.Keyword;

namespace Ciphers.CLI.SubstitutionCiphers.Keyword
{
    public sealed class VigenereCipherCommand : CipherCommand
    {
        private readonly VigenereAutokeyCipher cipher;

        public VigenereCipherCommand()
            : base("vigenere", "Vigenere cipher.")
        {
            cipher = new VigenereCipher();

            Handler = CommandHandler.Create<string, string>(HandleCommand);
        }

        private void HandleCommand(string decode, string encode)
        {
            if (!string.IsNullOrEmpty(decode))
                Console.Write(cipher.Decode(decode));
            else if (!string.IsNullOrEmpty(encode))
                Console.Write(cipher.Encode(encode));
        }
    }
}
