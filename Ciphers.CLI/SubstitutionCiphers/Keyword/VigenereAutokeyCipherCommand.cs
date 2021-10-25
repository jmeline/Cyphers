using System;
using System.CommandLine;
using System.CommandLine.Invocation;
using Ciphers.SubstitutionCiphers.Keyword;

namespace Ciphers.CLI.SubstitutionCiphers.Keyword
{
    public sealed class VigenereAutokeyCipherCommand : CipherCommand
    {
        private readonly VigenereAutokeyCipher cipher;

        public VigenereAutokeyCipherCommand()
            : base("vigenere-autokey", "Vigenere Autokey cipher.")
        {
            cipher = new VigenereAutokeyCipher();

            AddOption(new Option<string>(new string[] { "-k", "--keyword" }, "Keyword.")
            {
                IsRequired = true
            });

            Handler = CommandHandler.Create<string, string, string>(HandleCommand);
        }

        private void HandleCommand(string decode, string encode, string keyword)
        {
            cipher.SetKeyword(keyword);

            if (!string.IsNullOrEmpty(decode))
                Console.Write(cipher.Decode(decode));
            else if (!string.IsNullOrEmpty(encode))
                Console.Write(cipher.Encode(encode));
        }
    }
}
