using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace Data
{
    partial class StudentInfoDAL
    {
        public StudentInfoModel GetByCrdId(string id)
        {
            DataTable dt = SqlHelper.ExecuteDataTable("select * from T_StudentInfo where IDCardNO=@id",
                new MySqlParameter("id", id));
            if (dt.Rows.Count <= 0)
            {
                return null;
            }
            else if (dt.Rows.Count == 1)
            {
                StudentInfoModel model = new StudentInfoModel();
                DataRow row = dt.Rows[0];
                model.id = new Guid(row["id"].ToString());
                model.UserName = (string)row["UserName"];
                model.PassWord = (string)row["PassWord"];
                model.Name = (string)row["Name"];
                model.NamePY = (string)GetNull(row["NamePY"]);
                model.HaveBY = Convert.ToBoolean(row["HaveBY"]);
                model.Sex = (string)GetNull(row["Sex"]);
                model.IDCardNO = (string)GetNull(row["IDCardNO"]);
                model.HomeAddress = (string)GetNull(row["HomeAddress"]);
                model.SchoolRollNO = (string)GetNull(row["SchoolRollNO"]);
                model.NowGuardian = null;
                model.IsStayAtHomeChild = Convert.ToBoolean(row["IsStayAtHomeChild"]);
                model.IsMigrants = Convert.ToBoolean(row["IsMigrants"]);
                model.IsDeLess = Convert.ToBoolean(row["IsDeLess"]);
                model.IsHeartLess = Convert.ToBoolean(row["IsHeartLess"]);
                model.IsPoor = Convert.ToBoolean(row["IsPoor"]);
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
