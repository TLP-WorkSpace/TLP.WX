using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace WCP_DealCommon
{
    public class SqlConnections
    {
        public MySqlConnection Connection;

        public string Connectionstr { get; set; }

        public SqlConnections(string connectionstr)
        {
            Connectionstr = connectionstr;
            Connection = GetMySqlConnection();
        }

        private MySqlConnection GetMySqlConnection(bool open = true,
            bool convertZeroDatetime = false, bool allowZeroDatetime = false)
        {

            string cs = Connectionstr;
            var csb = new MySqlConnectionStringBuilder(cs)
            {
                AllowZeroDateTime = allowZeroDatetime,
                ConvertZeroDateTime = convertZeroDatetime
            };
            var conn = new MySqlConnection(csb.ConnectionString);
            if (open) conn.Open();
            return conn;
        }
    }
}
