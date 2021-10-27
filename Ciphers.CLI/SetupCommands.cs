using Ciphers.CLI.SubstitutionCiphers.Keyword;
using Microsoft.Extensions.DependencyInjection;
using System.CommandLine;

namespace Ciphers.CLI
{
    public static class SetupCommands
    {
        public static IServiceCollection AddCipherCommands(this IServiceCollection services)
        {
            services.AddSingleton<Command, MorseCode.MorseCodeCommand>();
            services.AddSingleton<Command, SubstitutionCiphers.Atbash.AtbashCipherCommand>();
            services.AddSingleton<Command, SubstitutionCiphers.Keyword.KeywordCipherCommand>();
            services.AddSingleton<Command, SubstitutionCiphers.ROT13.RotateBy13PlacesCipherCommand>();
            services.AddSingleton<Command, TranspositionCiphers.SpiralRouteCipherCommand>();
            services.AddSingleton<Command, VigenereAutokeyCipherCommand>();

            return services;
        }
    }
}
