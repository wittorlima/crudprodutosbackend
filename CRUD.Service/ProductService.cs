using CRUD.Domain.Entities;
using CRUD.Domain.Interfaces.Repositories;
using CRUD.Domain.Interfaces.Services;

namespace CRUD.Service
{
    public class ProductService : ServiceBase<Product>, IProductService
    {
        protected IProductRepository ProductRepository;

        public ProductService(IProductRepository productRepository) : base(productRepository)
        {
            this.ProductRepository = productRepository;
        }

    }
}
