using System;
using System.Configuration;

namespace CRUD.Domain.Util
{
    public class QuerySettings
    {
        public QuerySettings()
        {
            this.Page = 1;
            this.RecordPerPage = Convert.ToInt32(ConfigurationManager.AppSettings["RecordsPerPage"]);
        }

        public QuerySettings(int page) : this()
        {
            this.Page = page;
        }

        public int Page { get; set; }

        public int RecordPerPage { get; set; }

        public int TotalRecord { get; set; }
    }
}
