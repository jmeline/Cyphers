using System;
using System.CommandLine;
using System.CommandLine.Invocation;
using Ciphers.RouteCipher;

namespace Ciphers.CLI.RouteCipher
{
    public sealed class SpiralRouteCipherCommand : CipherCommand
    {
        private readonly SpiralRouteCipher cipher;

        public SpiralRouteCipherCommand()
            : base("route-spiral", "Route Spiral cipher.")
        {
            cipher = new SpiralRouteCipher();

            AddOption(new Option<string>(new string[] { "-r", "--rows" }, "Rows of the spiral.")
            {
                IsRequired = true
            });

            AddOption(new Option<string>(new string[] { "-c", "--columns" }, "Columns of the spiral.")
            {
                IsRequired = true
            });

            Handler = CommandHandler.Create<string, string, int, int>(HandleCommand);
        }

        private void HandleCommand(string decode, string encode, int rows, int columns)
        {
            cipher.SetSpiralSize(rows, columns);

            if (!string.IsNullOrEmpty(decode))
                Console.Write(cipher.Decode(decode));
            else if (!string.IsNullOrEmpty(encode))
                Console.Write(cipher.Encode(encode));
        }
    }
}
