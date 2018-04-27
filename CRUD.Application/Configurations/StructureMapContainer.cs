using CRUD.Infra.Data;
using CRUD.Service;
using StructureMap;

namespace CRUD.Application.Configurations
{
    public class StructureMapContainer
    {
        public static void Configure(IContainer container)
        {
            container.Configure(o => {
                o.AddRegistry<DataRegistry>();
                o.AddRegistry<NhibernateRegistry>();
                o.AddRegistry<ServiceRegister>();
            });

            container.Configure(o => o.Scan(s =>
            {
                s.TheCallingAssembly();
                s.WithDefaultConventions();
                s.LookForRegistries();
            }));
        }
    }
}