

using CRUD.Domain.Interfaces.Services;
using StructureMap;

namespace CRUD.Service
{
    public class ServiceRegister : Registry
    {
        public ServiceRegister()
        {
            Scan(scan =>
            {
                scan.TheCallingAssembly();
                scan.WithDefaultConventions();
                scan.LookForRegistries();
            });

            this.For<IProductService>().Use<ProductService>();
        }
    }
}
