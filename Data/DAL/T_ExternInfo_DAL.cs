using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Data.OleDb;

namespace Data
{
    partial class ExternInfoDAL
    {
        public int AddNew(ExternInfoModel model)
        {
            object obj = SqlHelper.ExecuteScalar("insert into T_ExternInfo(id,StuId,GoSchoolTool,ShuttleMode,ClassId) values(@id,@StuId,@GoSchoolTool,@ShuttleMode,@ClassId )",
                            new SqlParameter("id", model.id),
                            new SqlParameter("StuId", model.StuId),
                            new SqlParameter("GoSchoolTool", PutNull(model.GoSchoolTool)),
                            new SqlParameter("ShuttleMode", PutNull(model.ShuttleMode)),
                            new SqlParameter("ClassId", model.ClassId));
            return Convert.ToInt32(obj);
        }

        public int Delete(Guid id)
        {
            return SqlHelper.ExecuteNonQuery("delete from T_ExternInfo where id=@id",
                new SqlParameter("id",id));
        }

        public int Update(ExternInfoModel model)
        {
            object obj = SqlHelper.ExecuteScalar("update T_ExternInfo set StuId=@StuId,GoSchoolTool=@GoSchoolTool,ShuttleMode=@ShuttleMode,ClassId=@ClassId where id=@id",
                            new SqlParameter("StuId", model.StuId),
                            new SqlParameter("GoSchoolTool", PutNull(model.GoSchoolTool)),
                            new SqlParameter("ShuttleMode", PutNull(model.ShuttleMode)),
                            new SqlParameter("ClassId", model.ClassId),
                new SqlParameter("id",model.id));
            return Convert.ToInt32(obj);
        }
        public ExternInfoModel Get(Guid id)
        {
            DataTable dt = SqlHelper.ExecuteDataTable("select * from T_ExternInfo where id=@id",
                new SqlParameter("id",id));
            if (dt.Rows.Count <= 0)
            {
                return null;
            }
            else if (dt.Rows.Count == 1)
            {
                ExternInfoModel model = new ExternInfoModel();
                DataRow row = dt.Rows[0];
                model.id= (Guid)row["id"];
                model.StuId= (Guid)row["StuId"];
                model.GoSchoolTool= (string)GetNull(row["GoSchoolTool"]);
                model.ShuttleMode= (string)GetNull(row["ShuttleMode"]);
                model.ClassId= (Guid)row["ClassId"];
                return model;
            }
            else
            {
                throw new Exception("出现多条数据！");
            }
        }

        public IEnumerable<ExternInfoModel> GetAll()
        {
            DataTable dt = SqlHelper.ExecuteDataTable("select * from T_ExternInfo");
            List<ExternInfoModel> list = new List<ExternInfoModel>();
            foreach (DataRow row in dt.Rows)
            {
                ExternInfoModel model = new ExternInfoModel();
                model.id= (Guid)row["id"];
                model.StuId= (Guid)row["StuId"];
                model.GoSchoolTool= (string)GetNull(row["GoSchoolTool"]);
                model.ShuttleMode= (string)GetNull(row["ShuttleMode"]);
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
