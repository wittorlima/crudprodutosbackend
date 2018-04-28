using AutoMapper;
using CRUD.Application.Configurations.AutoMapper;

namespace CRUD.Application.Configurations
{
    public class AutoMapperBootstrapper
    {
        public static void Initialize()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<ProductMappingProfile>();
            });
        }
    }
}