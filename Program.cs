using System;

using Autofac;

using UmbracoConfigDocTypeExporter.AppStart;
using UmbracoConfigDocTypeExporter.Enums;
using UmbracoConfigDocTypeExporter.Services;
using UmbracoConfigDocTypeExporter.Services.Interfaces;

namespace UmbracoConfigDocTypeExporter
{
    class Program
    {
        static int Main(string[] args)
        {
            var container = AutofacConfig.RegisterDependencies();
            var options = new Options();

            if (CommandLine.Parser.Default.ParseArguments(args, options))
            {
                using (var scope = container.BeginLifetimeScope())
                {
                    var exporter = scope.Resolve<IExporter>();
                    var csvWritingService = scope.Resolve<IWritingService>();

                    var exportData = exporter.Export(options);

                    if (exportData != null)
                    {
                        Console.WriteLine("Writing Data to file...");
                        csvWritingService.WriteToFile(options.OutputFolder, options.SiteName, options.DocumentType, exportData);
                        Console.WriteLine("Export Complete.");
                        Console.ReadLine();
                        return (int)ErrorCodes.Success;
                    }

                    Console.WriteLine("Export Failed.");
                    Console.ReadLine();
                    return (int)ErrorCodes.DocumentLoadFailure;
                }
            }

            Console.ReadLine();
            return (int)ErrorCodes.IncorrectOptions;
        }
    }
}
