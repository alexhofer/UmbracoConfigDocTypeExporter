using System.Collections.Generic;
using System.Xml.Linq;

namespace UmbracoConfigDocTypeExporter.Services.Interfaces
{
    public interface IRelatedNodeService
    {
        string GetRelatedNodesAsString(List<string> nodes, XDocument umbracoConfig);
    }
}
