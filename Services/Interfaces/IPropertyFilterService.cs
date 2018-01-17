using System.Collections.Generic;

using UmbracoConfigDocTypeExporter.Models;

namespace UmbracoConfigDocTypeExporter.Services.Interfaces
{
    public interface IPropertyFilterService
    {
        List<GenericDocumentProperties> FilterPropertiesFromOptions(List<GenericDocumentProperties> propertyList, string[] propertiesToInclude, string[] propertiesToExclude);

        bool PropertyListContainsValue(IDictionary<string, string> dictionary, List<string> filterByProperties);
    }
}
