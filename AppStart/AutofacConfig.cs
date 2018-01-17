using Autofac;

using UmbracoConfigDocTypeExporter.Services.Implimentaitons;
using UmbracoConfigDocTypeExporter.Services.Interfaces;

namespace UmbracoConfigDocTypeExporter.AppStart
{
    public class AutofacConfig
    {
        public static IContainer RegisterDependencies()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<Exporter>().As<IExporter>();
            builder.RegisterType<PropertyFilterService>().As<IPropertyFilterService>();
            builder.RegisterType<RelatedNodeService>().As<IRelatedNodeService>();
            builder.RegisterType<CsvWritingService>().As<IWritingService>();

            return builder.Build();
        }
    }
}
