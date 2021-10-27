using System;
using System.CommandLine.Invocation;
using Ciphers.TranspositionCiphers;

namespace Ciphers.CLI.SubstitutionCiphers.Keyword
{
    public sealed class RailFenceCipherCommand : CipherCommand
    {
        private readonly RailFenceCipher cipher;

        public RailFenceCipherCommand()
            : base("railfence", "Rail Fence cipher.")
        {
            cipher = new RailFenceCipher();

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
