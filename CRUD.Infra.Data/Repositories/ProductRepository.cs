using CRUD.Domain.Entities;
using CRUD.Domain.Interfaces.Repositories;
using NHibernate;

namespace CRUD.Infra.Data.Repositories
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(ISession session) : base(session)
        {

        }
    }
}
