using System;
using System.Collections.Generic;
using System.Linq;

using UmbracoConfigDocTypeExporter.Models;
using UmbracoConfigDocTypeExporter.Services.Interfaces;

namespace UmbracoConfigDocTypeExporter.Services.Implimentaitons
{
    public class PropertyFilterService : IPropertyFilterService
    {
        public List<GenericDocumentProperties> FilterPropertiesFromOptions(List<GenericDocumentProperties> propertyList, string[] propertiesToInclude, string[] propertiesToExclude)
        {

            if(propertiesToExclude != null)
            {
                propertyList = propertyList.Where(x => propertiesToExclude.Any(a => !x.Property.Contains(a))).ToList();
            }

            if(propertiesToInclude != null)
            {
                propertyList = propertyList.Where(x => propertiesToInclude.Any(a => x.Property.Contains(a))).ToList();
            }

            return propertyList;
        }

        public bool PropertyListContainsValue(IDictionary<string, string> dictionary, List<string> filterByProperties)
        {
            if (filterByProperties?.Count != 2)
                return false;

            if (!dictionary.TryGetValue(filterByProperties[0], out var actualValue))
            {
                return false;
            }

            var output = string.Equals(actualValue, filterByProperties[1], StringComparison.InvariantCulture);

            return output;
        }
    }
}
