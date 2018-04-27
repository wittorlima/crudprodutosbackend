using FluentMigrator;

namespace CRUD.Infra.Data.Migrations
{
    [Migration(2)]
    public class M0002_CreateTableProduct : ForwardOnlyMigration
    {
        public override void Up()
        {
            Execute.Sql(@"USE CRUD;
                            CREATE TABLE Product(
                            Id INTEGER UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
                            Description TEXT,
                            Image 	LONGBLOB ,
                            DatePurchased DateTime,
                            Price DECIMAL(18,2),
                            Origin int
                            );");
        }
    }
}
