using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Data.OleDb;
using MySql.Data.MySqlClient;

namespace Data
{
    partial class ClassDAL
    {
        public ClassModel GetByTeaID(Guid id)
        {
            DataTable dt = SqlHelper.ExecuteDataTable("select * from T_Class where TeacherId=@TeacherId",
                new MySqlParameter("TeacherId", id));
            if (dt.Rows.Count <= 0)
            {
                return null;
            }
            else if (dt.Rows.Count == 1)
            {
                ClassModel model = new ClassModel();
                DataRow row = dt.Rows[0];
                model.id = new Guid(row["id"].ToString());
                model.TeacherId = new Guid(row["TeacherId"].ToString());
                model.ClassName = (string)row["ClassName"];
                model.Year = (string)row["Year"];
                model.Remark = (string)GetNull(row["Remark"]);
                return model;
            }
            else
            {
                throw new Exception("出现多条数据！");
            }
        }
    }
}
