using MySql.Data.MySqlClient;
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
                            new MySqlParameter("id", model.id),
                            new MySqlParameter("Name", model.Name),
                            new MySqlParameter("UserName", model.UserName),
                            new MySqlParameter("Password", model.Password),
                            new MySqlParameter("TelYd", PutNull(model.TelYd)),
                            new MySqlParameter("TelDx", PutNull(model.TelDx)),
                            new MySqlParameter("TelGh", PutNull(model.TelGh)),
                            new MySqlParameter("TelLt", PutNull(model.TelLt)),
                            new MySqlParameter("EMail", PutNull(model.EMail)),
                            new MySqlParameter("IDCardNO", PutNull(model.IDCardNO)),
                            new MySqlParameter("Mark", model.Mark),
                            new MySqlParameter("LoginId", PutNull(model.LoginId)),
                            new MySqlParameter("LoginOutTime", PutNull(model.LoginOutTime)),
                            new MySqlParameter("LoginIP", PutNull(model.LoginIP)));
            return Convert.ToInt32(obj);
        }

        public int Delete(Guid id)
        {
            return SqlHelper.ExecuteNonQuery("delete from T_TeacherInfo where id=@id",
                new MySqlParameter("id",id));
        }

        public int Update(TeacherInfoModel model)
        {
            object obj = SqlHelper.ExecuteScalar("update T_TeacherInfo set Name=@Name,UserName=@UserName,Password=@Password,TelYd=@TelYd,TelDx=@TelDx,TelGh=@TelGh,TelLt=@TelLt,EMail=@EMail,IDCardNO=@IDCardNO,Mark=@Mark,LoginId=@LoginId,LoginOutTime=@LoginOutTime,LoginIP=@LoginIP where id=@id",
                            new MySqlParameter("Name", model.Name),
                            new MySqlParameter("UserName", model.UserName),
                            new MySqlParameter("Password", model.Password),
                            new MySqlParameter("TelYd", PutNull(model.TelYd)),
                            new MySqlParameter("TelDx", PutNull(model.TelDx)),
                            new MySqlParameter("TelGh", PutNull(model.TelGh)),
                            new MySqlParameter("TelLt", PutNull(model.TelLt)),
                            new MySqlParameter("EMail", PutNull(model.EMail)),
                            new MySqlParameter("IDCardNO", PutNull(model.IDCardNO)),
                            new MySqlParameter("Mark", model.Mark),
                            new MySqlParameter("LoginId", PutNull(model.LoginId)),
                            new MySqlParameter("LoginOutTime", PutNull(model.LoginOutTime)),
                            new MySqlParameter("LoginIP", PutNull(model.LoginIP)),
                new MySqlParameter("id",model.id));
            return Convert.ToInt32(obj);
        }
        public TeacherInfoModel Get(Guid id)
        {
            DataTable dt = SqlHelper.ExecuteDataTable("select * from T_TeacherInfo where id=@id",
                new MySqlParameter("id",id));
            if (dt.Rows.Count <= 0)
            {
                return null;
            }
            else if (dt.Rows.Count == 1)
            {
                TeacherInfoModel model = new TeacherInfoModel();
                DataRow row = dt.Rows[0];
                model.id= new Guid(row["id"].ToString());
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
                model.id= new Guid(row["id"].ToString());
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
