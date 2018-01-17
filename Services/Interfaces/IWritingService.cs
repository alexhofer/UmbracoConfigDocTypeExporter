using System.Collections.Generic;

namespace UmbracoConfigDocTypeExporter.Services.Interfaces
{
    public interface IWritingService
    {
        void WriteToFile(string path, string siteName, string documentType, List<IDictionary<string, string>> data);
    }
}
