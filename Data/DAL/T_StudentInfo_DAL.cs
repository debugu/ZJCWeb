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
    partial class StudentInfoDAL
    {
        public int AddNew(StudentInfoModel model)
        {
            object obj = SqlHelper.ExecuteScalar("insert into T_StudentInfo(id,UserName,PassWord,Name,NamePY,HaveBY,Sex,IDCardNO,HomeAddress,SchoolRollNO,NowGuardian,IsStayAtHomeChild,IsMigrants,IsDeLess,IsHeartLess,IsPoor,Remark) values(@id,@UserName,@PassWord,@Name,@NamePY,@HaveBY,@Sex,@IDCardNO,@HomeAddress,@SchoolRollNO,@NowGuardian,@IsStayAtHomeChild,@IsMigrants,@IsDeLess,@IsHeartLess,@IsPoor,@Remark )",
                            new MySqlParameter("id", model.id.ToString()),
                            new MySqlParameter("UserName", model.UserName),
                            new MySqlParameter("PassWord", model.PassWord),
                            new MySqlParameter("Name", model.Name),
                            new MySqlParameter("NamePY", PutNull(model.NamePY)),
                            new MySqlParameter("HaveBY", model.HaveBY),
                            new MySqlParameter("Sex", PutNull(model.Sex)),
                            new MySqlParameter("IDCardNO", PutNull(model.IDCardNO)),
                            new MySqlParameter("HomeAddress", PutNull(model.HomeAddress)),
                            new MySqlParameter("SchoolRollNO", PutNull(model.SchoolRollNO)),
                            new MySqlParameter("NowGuardian", PutNull(model.NowGuardian).ToString()),
                            new MySqlParameter("IsStayAtHomeChild", model.IsStayAtHomeChild),
                            new MySqlParameter("IsMigrants", model.IsMigrants),
                            new MySqlParameter("IsDeLess", model.IsDeLess),
                            new MySqlParameter("IsHeartLess", model.IsHeartLess),
                            new MySqlParameter("IsPoor", model.IsPoor),
                            new MySqlParameter("Remark", PutNull(model.Remark)));
            return Convert.ToInt32(obj);
        }

        public int Delete(Guid id)
        {
            return SqlHelper.ExecuteNonQuery("delete from T_StudentInfo where id=@id",
                new MySqlParameter("id",id));
        }

        public int Update(StudentInfoModel model)
        {
            object obj = SqlHelper.ExecuteScalar("update T_StudentInfo set UserName=@UserName,PassWord=@PassWord,Name=@Name,NamePY=@NamePY,HaveBY=@HaveBY,Sex=@Sex,IDCardNO=@IDCardNO,HomeAddress=@HomeAddress,SchoolRollNO=@SchoolRollNO,NowGuardian=@NowGuardian,IsStayAtHomeChild=@IsStayAtHomeChild,IsMigrants=@IsMigrants,IsDeLess=@IsDeLess,IsHeartLess=@IsHeartLess,IsPoor=@IsPoor,Remark=@Remark where id=@id",
                            new MySqlParameter("UserName", model.UserName),
                            new MySqlParameter("PassWord", model.PassWord),
                            new MySqlParameter("Name", model.Name),
                            new MySqlParameter("NamePY", PutNull(model.NamePY)),
                            new MySqlParameter("HaveBY", model.HaveBY),
                            new MySqlParameter("Sex", PutNull(model.Sex)),
                            new MySqlParameter("IDCardNO", PutNull(model.IDCardNO)),
                            new MySqlParameter("HomeAddress", PutNull(model.HomeAddress)),
                            new MySqlParameter("SchoolRollNO", PutNull(model.SchoolRollNO)),
                            new MySqlParameter("NowGuardian", PutNull(model.NowGuardian).ToString()),
                            new MySqlParameter("IsStayAtHomeChild", model.IsStayAtHomeChild),
                            new MySqlParameter("IsMigrants", model.IsMigrants),
                            new MySqlParameter("IsDeLess", model.IsDeLess),
                            new MySqlParameter("IsHeartLess", model.IsHeartLess),
                            new MySqlParameter("IsPoor", model.IsPoor),
                            new MySqlParameter("Remark", PutNull(model.Remark)),
                new MySqlParameter("id",model.id.ToString()));
            return Convert.ToInt32(obj);
        }
        public StudentInfoModel Get(Guid id)
        {
            DataTable dt = SqlHelper.ExecuteDataTable("select * from T_StudentInfo where id=@id",
                new MySqlParameter("id",id));
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
                model.PassWord = (string)GetNull(row["PassWord"]);
                model.Name = (string)row["Name"];
                model.NamePY = (string)GetNull(row["NamePY"]);
                model.HaveBY = Convert.ToBoolean(row["HaveBY"]);
                model.Sex = (string)GetNull(row["Sex"]);
                model.IDCardNO = (string)GetNull(row["IDCardNO"]);
                model.HomeAddress = (string)GetNull(row["HomeAddress"]);
                model.SchoolRollNO = (string)GetNull(row["SchoolRollNO"]);
                model.NowGuardian = (Guid?)GetNull(row["NowGuardian"]);
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

        public IEnumerable<StudentInfoModel> GetAll()
        {
            DataTable dt = SqlHelper.ExecuteDataTable("select * from T_StudentInfo");
            List<StudentInfoModel> list = new List<StudentInfoModel>();
            foreach (DataRow row in dt.Rows)
            {
                StudentInfoModel model = new StudentInfoModel();
                model.id = new Guid(row["id"].ToString());
                model.UserName = (string)GetNull(row["UserName"]);
                model.PassWord = (string)GetNull(row["PassWord"]);
                model.Name = (string)row["Name"];
                model.NamePY = (string)GetNull(row["NamePY"]);
                model.HaveBY = Convert.ToBoolean(row["HaveBY"]);
                model.Sex = (string)GetNull(row["Sex"]);
                model.IDCardNO = (string)GetNull(row["IDCardNO"]);
                model.HomeAddress = (string)GetNull(row["HomeAddress"]);
                model.SchoolRollNO = (string)GetNull(row["SchoolRollNO"]);
                //if (row["NowGuardian"] != DBNull.Value)
                //{
                //    model.NowGuardian = new Guid(row["NowGuardian"].ToString());
                //}
                //else {
                model.NowGuardian = null;
                //}
                model.IsStayAtHomeChild = Convert.ToBoolean(row["IsStayAtHomeChild"]);
                model.IsMigrants = Convert.ToBoolean(row["IsMigrants"]);
                model.IsDeLess = Convert.ToBoolean(row["IsDeLess"]);
                model.IsHeartLess = Convert.ToBoolean(row["IsHeartLess"]);
                model.IsPoor = Convert.ToBoolean(row["IsPoor"]);
                model.Remark = (string)GetNull(row["Remark"]);
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
