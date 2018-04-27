
using FluentMigrator;

namespace CRUD.Infra.Data.Migrations
{
    [Migration(1)]
    public class M0001_CreateDatabaseCrud : ForwardOnlyMigration
    {
        public override void Up()
        {
            Execute.Sql(@"CREATE DATABASE CRUD;");
        }
    }
}
