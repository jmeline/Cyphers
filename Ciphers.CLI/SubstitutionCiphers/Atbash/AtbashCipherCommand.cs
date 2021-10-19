using System;
using System.CommandLine.Invocation;

namespace Ciphers.CLI.SubstitutionCiphers.Atbash
{
    public sealed class AtbashCipherCommand : CipherCommand
    {
        private readonly ICipher cipher;

        public AtbashCipherCommand()
            : base("atbash", "Atbash cipher.")
        {
            cipher = new Ciphers.SubstitutionCiphers.Atbash.AtbashCipher();

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
