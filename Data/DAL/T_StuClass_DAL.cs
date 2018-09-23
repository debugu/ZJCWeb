using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Data.OleDb;

namespace Data
{
    partial class StuClassDAL
    {
        public int AddNew(StuClassModel model)
        {
            object obj = SqlHelper.ExecuteScalar("insert into T_StuClass(id,StuId,ClassId) values(@id,@StuId,@ClassId )",
                            new SqlParameter("id", model.id),
                            new SqlParameter("StuId", model.StuId),
                            new SqlParameter("ClassId", model.ClassId));
            return Convert.ToInt32(obj);
        }

        public int Delete(Guid id)
        {
            return SqlHelper.ExecuteNonQuery("delete from T_StuClass where id=@id",
                new SqlParameter("id",id));
        }

        public int Update(StuClassModel model)
        {
            object obj = SqlHelper.ExecuteScalar("update T_StuClass set StuId=@StuId,ClassId=@ClassId where id=@id",
                            new SqlParameter("StuId", model.StuId),
                            new SqlParameter("ClassId", model.ClassId),
                new SqlParameter("id",model.id));
            return Convert.ToInt32(obj);
        }
        public StuClassModel Get(Guid id)
        {
            DataTable dt = SqlHelper.ExecuteDataTable("select * from T_StuClass where id=@id",
                new SqlParameter("id",id));
            if (dt.Rows.Count <= 0)
            {
                return null;
            }
            else if (dt.Rows.Count == 1)
            {
                StuClassModel model = new StuClassModel();
                DataRow row = dt.Rows[0];
                model.id= (Guid)row["id"];
                model.StuId= (Guid)row["StuId"];
                model.ClassId= (Guid)row["ClassId"];
                return model;
            }
            else
            {
                throw new Exception("出现多条数据！");
            }
        }

        public IEnumerable<StuClassModel> GetAll()
        {
            DataTable dt = SqlHelper.ExecuteDataTable("select * from T_StuClass");
            List<StuClassModel> list = new List<StuClassModel>();
            foreach (DataRow row in dt.Rows)
            {
                StuClassModel model = new StuClassModel();
                model.id= (Guid)row["id"];
                model.StuId= (Guid)row["StuId"];
                model.ClassId= (Guid)row["ClassId"];
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
