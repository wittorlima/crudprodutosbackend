using CRUD.Infra.Data.Mappings;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Cfg.MappingSchema;
using NHibernate.Dialect;
using NHibernate.Mapping.ByCode;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Infra.Data
{
    /// <summary>
    /// Handles all the NHibernate's initialization process.
    /// </summary>
    public class NHibernateInitializer
    {
        /// <summary>
        /// Holds NHibernate configuration and Session creation.
        /// </summary>
        public static ISessionFactory SessionFactory { get; internal set; }

        /// <summary>
        /// Runs all procedures to let NHibernate ready for usage.
        /// </summary>
        public static void Init()
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

            //var schema = new SchemaExport(cfg);
            //schema.SetOutputFile("C:\\Teste\\sql.txt");
            //schema.Create(true, false);
        }

        /// <summary>
        /// Gets all mapping classes for the project.
        /// </summary>
        /// <returns></returns>
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
