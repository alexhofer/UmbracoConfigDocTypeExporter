using System.Collections.Generic;
using System.Text;

using CommandLine;
using CommandLine.Text;

namespace UmbracoConfigDocTypeExporter.Services
{
    public class Options
    {
        [Option('u', "umbracoConfig", Required = true, HelpText = "The Umbraco Config file being used for export. [Error Code: 1 if document cannot be loaded.]")]
        public string ConfigLocation { get; set; }

        [Option('d', "documentType", Required = true, HelpText = "The Umbraco Document Type to export. All properties will be exported.")]
        public string DocumentType { get; set; }

        [Option('s', "siteName", Required = true, HelpText = "The name of the site the Umbraco config is for.")]
        public string SiteName { get; set; }

        [Option('o', "outputFolder", Required = true, HelpText = "The folder where the output will be saved.")]
        public string OutputFolder { get; set; }

        [OptionArray('p', "propertiesToInclude", Required = false, HelpText = "Specifies properties to export, if empty it will export all properties. Ex. -p hotdog notHotdog")]
        public string[] PropertiesToInclude { get; set; }

        [OptionArray('x', "propertiesToExclude", Required = false, HelpText = "Specifies properties to exclude from export, if empty it will export all properties. Ex. -p notHotdog hotdog")]
        public string[] PropertiesToExclude { get; set; }

        [OptionList('f', "filterByProperty", Required = false, HelpText = "Filters by a specific property for the document type. Only one filter is supported at this time. Ex. -f productSize:large")]
        public List<string> FilterByProperty { get; set; }

        [HelpOption]
        public string GetUsage()
        {
            var help = new StringBuilder();

            help.AppendLine(HelpText.AutoBuild(this,
              current => HelpText.DefaultParsingErrorsHandler(this, current)));

            help.AppendLine("Error Codes listed below:");
            help.AppendLine("[Error Code: 0] - Error....SUCCESS.");
            help.AppendLine("[Error Code: 1] - Document Load Error, I.E. something is wrong with the config file and it couldn't be loaded.");
            help.AppendLine("[Error Code: 2] - Incorrect Options. The Options could not be parsed for some reason.");

            return help.ToString();
        }
    }
}
