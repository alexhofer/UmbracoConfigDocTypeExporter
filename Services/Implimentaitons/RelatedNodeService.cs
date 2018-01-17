using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

using ServiceStack;

using UmbracoConfigDocTypeExporter.Services.Interfaces;

namespace UmbracoConfigDocTypeExporter.Services.Implimentaitons
{
    public class RelatedNodeService : IRelatedNodeService
    {
        public string GetRelatedNodesAsString(List<string> nodes, XDocument umbracoConfig)
        {
            //Quick way to make sure they are Umbraco node ID's.
            if (nodes.All(x => x.Length != 4))
            {
                return string.Empty;
            }

            var stringBuilder = new StringBuilder();

            foreach (var node in nodes)
            {
                var relatedNode = umbracoConfig
                                .Descendants()
                                .FirstOrDefault(x => string.Equals(x.Attribute("id")?.Value, node, StringComparison.InvariantCulture));

                if (relatedNode == null)
                    continue;
                
                var propertyString = relatedNode.Elements().Select(x => x.Value).Join();

                stringBuilder.Append(propertyString).Append("||");
                
            }

            return stringBuilder.ToString();
        }
    }
}
