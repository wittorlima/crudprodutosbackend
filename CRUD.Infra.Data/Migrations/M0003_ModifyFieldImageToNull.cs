
using FluentMigrator;

namespace CRUD.Infra.Data.Migrations
{
    [Migration(3)]
    public class M0003_ModifyFieldImageToNull : ForwardOnlyMigration
    {
        public override void Up()
        {
            Execute.Sql(@"Alter table Product modify  Image BLOB null;");
        }
    }
}
