using NHibernate;
using NHibernate.SqlCommand;
using System.Diagnostics;
using System.Linq;

namespace CRUD.Infra.Data
{
    public class NHLogger : EmptyInterceptor
    {
        public override SqlString OnPrepareStatement(SqlString sql)
        {
            Debug.WriteLine("------------------------------");
            Debug.WriteLine("NHIBERNATE: " + sql);

            if (sql.GetParameters().Any())
            {
                foreach (var parameter in sql.GetParameters())
                {
                    Debug.WriteLine(string.Format("parameter: {0} - valor: {1}", parameter.ParameterPosition, parameter.ToString()));
                }
            }
            Debug.WriteLine("------------------------------");

            return base.OnPrepareStatement(sql);
        }
    }
}
