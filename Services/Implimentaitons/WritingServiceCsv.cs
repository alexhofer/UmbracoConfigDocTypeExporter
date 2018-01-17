using System.Collections.Generic;
using System.IO;

using ServiceStack;

using UmbracoConfigDocTypeExporter.Services.Interfaces;

namespace UmbracoConfigDocTypeExporter.Services.Implimentaitons
{
    public class CsvWritingService : IWritingService
    {
        public void WriteToFile(string path, string siteName, string documentType, List<IDictionary<string, string>> data)
        {

            var csvOutput = data.ToCsv();

            File.WriteAllText($"{path}{siteName}_{documentType}.csv", csvOutput);
        }
    }
}
