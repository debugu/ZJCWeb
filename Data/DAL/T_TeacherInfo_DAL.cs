using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Data
{
    partial class TeacherInfoDAL
    {
        public int AddNew(TeacherInfoModel model)
        {
            object obj = SqlHelper.ExecuteScalar("insert into T_TeacherInfo(id,Name,UserName,Password,TelYd,TelDx,TelGh,TelLt,EMail,IDCardNO,Mark,LoginId,LoginOutTime,LoginIP) values(@id,@Name,@UserName,@Password,@TelYd,@TelDx,@TelGh,@TelLt,@EMail,@IDCardNO,@Mark,@LoginId,@LoginOutTime,@LoginIP )",
                            new SqlParameter("id", model.id),
                            new SqlParameter("Name", model.Name),
                            new SqlParameter("UserName", model.UserName),
                            new SqlParameter("Password", model.Password),
                            new SqlParameter("TelYd", PutNull(model.TelYd)),
                            new SqlParameter("TelDx", PutNull(model.TelDx)),
                            new SqlParameter("TelGh", PutNull(model.TelGh)),
                            new SqlParameter("TelLt", PutNull(model.TelLt)),
                            new SqlParameter("EMail", PutNull(model.EMail)),
                            new SqlParameter("IDCardNO", PutNull(model.IDCardNO)),
                            new SqlParameter("Mark", model.Mark),
                            new SqlParameter("LoginId", PutNull(model.LoginId)),
                            new SqlParameter("LoginOutTime", PutNull(model.LoginOutTime)),
                            new SqlParameter("LoginIP", PutNull(model.LoginIP)));
            return Convert.ToInt32(obj);
        }

        public int Delete(Guid id)
        {
            return SqlHelper.ExecuteNonQuery("delete from T_TeacherInfo where id=@id",
                new SqlParameter("id",id));
        }

        public int Update(TeacherInfoModel model)
        {
            object obj = SqlHelper.ExecuteScalar("update T_TeacherInfo set Name=@Name,UserName=@UserName,Password=@Password,TelYd=@TelYd,TelDx=@TelDx,TelGh=@TelGh,TelLt=@TelLt,EMail=@EMail,IDCardNO=@IDCardNO,Mark=@Mark,LoginId=@LoginId,LoginOutTime=@LoginOutTime,LoginIP=@LoginIP where id=@id",
                            new SqlParameter("Name", model.Name),
                            new SqlParameter("UserName", model.UserName),
                            new SqlParameter("Password", model.Password),
                            new SqlParameter("TelYd", PutNull(model.TelYd)),
                            new SqlParameter("TelDx", PutNull(model.TelDx)),
                            new SqlParameter("TelGh", PutNull(model.TelGh)),
                            new SqlParameter("TelLt", PutNull(model.TelLt)),
                            new SqlParameter("EMail", PutNull(model.EMail)),
                            new SqlParameter("IDCardNO", PutNull(model.IDCardNO)),
                            new SqlParameter("Mark", model.Mark),
                            new SqlParameter("LoginId", PutNull(model.LoginId)),
                            new SqlParameter("LoginOutTime", PutNull(model.LoginOutTime)),
                            new SqlParameter("LoginIP", PutNull(model.LoginIP)),
                new SqlParameter("id",model.id));
            return Convert.ToInt32(obj);
        }
        public TeacherInfoModel Get(Guid id)
        {
            DataTable dt = SqlHelper.ExecuteDataTable("select * from T_TeacherInfo where id=@id",
                new SqlParameter("id",id));
            if (dt.Rows.Count <= 0)
            {
                return null;
            }
            else if (dt.Rows.Count == 1)
            {
                TeacherInfoModel model = new TeacherInfoModel();
                DataRow row = dt.Rows[0];
                model.id= (Guid)row["id"];
                model.Name= (string)row["Name"];
                model.UserName= (string)row["UserName"];
                model.Password= (string)row["Password"];
                model.TelYd= (string)GetNull(row["TelYd"]);
                model.TelDx= (string)GetNull(row["TelDx"]);
                model.TelGh= (string)GetNull(row["TelGh"]);
                model.TelLt= (string)GetNull(row["TelLt"]);
                model.EMail= (string)GetNull(row["EMail"]);
                model.IDCardNO= (string)GetNull(row["IDCardNO"]);
                model.Mark= (string)row["Mark"];
                model.LoginId= (Guid?)GetNull(row["LoginId"]);
                model.LoginOutTime= (DateTime?)GetNull(row["LoginOutTime"]);
                model.LoginIP= (string)GetNull(row["LoginIP"]);
                return model;
            }
            else
            {
                throw new Exception("出现多条数据！");
            }
        }

        public IEnumerable<TeacherInfoModel> GetAll()
        {
            DataTable dt = SqlHelper.ExecuteDataTable("select * from T_TeacherInfo");
            List<TeacherInfoModel> list = new List<TeacherInfoModel>();
            foreach (DataRow row in dt.Rows)
            {
                TeacherInfoModel model = new TeacherInfoModel();
                model.id= (Guid)row["id"];
                model.Name= (string)row["Name"];
                model.UserName= (string)row["UserName"];
                model.Password= (string)row["Password"];
                model.TelYd= (string)GetNull(row["TelYd"]);
                model.TelDx= (string)GetNull(row["TelDx"]);
                model.TelGh= (string)GetNull(row["TelGh"]);
                model.TelLt= (string)GetNull(row["TelLt"]);
                model.EMail= (string)GetNull(row["EMail"]);
                model.IDCardNO= (string)GetNull(row["IDCardNO"]);
                model.Mark= (string)row["Mark"];
                model.LoginId= (Guid?)GetNull(row["LoginId"]);
                model.LoginOutTime= (DateTime?)GetNull(row["LoginOutTime"]);
                model.LoginIP= (string)GetNull(row["LoginIP"]);
                list.Add(model);
            }
            return list;
        }

        public object GetNull(object value)//取空值处理
        {
            if (value == DBNull.Value)
            {
                return null;
            }
            else
            {
                return value;
            }
        }

        public object PutNull(object value)//赋空值处理
        {
            if (value == null)
            {
                return DBNull.Value;
            }
            else
            {
                return value;
            }
        } 

    }
}
