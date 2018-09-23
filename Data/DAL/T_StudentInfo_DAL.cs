using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Data.OleDb;

namespace Data
{
    partial class StudentInfoDAL
    {
        public int AddNew(StudentInfoModel model)
        {
            object obj = SqlHelper.ExecuteScalar("insert into T_StudentInfo(id,UserName,PassWord,Name,NamePY,HaveBY,Sex,IDCardNO,HomeAddress,SchoolRollNO,NowGuardian,IsStayAtHomeChild,IsMigrants,IsDeLess,IsHeartLess,IsPoor,Remark) values(@id,@UserName,@PassWord,@Name,@NamePY,@HaveBY,@Sex,@IDCardNO,@HomeAddress,@SchoolRollNO,@NowGuardian,@IsStayAtHomeChild,@IsMigrants,@IsDeLess,@IsHeartLess,@IsPoor,@Remark )",
                            new SqlParameter("id", model.id),
                            new SqlParameter("UserName", model.UserName),
                            new SqlParameter("PassWord", model.PassWord),
                            new SqlParameter("Name", model.Name),
                            new SqlParameter("NamePY", PutNull(model.NamePY)),
                            new SqlParameter("HaveBY", model.HaveBY),
                            new SqlParameter("Sex", PutNull(model.Sex)),
                            new SqlParameter("IDCardNO", PutNull(model.IDCardNO)),
                            new SqlParameter("HomeAddress", PutNull(model.HomeAddress)),
                            new SqlParameter("SchoolRollNO", PutNull(model.SchoolRollNO)),
                            new SqlParameter("NowGuardian", PutNull(model.NowGuardian)),
                            new SqlParameter("IsStayAtHomeChild", model.IsStayAtHomeChild),
                            new SqlParameter("IsMigrants", model.IsMigrants),
                            new SqlParameter("IsDeLess", model.IsDeLess),
                            new SqlParameter("IsHeartLess", model.IsHeartLess),
                            new SqlParameter("IsPoor", model.IsPoor),
                            new SqlParameter("Remark", PutNull(model.Remark)));
            return Convert.ToInt32(obj);
        }

        public int Delete(Guid id)
        {
            return SqlHelper.ExecuteNonQuery("delete from T_StudentInfo where id=@id",
                new SqlParameter("id",id));
        }

        public int Update(StudentInfoModel model)
        {
            object obj = SqlHelper.ExecuteScalar("update T_StudentInfo set UserName=@UserName,PassWord=@PassWord,Name=@Name,NamePY=@NamePY,HaveBY=@HaveBY,Sex=@Sex,IDCardNO=@IDCardNO,HomeAddress=@HomeAddress,SchoolRollNO=@SchoolRollNO,NowGuardian=@NowGuardian,IsStayAtHomeChild=@IsStayAtHomeChild,IsMigrants=@IsMigrants,IsDeLess=@IsDeLess,IsHeartLess=@IsHeartLess,IsPoor=@IsPoor,Remark=@Remark where id=@id",
                            new SqlParameter("UserName", model.UserName),
                            new SqlParameter("PassWord", model.PassWord),
                            new SqlParameter("Name", model.Name),
                            new SqlParameter("NamePY", PutNull(model.NamePY)),
                            new SqlParameter("HaveBY", model.HaveBY),
                            new SqlParameter("Sex", PutNull(model.Sex)),
                            new SqlParameter("IDCardNO", PutNull(model.IDCardNO)),
                            new SqlParameter("HomeAddress", PutNull(model.HomeAddress)),
                            new SqlParameter("SchoolRollNO", PutNull(model.SchoolRollNO)),
                            new SqlParameter("NowGuardian", PutNull(model.NowGuardian)),
                            new SqlParameter("IsStayAtHomeChild", model.IsStayAtHomeChild),
                            new SqlParameter("IsMigrants", model.IsMigrants),
                            new SqlParameter("IsDeLess", model.IsDeLess),
                            new SqlParameter("IsHeartLess", model.IsHeartLess),
                            new SqlParameter("IsPoor", model.IsPoor),
                            new SqlParameter("Remark", PutNull(model.Remark)),
                new SqlParameter("id",model.id));
            return Convert.ToInt32(obj);
        }
        public StudentInfoModel Get(Guid id)
        {
            DataTable dt = SqlHelper.ExecuteDataTable("select * from T_StudentInfo where id=@id",
                new SqlParameter("id",id));
            if (dt.Rows.Count <= 0)
            {
                return null;
            }
            else if (dt.Rows.Count == 1)
            {
                StudentInfoModel model = new StudentInfoModel();
                DataRow row = dt.Rows[0];
                model.id= (Guid)row["id"];
                model.UserName= (string)row["UserName"];
                model.PassWord= (string)row["PassWord"];
                model.Name= (string)row["Name"];
                model.NamePY= (string)GetNull(row["NamePY"]);
                model.HaveBY= (bool)row["HaveBY"];
                model.Sex= (string)GetNull(row["Sex"]);
                model.IDCardNO= (string)GetNull(row["IDCardNO"]);
                model.HomeAddress= (string)GetNull(row["HomeAddress"]);
                model.SchoolRollNO= (string)GetNull(row["SchoolRollNO"]);
                model.NowGuardian= (Guid?)GetNull(row["NowGuardian"]);
                model.IsStayAtHomeChild= (bool)row["IsStayAtHomeChild"];
                model.IsMigrants= (bool)row["IsMigrants"];
                model.IsDeLess= (bool)row["IsDeLess"];
                model.IsHeartLess= (bool)row["IsHeartLess"];
                model.IsPoor= (bool)row["IsPoor"];
                model.Remark= (string)GetNull(row["Remark"]);
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
                model.id= (Guid)row["id"];
                model.UserName= (string)row["UserName"];
                model.PassWord= (string)row["PassWord"];
                model.Name= (string)row["Name"];
                model.NamePY= (string)GetNull(row["NamePY"]);
                model.HaveBY= (bool)row["HaveBY"];
                model.Sex= (string)GetNull(row["Sex"]);
                model.IDCardNO= (string)GetNull(row["IDCardNO"]);
                model.HomeAddress= (string)GetNull(row["HomeAddress"]);
                model.SchoolRollNO= (string)GetNull(row["SchoolRollNO"]);
                model.NowGuardian= (Guid?)GetNull(row["NowGuardian"]);
                model.IsStayAtHomeChild= (bool)row["IsStayAtHomeChild"];
                model.IsMigrants= (bool)row["IsMigrants"];
                model.IsDeLess= (bool)row["IsDeLess"];
                model.IsHeartLess= (bool)row["IsHeartLess"];
                model.IsPoor= (bool)row["IsPoor"];
                model.Remark= (string)GetNull(row["Remark"]);
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
