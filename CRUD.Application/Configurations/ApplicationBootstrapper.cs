using Nancy.Bootstrappers.StructureMap;
using StructureMap;

namespace CRUD.Application.Configurations
{
    public class ApplicationBootstrapper : StructureMapNancyBootstrapper
    {
        protected override void ConfigureApplicationContainer(IContainer existingContainer)
        {
            AutoMapperBootstrapper.Initialize();
            StructureMapContainer.Configure(existingContainer);
        }
    }
}

