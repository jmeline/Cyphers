using System;
using System.CommandLine.Invocation;

namespace Ciphers.CLI.MorseCode
{
    public sealed class MorseCodeCommand : CipherCommand
    {
        private readonly ICipher cipher;

        public MorseCodeCommand()
            : base("morse-code", "Morse code cipher.")
        {
            cipher = new Ciphers.MorseCode.MorseCode();

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
