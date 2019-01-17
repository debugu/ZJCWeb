using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace Data
{
    partial class StuClassDAL
    {
        public int AddNew(StuClassModel model)
        {
            object obj = SqlHelper.ExecuteScalar("insert into T_StuClass(id,StuId,ClassId) values(@id,@StuId,@ClassId )",
                            new MySqlParameter("id", model.id.ToString()),
                            new MySqlParameter("StuId", model.StuId.ToString()),
                            new MySqlParameter("ClassId", model.ClassId.ToString()));
            return Convert.ToInt32(obj);
        }

        public int Delete(Guid id)
        {
            return SqlHelper.ExecuteNonQuery("delete from T_StuClass where id=@id",
                new MySqlParameter("id",id.ToString()));
        }

        public int Update(StuClassModel model)
        {
            object obj = SqlHelper.ExecuteScalar("update T_StuClass set StuId=@StuId,ClassId=@ClassId where id=@id",
                            new MySqlParameter("StuId", model.StuId.ToString()),
                            new MySqlParameter("ClassId", model.ClassId.ToString()),
                new MySqlParameter("id",model.id.ToString()));
            return Convert.ToInt32(obj);
        }
        public StuClassModel Get(Guid id)
        {
            DataTable dt = SqlHelper.ExecuteDataTable("select * from T_StuClass where id=@id",
                new MySqlParameter("id",id));
            if (dt.Rows.Count <= 0)
            {
                return null;
            }
            else if (dt.Rows.Count == 1)
            {
                StuClassModel model = new StuClassModel();
                DataRow row = dt.Rows[0];
                model.id= new Guid(row["id"].ToString());
                model.StuId= new Guid(row["StuId"].ToString());
                model.ClassId= new Guid(row["ClassId"].ToString());
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
                model.id= new Guid(row["id"].ToString());
                model.StuId= new Guid(row["StuId"].ToString());
                model.ClassId= new Guid(row["ClassId"].ToString());
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
