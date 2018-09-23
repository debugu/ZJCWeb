using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Data.OleDb;

namespace Data
{
    partial class ClassDAL
    {
        public int AddNew(ClassModel model)
        {
            object obj = SqlHelper.ExecuteScalar("insert into T_Class(id,TeacherId,ClassName,Year,Remark) values(@id,@TeacherId,@ClassName,@Year,@Remark )",
                            new SqlParameter("id", model.id),
                            new SqlParameter("TeacherId", model.TeacherId),
                            new SqlParameter("ClassName", model.ClassName),
                            new SqlParameter("Year", model.Year),
                            new SqlParameter("Remark", PutNull(model.Remark)));
            return Convert.ToInt32(obj);
        }

        public int Delete(Guid id)
        {
            return SqlHelper.ExecuteNonQuery("delete from T_Class where id=@id",
                new SqlParameter("id",id));
        }

        public int Update(ClassModel model)
        {
            object obj = SqlHelper.ExecuteScalar("update T_Class set TeacherId=@TeacherId,ClassName=@ClassName,Year=@Year,Remark=@Remark where id=@id",
                            new SqlParameter("TeacherId", model.TeacherId),
                            new SqlParameter("ClassName", model.ClassName),
                            new SqlParameter("Year", model.Year),
                            new SqlParameter("Remark", PutNull(model.Remark)),
                new SqlParameter("id",model.id));
            return Convert.ToInt32(obj);
        }
        public ClassModel Get(Guid id)
        {
            DataTable dt = SqlHelper.ExecuteDataTable("select * from T_Class where id=@id",
                new SqlParameter("id",id));
            if (dt.Rows.Count <= 0)
            {
                return null;
            }
            else if (dt.Rows.Count == 1)
            {
                ClassModel model = new ClassModel();
                DataRow row = dt.Rows[0];
                model.id= (Guid)row["id"];
                model.TeacherId= (Guid)row["TeacherId"];
                model.ClassName= (string)row["ClassName"];
                model.Year= (string)row["Year"];
                model.Remark= (string)GetNull(row["Remark"]);
                return model;
            }
            else
            {
                throw new Exception("出现多条数据！");
            }
        }

        public IEnumerable<ClassModel> GetAll()
        {
            DataTable dt = SqlHelper.ExecuteDataTable("select * from T_Class");
            List<ClassModel> list = new List<ClassModel>();
            foreach (DataRow row in dt.Rows)
            {
                ClassModel model = new ClassModel();
                model.id= (Guid)row["id"];
                model.TeacherId= (Guid)row["TeacherId"];
                model.ClassName= (string)row["ClassName"];
                model.Year= (string)row["Year"];
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
