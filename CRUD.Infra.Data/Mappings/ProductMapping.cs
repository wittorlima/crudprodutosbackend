
using CRUD.Domain.Entities;

namespace CRUD.Infra.Data.Mappings
{
    public class ProductMapping : EntityMapping<Product>
    {
        public ProductMapping()
        {
            Table("Product");

            Property(x => x.Description, mapper =>
            {
                mapper.Column("Description");
                mapper.Length(120);
                mapper.NotNullable(false);
            });

            Property(x => x.DatePurchased, mapper =>
            {
                mapper.Column("DatePurchased");
                mapper.Length(120);
                mapper.NotNullable(true);
            });

            Property(x => x.Image, mapper =>
            {
                mapper.Column("Image");
                mapper.NotNullable(false);
            });

            Property(x => x.Origin, mapper =>
            {
                mapper.Column("Origin");
            });

            Property(x => x.Price, mapper =>
            {
                mapper.Column("Price");
            });
        }
    }
}
