using System;
using System.CommandLine.Invocation;

namespace Ciphers.CLI.SubstitutionCiphers.ROT13
{
    public sealed class RotateBy13PlacesCipherCommand : CipherCommand
    {
        private readonly ICipher cipher;

        public RotateBy13PlacesCipherCommand()
            : base("rotate-13", "Rotate by 13 cipher.")
        {
            cipher = new Ciphers.SubstitutionCiphers.ROT13.RotateBy13PlacesCipher();

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
