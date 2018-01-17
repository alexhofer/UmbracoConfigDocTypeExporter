using System.Collections.Generic;

namespace UmbracoConfigDocTypeExporter.Services.Interfaces
{
    public interface IExporter
    {
        List<IDictionary<string, string>> Export(Options options);
    }
}
