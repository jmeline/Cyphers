using Ciphers.SubstitutionCiphers.Keyword;
using System;
using System.CommandLine;
using System.CommandLine.Invocation;

namespace Ciphers.CLI.SubstitutionCiphers.Keyword
{
    public sealed class KeywordCipherCommand : CipherCommand
    {
        private readonly KeywordCipher cipher;

        public KeywordCipherCommand()
            : base("keyword", "Keyword cipher.")
        {
            cipher = new KeywordCipher();

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
