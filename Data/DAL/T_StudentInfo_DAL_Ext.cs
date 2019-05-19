using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
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

        public StudentInfoModel GetByUserName(string username)
        {
            DataTable dt = SqlHelper.ExecuteDataTable("select * from T_StudentInfo where UserName=@UserName",
                new MySqlParameter("UserName", username));
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

        public IEnumerable<WanChengQingkuangModel> GetWanChengQingKuang(string className)
        {
            DataTable dt = SqlHelper.ExecuteDataTable("SELECT id,`Name`,UserName,HaveBY,r.num FROM T_StudentInfo as s LEFT JOIN (SELECT StuId,count(StuId) as num from T_StuRelationship GROUP BY StuId) as r on s.id=r.StuId where UserName=@UserName",
                new MySqlParameter("UserName", className));
            List<WanChengQingkuangModel> list = new List<WanChengQingkuangModel>();
            foreach (DataRow row in dt.Rows)
            {
                WanChengQingkuangModel model = new WanChengQingkuangModel();
                model.id = new Guid(row["id"].ToString());
                model.StuName = (string)row["Name"];
                if (Convert.ToBoolean(row["HaveBY"]))
                {
                    model.WanCheng = "已完成";
                }
                else
                {
                    model.WanCheng = "未完成";
                }
                if (row["num"] == DBNull.Value)
                {
                    model.JhNum = 0;
                }
                else
                {
                    model.JhNum = Convert.ToInt32(row["num"]);
                }
                
                list.Add(model);
            }
            return list;
        }

        public WanChengQingkuangModel GetNumberOfRelationship(string idcardno)
        {
            DataTable dt1 = SqlHelper.ExecuteDataTable("SELECT id FROM T_StudentInfo where IDCardNO=@IDCardNO",
                new MySqlParameter("IDCardNO", idcardno));
            WanChengQingkuangModel model = new WanChengQingkuangModel();
            model.id = new Guid(dt1.Rows[0]["id"].ToString());
            model.JhNum = Convert.ToInt32(SqlHelper.ExecuteScalar("SELECT count(*) from T_StuRelationship where StuId=@StuId",
                new MySqlParameter("StuId", model.id)));
            return model;
        }

        public int SetRelationInserted(Guid id)
        {
            object obj = SqlHelper.ExecuteScalar("update T_StudentInfo set HaveBY=1 where id=@id",                        
                new MySqlParameter("id", id.ToString()));
            return Convert.ToInt32(obj);
        }
    }
}
