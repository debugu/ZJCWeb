using System;
using System.Data;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace Data
{
    class SqlHelper
    {
        public static string connstr = "server=55b091c3adbb0.sh.cdb.myqcloud.com;port=6959;User ID=cdb_outerroot;Password=g123456789;Database=zjc;Charset=gbk";
        //public static string connstr = "server=10.66.149.119;port=3306;User ID=root;Password=g123456789;Database=StuInfo;Charset=gbk";
        public static int ExecuteNonQuery(string MySqlstr, params MySqlParameter[] parameter)
        {
             using (MySqlConnection conn = new MySqlConnection(connstr))
                {
                    conn.Open();
                    using (MySqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = MySqlstr;
                        cmd.Parameters.AddRange(parameter);
                        return cmd.ExecuteNonQuery();
                    }
                }
        }
        public static object ExecuteScalar(string MySqlstr, params MySqlParameter[] parameter)
        {
            using (MySqlConnection conn = new MySqlConnection(connstr))
                {
                    conn.Open();
                    using (MySqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = MySqlstr;
                        cmd.Parameters.AddRange(parameter);
                        return cmd.ExecuteScalar();
                    }
                }
        }
        public static object ExecuteScalar(string MySqlstr,CommandType type, params MySqlParameter[] parameter)
        {
            using (MySqlConnection conn = new MySqlConnection(connstr))
            {
                conn.Open();
                using (MySqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = MySqlstr;
                    cmd.CommandType = type;
                    cmd.Parameters.AddRange(parameter);
                    return cmd.ExecuteScalar();
                }
            }
        }       
        public static DataTable ExecuteDataTable(string MySqlstr, params MySqlParameter[] parameter)
        {
            using (MySqlConnection conn = new MySqlConnection(connstr))
                {
                    try
                    {
                        conn.Open();
                    }
                    catch (Exception e)
                    {
                        throw new Exception(e.Message.ToString() + "数据库连接错误，请检查数据库设置！");
                    }
                    using (MySqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = MySqlstr;
                        cmd.Parameters.AddRange(parameter);
                        DataSet ds = new DataSet();
                        MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                        adapter.Fill(ds);
                        return ds.Tables[0];
                    }
                }
        }

        public static DataTable ExecuteDataTable(string MySqlstr,CommandType type, params MySqlParameter[] parameter)
        {
            using (MySqlConnection conn = new MySqlConnection(connstr))
            {
                try
                {
                    conn.Open();
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message.ToString() + "数据库连接错误，请检查数据库设置！");
                }
                using (MySqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = MySqlstr;
                    cmd.CommandType = type;
                    cmd.Parameters.AddRange(parameter);
                    DataSet ds = new DataSet();
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    adapter.Fill(ds);
                    return ds.Tables[0];
                }
            }
        }

        //public static void BulkUp(string tablename, DataTable table)
        //{
        //    using (MySqlConnection conn = new MySqlConnection(connstr))
        //    {
        //        conn.Open();
        //        MySqlBulkCopy MySqlbulk = new MySqlBulkCopy(conn);
        //        MySqlbulk.DestinationTableName =tablename;
        //        MySqlbulk.WriteToServer(table);
        //    }
        //}

        /// <summary>
        /// DES解密
        /// </summary>
        /// <param name="encryptedString">密文</param>
        /// <param name="key">密钥</param>
        /// <param name="iv">向量</param>
        /// <returns></returns>
        #region DES解密
        private static string Decrypt(string encryptedString, string key, string iv)
        {
            byte[] btKey = Encoding.UTF8.GetBytes(key);
            byte[] btIV = Encoding.UTF8.GetBytes(iv);
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            using (MemoryStream ms = new MemoryStream())
            {
                byte[] inData = Convert.FromBase64String(encryptedString);
                try
                {
                    using (CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(btKey, btIV), CryptoStreamMode.Write))
                    {
                        cs.Write(inData, 0, inData.Length);
                        cs.FlushFinalBlock();
                    }
                    return Encoding.UTF8.GetString(ms.ToArray());
                }
                catch
                {
                    throw new Exception("解密失败！");
                }
            }
        }
        #endregion
    }
}
