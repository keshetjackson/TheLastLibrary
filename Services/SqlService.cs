using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Dapper;

namespace TheLastLibrary.Services
{
    /// <summary>
    /// not neccesey and not used , here for future updgrades, and dou to problems with the json service
    /// </summary>
    internal class SqlService
    {
        public SqlConnection _connection { get;}
        public SqlCommand _cmd;
        private SqlDataAdapter _adapter;
        public SqlDataReader _reader { get; set; }
        public DataTable _dataTable { get; set; }

        public SqlService()
        {
            _connection = new SqlConnection(@"Data Source=DESKTOP-9BRI5GA;Initial Catalog=LibraryDb;Integrated Security=True");
        }

        public void SqlQuery(string QueryText)
        {
            _cmd = new SqlCommand(QueryText, _connection);
        }

        public DataTable QueryEx()
        {
            _adapter = new SqlDataAdapter(_cmd);
            _dataTable = new DataTable();
            _adapter.Fill(_dataTable);
            return _dataTable;
        }
         public void NonQueryEx()
        {
            _cmd.ExecuteNonQuery();
        }

        

        //public bool InsertBulkRecords<T>(List<T> records)
        //{
        //    bool Inserted = false;
        //    return Inserted;
        //}

        //public DataTable GetTable<T>(List<T> records)
        //{
        //    var type = typeof(T);

        //    return _dataTable;
        //}
    }
}
