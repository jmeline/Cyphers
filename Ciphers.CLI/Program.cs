using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.CommandLine;
using System.CommandLine.Builder;
using System.CommandLine.Parsing;

namespace Ciphers.CLI
{
    public static class Program
    {
        static void Main(string[] args)
        {
            var host = CreateHost(args);
            var commandLineParser = BuildCommandLineParser(host.Services);

            commandLineParser.Invoke(args);
        }

        private static IHost CreateHost(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureServices(ConfigureServices)
                .Build();
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddCommands();
        }

        private static Parser BuildCommandLineParser(IServiceProvider serviceProvider)
        {
            var commandLineBuilder = new CommandLineBuilder();

            foreach (var command in serviceProvider.GetServices<Command>())
            {
                commandLineBuilder.AddCommand(command);
            }

            return commandLineBuilder
                .UseDefaults()
                .Build();
        }

        private static void AddCommands(this IServiceCollection services)
        {
            services.AddCipherCommands();
        }
    }
}
