using System.CommandLine;

namespace Ciphers.CLI
{
    public abstract class CipherCommand : Command
    {
        public CipherCommand(string name, string description)
            : base(name, description)
        {
            AddOption(new Option<string>(new string[] { "-d", "--decode" }));
            AddOption(new Option<string>(new string[] { "-e", "--encode" }));
            AddValidator((result) =>
            {
                var hasDecodeOption = result.Children.Contains("-d") || result.Children.Contains("--decode");
                var hasEncodeOption = result.Children.Contains("-e") || result.Children.Contains("--encode");

                if (!(hasDecodeOption ^ hasEncodeOption))
                    return "You must specify either the 'decode' or 'encode' option.";

                return null;
            });
        }
    }
}
