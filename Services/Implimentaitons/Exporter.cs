using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

using Humanizer;

using ServiceStack;

using UmbracoConfigDocTypeExporter.Models;
using UmbracoConfigDocTypeExporter.Services.Interfaces;

namespace UmbracoConfigDocTypeExporter.Services.Implimentaitons
{
    public class Exporter : IExporter
    {
        private readonly IPropertyFilterService _propertyFilterService;
        private readonly IRelatedNodeService _relatedNodeService;

        public Exporter(IPropertyFilterService propertyFilterService, IRelatedNodeService relatedNodeService)
        {
            _propertyFilterService = propertyFilterService;
            _relatedNodeService = relatedNodeService;
        }
        public List<IDictionary<string, string>> Export(Options options)
        {
            var umbracoConfig = XDocument.Load(options.ConfigLocation);

            if (umbracoConfig.Document == null)
                return null;

            Console.WriteLine("Loading Umbraco Config file.");
            var documentTypeXml = umbracoConfig.Document.Descendants(options.DocumentType);
            var output = new List<IDictionary<string, string>>();

            foreach (var documentXml in documentTypeXml)
            {
                var documentPropertyList = documentXml.Elements()
                    .Select(x => new GenericDocumentProperties
                    {
                        Property = $"{x.Name.ToString()}{x.Attribute("nodeName")?.Value.ToTitleCase()}",
                        Value = (string)x
                    }).ToList();

                documentPropertyList = _propertyFilterService.FilterPropertiesFromOptions(documentPropertyList, options.PropertiesToInclude, options.PropertiesToExclude); 

                IDictionary<string, string> propertyList = new Dictionary<string, string>();
                foreach (var property in documentPropertyList)
                {
                    Console.WriteLine($"Adding properties for {property.Property}");

                    var nodeIds = property.Value.Split(',').ToList();
                    var relatedNodes = _relatedNodeService.GetRelatedNodesAsString(nodeIds, umbracoConfig);

                    if (relatedNodes != string.Empty)
                    {
                        property.Value = relatedNodes;
                    }

                    propertyList.Add(property.Property, property.Value);

                }

                if (options.FilterByProperty != null && _propertyFilterService.PropertyListContainsValue(propertyList, options.FilterByProperty))
                {
                    propertyList = propertyList.ToDictionary(x => x.Key.Humanize(), x => x.Value);
                    output.Add(propertyList);
                }
                else if (options.FilterByProperty == null)
                {
                    propertyList = propertyList.ToDictionary(x => x.Key.Humanize(), x => x.Value);
                    output.Add(propertyList);
                }                    
            }

            return output;
        }
    }
}
