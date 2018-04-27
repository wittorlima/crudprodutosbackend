using CRUD.Domain.Interfaces.Repositories;
using CRUD.Infra.Data.Repositories;
using StructureMap;

namespace CRUD.Infra.Data
{
    public class DataRegistry : Registry
    {
        public DataRegistry()
        {
            Scan(scan =>
            {
                scan.TheCallingAssembly();
                scan.WithDefaultConventions();
            });

            this.For<IProductRepository>().Use<ProductRepository>();
        }
    }
}
