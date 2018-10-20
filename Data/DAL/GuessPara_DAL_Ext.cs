using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Data.OleDb;

namespace Data
{
    partial class GuessParaDAL
    {
        public int Delete()
        {
            return SqlHelper.ExecuteNonQuery("delete from GuessPara");
        }
    }
}
