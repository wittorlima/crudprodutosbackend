using CRUD.Infra.Data.Mappings;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Cfg.MappingSchema;
using NHibernate.Dialect;
using NHibernate.Mapping.ByCode;
using StructureMap;
using System.Data;
using System.Reflection;

namespace CRUD.Infra.Data
{
    public class NhibernateRegistry : Registry
    {

        public static ISessionFactory SessionFactory { get; internal set; }

        public NhibernateRegistry()
        {
            this.For<ISessionFactory>().Singleton().Use(ObterSessionFactory());
            For<ISession>().Use(
                x => x.GetInstance<ISessionFactory>().OpenSession(new NHLogger()));
        }

        private static ISessionFactory ObterSessionFactory()
        {
            var cfg = new Configuration();
            var mappings = GetMappings();

            cfg.DataBaseIntegration(db =>
            {
                db.Dialect<MySQLDialect>();
                db.BatchSize = 10;
                db.ConnectionStringName = "DevEnv";
                db.IsolationLevel = IsolationLevel.ReadCommitted;
                db.LogFormattedSql = true;
                db.LogSqlInConsole = false;
            });

            cfg.AddDeserializedMapping(mappings, "NHibernateMappings");

            SessionFactory = cfg.BuildSessionFactory();

            return SessionFactory;

        }

        private static HbmMapping GetMappings()
        {
            var mapper = new ModelMapper();
            var mappingTypes = Assembly.GetAssembly(typeof(ProductMapping)).GetExportedTypes();

            mapper.AddMappings(mappingTypes);

            var mapping = mapper.CompileMappingForAllExplicitlyAddedEntities();

            return mapping;
        }
    }
}
