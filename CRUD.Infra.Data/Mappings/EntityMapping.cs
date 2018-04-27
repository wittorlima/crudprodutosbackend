using CRUD.Domain.Entities;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Infra.Data.Mappings
{
    public class EntityMapping<T> : ClassMapping<T> where T : ModelBase
    {
        public EntityMapping()
        {
            Schema("emax");

            Id(x => x.Id, mapper =>
            {
                mapper.Generator(Generators.Increment);
                mapper.Column("id");
            });
        }
    }
}
