using System;
using System.CommandLine;
using System.CommandLine.Invocation;
using Ciphers.TranspositionCiphers;

namespace Ciphers.CLI.SubstitutionCiphers.Keyword
{
    public sealed class ColumnarTranspositionCipherCommand : CipherCommand
    {
        private readonly ColumnarTranspositionCipher cipher;

        public ColumnarTranspositionCipherCommand()
            : base("columnar", "Columnar Transposition cipher.")
        {
            cipher = new ColumnarTranspositionCipher();

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
