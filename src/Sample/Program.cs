using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Sample
{
    /// <summary>
    /// Class containing the static void main (program entrypoint).
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Program entrypoint
        /// </summary>
        /// <param name="args">Received arguments from command line.</param>
        public static void Main(string[] args)
        {
            try
            {

                // Get configs from args, env-vars and json file.
                var config = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("hostsettings.json",optional: true, reloadOnChange: true)
                    .AddEnvironmentVariables(prefix: "SAMPLE_")
                    .AddCommandLine(args)
                    .Build();

                // Setup logger.
                var loggerFactory = new LoggerFactory()
                    .AddConsole()
                    .AddDebug();

                // Start web api
                BuildWebHost(args, config).Run();
            }
            catch (Exception e)
            {
                Console.WriteLine("Unhandled exception:");
                Console.WriteLine(e);
            }
        }

        public static IWebHost BuildWebHost(string[] args, IConfiguration configuration) =>
            WebHost.CreateDefaultBuilder(args)
                .UseConfiguration(configuration)
                .UseStartup<Startup>()
                .Build();
    }
}

