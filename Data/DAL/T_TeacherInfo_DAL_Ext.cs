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
    partial class TeacherInfoDAL
    {
        public TeacherInfoModel Get(string UserName)
        {
            DataTable dt = SqlHelper.ExecuteDataTable("select * from T_TeacherInfo where UserName=@UserName", new MySqlParameter("@UserName", UserName));
            if (dt.Rows.Count <= 0)
            {
                return null;
            }
            else if (dt.Rows.Count == 1)
            {
                TeacherInfoModel model = new TeacherInfoModel();
                DataRow row = dt.Rows[0];
                model.id = new Guid(row["id"].ToString());
                model.Name = (string)row["Name"];
                model.UserName = (string)row["UserName"];
                model.Password = (string)row["Password"];
                model.TelYd = (string)GetNull(row["TelYd"]);
                model.TelDx = (string)GetNull(row["TelDx"]);
                model.TelGh = (string)GetNull(row["TelGh"]);
                model.TelLt = (string)GetNull(row["TelLt"]);
                model.EMail = (string)GetNull(row["EMail"]);
                model.IDCardNO = (string)GetNull(row["IDCardNO"]);
                model.Mark = (string)row["Mark"];
                model.LoginId = (Guid?)GetNull(row["LoginId"]);
                model.LoginOutTime = (DateTime?)GetNull(row["LoginOutTime"]);
                model.LoginIP = (string)GetNull(row["LoginIP"]);
                return model;
            }
            else
            {
                throw new Exception("出现多条数据！");
            }
        }
    }
}
