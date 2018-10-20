using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Data;

namespace Data
{
    class SqlHelper
    {
        public static string connstr ="Data Source=192.168.0.100;Initial Catalog=Zjc;User ID=sa;Password=Class?1;";
        public static int ExecuteNonQuery(string sqlstr, params SqlParameter[] parameter)
        {
             using (SqlConnection conn = new SqlConnection(connstr))
                {
                    conn.Open();
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = sqlstr;
                        cmd.Parameters.AddRange(parameter);
                        return cmd.ExecuteNonQuery();
                    }
                }
        }
        public static object ExecuteScalar(string sqlstr, params SqlParameter[] parameter)
        {
            using (SqlConnection conn = new SqlConnection(connstr))
                {
                    conn.Open();
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = sqlstr;
                        cmd.Parameters.AddRange(parameter);
                        return cmd.ExecuteScalar();
                    }
                }
        }
       
        public static DataTable ExecuteDataTable(string sqlstr, params SqlParameter[] parameter)
        {
            using (SqlConnection conn = new SqlConnection(connstr))
                {
                    conn.Open();
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = sqlstr;
                        cmd.Parameters.AddRange(parameter);
                        DataSet ds = new DataSet();
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(ds);
                        return ds.Tables[0];
                    }
                }
        }

        public static void BulkUp(string tablename, DataTable table)
        {
            using (SqlConnection conn = new SqlConnection(connstr))
            {
                conn.Open();
                SqlBulkCopy sqlbulk = new SqlBulkCopy(conn);
                sqlbulk.DestinationTableName =tablename;
                sqlbulk.WriteToServer(table);
            }
        }
    }
}
