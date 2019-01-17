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
    partial class V_ClassDAL
    {
        public int AddNew(V_ClassModel model)
        {
            object obj = SqlHelper.ExecuteScalar("insert into V_Class(id,TeacherId,ClassName,Year,Remark,Name) values(@id,@TeacherId,@ClassName,@Year,@Remark,@Name )",
                            new MySqlParameter("id", model.id),
                            new MySqlParameter("TeacherId", PutNull(model.TeacherId)),
                            new MySqlParameter("ClassName", model.ClassName),
                            new MySqlParameter("Year", model.Year),
                            new MySqlParameter("Remark", PutNull(model.Remark)),
                            new MySqlParameter("Name", model.Name));
            return Convert.ToInt32(obj);
        }

        public int Delete(Guid id)
        {
            return SqlHelper.ExecuteNonQuery("delete from V_Class where id=@id",
                new MySqlParameter("id",id));
        }

        public int Update(V_ClassModel model)
        {
            object obj = SqlHelper.ExecuteScalar("update V_Class set TeacherId=@TeacherId,ClassName=@ClassName,Year=@Year,Remark=@Remark,Name=@Name where id=@id",
                            new MySqlParameter("TeacherId", PutNull(model.TeacherId)),
                            new MySqlParameter("ClassName", model.ClassName),
                            new MySqlParameter("Year", model.Year),
                            new MySqlParameter("Remark", PutNull(model.Remark)),
                            new MySqlParameter("Name", model.Name),
                new MySqlParameter("id",model.id));
            return Convert.ToInt32(obj);
        }
        public V_ClassModel Get(Guid id)
        {
            DataTable dt = SqlHelper.ExecuteDataTable("select * from V_Class where id=@id",
                new MySqlParameter("id",id));
            if (dt.Rows.Count <= 0)
            {
                return null;
            }
            else if (dt.Rows.Count == 1)
            {
                V_ClassModel model = new V_ClassModel();
                DataRow row = dt.Rows[0];
                model.id= new Guid(row["id"].ToString());
                model.TeacherId= (Guid?)GetNull(row["TeacherId"]);
                model.ClassName= (string)row["ClassName"];
                model.Year= (string)row["Year"];
                model.Remark= (string)GetNull(row["Remark"]);
                model.Name= (string)row["Name"];
                return model;
            }
            else
            {
                throw new Exception("出现多条数据！");
            }
        }

        public IEnumerable<V_ClassModel> GetAll()
        {
            DataTable dt = SqlHelper.ExecuteDataTable("select * from V_Class order by ClassName");
            List<V_ClassModel> list = new List<V_ClassModel>();
            foreach (DataRow row in dt.Rows)
            {
                V_ClassModel model = new V_ClassModel();
                model.id= new Guid(row["id"].ToString());
                if (row["TeacherId"] != null)
                {
                    model.TeacherId = new Guid(row["TeacherId"].ToString());
                }
                model.ClassName= (string)row["ClassName"];
                model.Year= (string)row["Year"];
                model.Remark= (string)GetNull(row["Remark"]);
                model.Name= (string)row["Name"];
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
